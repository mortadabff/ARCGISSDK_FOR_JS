
require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/layers/FeatureLayer",
  "esri/widgets/Editor"
], function(esriConfig, Map, MapView, FeatureLayer, Editor) {
  // Configuration de l'API
  esriConfig.apiKey = "AAPK7324697cbd7848de9b9a3ec4079db8ecvHN4GtuWJHgu6ndHccXKf0XdBDRP4W4PVbdn-TSi8E5xsXU7AMzVXVWDOzEsCkYy";
  

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
  const commune = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
  });
  map.add(commune);

  // Configuration du widget Editor
  const editor = new Editor({
    view: view,
    layerInfos: [{
      layer: commune,
      formTemplate: {
        elements: [
          {
            type: "field",
            fieldName: "PREFECTURE",
            label: "PREFECTURE",
            domain: {
              type: "coded-value",
              name: "PREFECTURE",
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
            label: "plan aménagement"
          }
        ]
      },
      enabled: true,
      addEnabled: true,
      updateEnabled: true,
      deleteEnabled: true,
      attributeUpdatesEnabled: true,
      geometryUpdatesEnabled: true,
      attachmentsOnCreateEnabled: true,
      attachmentsOnUpdateEnabled: true
    }]
  });

  // Ajout du widget Editor à la vue
  view.ui.add(editor, "top-right");
});
