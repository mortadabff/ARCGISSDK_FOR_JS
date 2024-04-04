require([
    "esri/config",
    "esri/Map",
    "esri/views/MapView",
    "esri/widgets/BasemapToggle",
    "esri/layers/FeatureLayer",
    "esri/PopupTemplate"
  ], function(esriConfig, Map, MapView, BasemapToggle, FeatureLayer, PopupTemplate) {
    
    esriConfig.apiKey = "AAPK7324697cbd7848de9b9a3ec4079db8ecvHN4GtuWJHgu6ndHccXKf0XdBDRP4W4PVbdn-TSi8E5xsXU7AMzVXVWDOzEsCkYy";

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

    var popupCommune = new PopupTemplate({
      title: "<b>Commune: {COMMUNE_AR}</b>",
      content: "<p>PREFECTURE : {PREFECTURE}</p>" +
               "<p>Communes : {COMMUNE_AR}</p>" +
               "<p>Surface : {Shape_Area}</p>"
    });

    const communesLayer = new FeatureLayer({
      url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
      outFields: ["PREFECTURE", "COMMUNE_AR", "Shape_Area"],
      popupTemplate: popupCommune
    });

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

    const populationLayer = new FeatureLayer({
      url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/casa_population1/FeatureServer/0",
      outFields: ["TOTAL1994", "TOTAL2004"],
      popupTemplate: popupPopulation
    });

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

    const voirieLayer = new FeatureLayer({
      url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/voirie_casa/FeatureServer/0",
      outFields: ["NOM", "LENGTH"],
      popupTemplate: popupVoirie
    });

    // Ajout des couches à la carte
    map.add(communesLayer);
    map.add(populationLayer);
    map.add(voirieLayer);
  });
