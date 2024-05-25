import { apiKey1 } from '../Ressources/config.js';

require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/widgets/BasemapToggle",
  "esri/layers/FeatureLayer",
  "esri/PopupTemplate",
  "esri/renderers/SimpleRenderer",
  "esri/renderers/ClassBreaksRenderer",
  "esri/symbols/SimpleMarkerSymbol",
  "esri/symbols/SimpleLineSymbol",
  "esri/symbols/SimpleFillSymbol"
], function(
  esriConfig, Map, MapView, BasemapToggle, FeatureLayer, PopupTemplate,
  SimpleRenderer, ClassBreaksRenderer, SimpleMarkerSymbol, SimpleLineSymbol, SimpleFillSymbol
) {
  
  esriConfig.apiKey = apiKey1;
  
  const map = new Map({
    basemap: "arcgis-topographic"
  });

  const view = new MapView({
    map: map,
    center: [-7.62, 33.59],
    zoom: 13,
    container: "viewDiv"
  });

  const basemapToggle = new BasemapToggle({
    view: view,
    nextBasemap: "arcgis-imagery"
  });

  view.ui.add(basemapToggle, "bottom-right");

  // Fenêtre contextuelle pour la couche des communes
  var popupCommune = new PopupTemplate({
    title: "<b>Commune: {COMMUNE_AR}</b>",
    content: "<p>PREFECTURE : {PREFECTURE}</p>" +
             "<p>Communes : {COMMUNE_AR}</p>" +
             "<p>Surface : {Shape_Area}</p>"
  });

  // Popup pour la couche de population
  var popupPopulation = new PopupTemplate({
    title: "<b>Population de : {ARRONDISSE}</b>",
    content: [{
      type: "media",
      mediaInfos: [{
        type: "column-chart",
        caption: "Statistiques de la population",
        value: {
          fields: ["TOTAL1994", "TOTAL2004"],
          normalizeField: null,
          tooltipField: ""
        }
      }]
    }]
  });

  // Popup pour la couche de voirie
  var popupVoirie = new PopupTemplate({
    title: "Voirie de Casablanca",
    content: [{
      type: "fields",
      fieldInfos: [
        { fieldName: "NOM", label: "Nom", isEditable: true, tooltip: "", visible: true, format: null, stringFieldOption: "text-box" },
        { fieldName: "LENGTH", label: "Longueur", isEditable: true, tooltip: "", visible: true, format: { places: 1, digitSeparator: true }, stringFieldOption: "text-box" }
      ]
    }]
  });

  // Symbologie simple pour la couche population
  let popRenderer = new SimpleRenderer({
    symbol: new SimpleMarkerSymbol({
      size: 6,
      color: "green",
      outline: {
        width: 0.5,
        color: "white"
      }
    }),
    visualVariables: [{
      type: "size",
      field: "TOTAL2004",
      minDataValue: 3365,
      maxDataValue: 323944,
      minSize: 8,
      maxSize: 30
    }]
  });

  // Symbologie simple pour la couche voirie
  let voirieRenderer = new SimpleRenderer({
    symbol: new SimpleLineSymbol({
      color: "black",
      width: "2px",
      style: "short-dot"
    })
  });

  // Symbologie dégradée par classe pour la couche communes
  let communeRenderer = new ClassBreaksRenderer({
    field: "Shape_Area",
    classBreakInfos: [
      { minValue: 0, maxValue: 8000000, symbol: new SimpleFillSymbol({ color: [255, 255, 212], style: "solid", outline: { color: "white", width: 1 } }) },
      { minValue: 8000001, maxValue: 16000000, symbol: new SimpleFillSymbol({ color: [254, 227, 145], style: "solid", outline: { color: "white", width: 1 } }) },
      { minValue: 16000001, maxValue: 26000000, symbol: new SimpleFillSymbol({ color: [254, 196, 79], style: "solid", outline: { color: "white", width: 1 } }) },
      { minValue: 26000001, maxValue: 48000000, symbol: new SimpleFillSymbol({ color: [254, 153, 41], style: "solid", outline: { color: "white", width: 1 } }) },
      { minValue: 48000001, maxValue: 78000000, symbol: new SimpleFillSymbol({ color: [217, 95, 14], style: "solid", outline: { color: "white", width: 1 } }) },
      { minValue: 78000001, maxValue: 135000000, symbol: new SimpleFillSymbol({ color: [153, 52, 4], style: "solid", outline: { color: "white", width: 1 } }) }
    ]
  });

  const communesLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
    outFields: ["PREFECTURE", "COMMUNE_AR", "Shape_Area"],
    popupTemplate: popupCommune,
    renderer: communeRenderer
  });

  const populationLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/casa_population1/FeatureServer/0",
    outFields: ["TOTAL1994", "TOTAL2004"],
    popupTemplate: popupPopulation,
    renderer: popRenderer
  });

  const voirieLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/voirie_casa/FeatureServer/0",
    outFields: ["NOM", "LENGTH"],
    popupTemplate: popupVoirie,
    renderer: voirieRenderer
  });

  map.add(communesLayer);
  map.add(populationLayer);
  map.add(voirieLayer);
});
