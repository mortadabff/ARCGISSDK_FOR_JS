import { apiKey1 } from '../Ressources/config.js';

require([
    "esri/config",
    "esri/Map",
    "esri/views/MapView",
    "esri/widgets/BasemapToggle",
    "esri/layers/FeatureLayer",
    "esri/PopupTemplate"
  ], function(esriConfig, Map, MapView, BasemapToggle, FeatureLayer, PopupTemplate) {
    
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

    
    const communesLayer = new FeatureLayer({
      url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
      outFields: ["PREFECTURE", "COMMUNE_AR", "Shape_Area"],
    });

    

    const populationLayer = new FeatureLayer({
      url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/casa_population1/FeatureServer/0",
      outFields: ["TOTAL1994", "TOTAL2004"],
    });

    

    const voirieLayer = new FeatureLayer({
      url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/voirie_casa/FeatureServer/0",
      outFields: ["NOM", "LENGTH"],
    });

    // Ajout des couches à la carte
    map.add(communesLayer);
    map.add(populationLayer);
    map.add(voirieLayer);
  });
