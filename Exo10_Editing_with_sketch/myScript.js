import { apiKey1 } from '../Ressources/config.js';

require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/layers/FeatureLayer",
  "esri/layers/GraphicsLayer",
  "esri/widgets/Editor",
  "esri/widgets/Sketch/SketchViewModel",
  "esri/Graphic"
], function(esriConfig, Map, MapView, FeatureLayer, GraphicsLayer, Editor, SketchViewModel, Graphic) {
  // Configuration de l'API
  esriConfig.apiKey =apiKey1;
  
  // Création de la carte
  const map = new Map({
    basemap: "arcgis-topographic" // Utilisez le fond de carte de votre choix
  });

  // Création de la vue de la carte
  const view = new MapView({
    container: "viewDiv", // Spécifiez l'ID de l'élément DOM
    map: map,
    center: [-7.62, 33.59], // Longitude, latitude
    zoom: 13
  });

  // Ajout de la couche de la commune
  const communeLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
  });


  // Création et ajout d'une couche graphique
  const graphicsLayer = new GraphicsLayer();
  map.addMany([graphicsLayer, communeLayer]);

  // Configuration du widget Editor
  const editor = new Editor({
    view: view,
    layerInfos: [{
      layer: communeLayer,
      formTemplate: {
        elements: [
          {
            type: "field",
            fieldName: "PREFECTURE",
            label: "PREFECTURE",
            domain: {
              type: "coded-value",
              codedValues: [
                {name: "PREFECTURE DE CASABLANCA", code: "PREFECTURE DE CASABLANCA"},
                {name: "PROVINCE DE MEDIOUNA", code: "PROVINCE DE MEDIOUNA"},
                {name: "PREFECTURE DE MOHAMMEDIA", code: "PREFECTURE DE MOHAMMEDIA"},
                {name: "PROVINCE DE NOUACEUR", code: "PROVINCE DE NOUACEUR"},
                {name: "PROVINCE DE BEN SLIMANE", code: "PROVINCE DE BEN SLIMANE"}
              ]
            }
          },
          {
            type: "field",
            fieldName: "COMMUNE_AR",
            label: "Commune/Arrondissement"
          },
          {
            type: "field",
            fieldName: "PLAN_AMENA",
            label: "Plan d'aménagement"
          }
        ]
      }
    }]
  });

  // Ajout du widget Editor à la vue
  view.ui.add(editor, "top-right");

  // Ajout d'un bouton pour le dessin
  const drawButton = document.createElement("button");
  drawButton.className = "action-button";
  drawButton.id = "drawButton";
  drawButton.innerText = "Dessiner Projet";
  view.ui.add(drawButton, "bottom-left");

  // Initialisation de SketchViewModel
  let sketchViewModel = new SketchViewModel({
    view: view,
    layer: graphicsLayer
  });

  // Gestion du bouton pour commencer le dessin
  drawButton.onclick = function() {
    sketchViewModel.create("polygon");
  };

  // Événement pour gérer la création de graphiques
  sketchViewModel.on("create", function(event) {
    if (event.state === "complete") {
      graphicsLayer.remove(event.graphic);
      communeLayer.applyEdits({
        addFeatures: [event.graphic]
      });
    }
  });

  // Gestion des suppressions avec Ctrl + Shift + Click
  view.on("click", ["Control", "Shift"], function(event) {
    view.hitTest(event).then(function(response) {
      if (response.results.length > 0) {
        const graphic = response.results.filter(function(result) {
          return result.graphic.layer === communeLayer;
        })[0].graphic;

        communeLayer.applyEdits({
          deleteFeatures: [graphic]
        });
      }
    });
  });

  view.on("click", ["Control", "Delete"], function(event) {
    view.hitTest(event).then(function(response) {
      if (response.results.length > 0) {
        const graphic = response.results.filter(function(result) {
          return result.graphic.layer === communeLayer;
        })[0].graphic;

        communeLayer.applyEdits({
          deleteFeatures: [graphic]
        });
      }
    });
  });
});
