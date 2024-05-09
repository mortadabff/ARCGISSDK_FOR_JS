require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/widgets/BasemapToggle",
  "esri/layers/FeatureLayer",
  "esri/layers/GraphicsLayer",
  "esri/widgets/Sketch"
], function(
  esriConfig, Map, MapView, BasemapToggle, FeatureLayer,GraphicsLayer,Sketch
) {
  ///Part 1:  API configuration , add layers and basemap 

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

  // communes Feature Layer 
  const popupCommune ={
    title: "Commune  Data",
    content:"PREFECTURE : {PREFECTURE} ,  Communes : {COMMUNE_AR} , Surface : {Shape_Area}"
    };

  // Communes Feature Layer
  const communesLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
    outFields: ["PREFECTURE", "COMMUNE_AR", "Shape_Area"],
    popupTemplate: popupCommune

  });

  const popupPopulation = {
    title: "Population Data",
    content: "Total 1994: {TOTAL1994}, Total 2004: {TOTAL2004}"
  };

  // Population Feature Layer
  const populationLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/casa_population1/FeatureServer/0",
    outFields: ["COMMUNE_AR","PREFECTURE","PREFECTU_1","TOTAL1994", "TOTAL2004","MÉNAGES200"],
    popupTemplate: popupPopulation
  });

  map.add(communesLayer); 
  map.add(populationLayer);




///Part 2 :  Filters 

  // SQL expressions pour les filtres (filters) : couche commune
  const sqlExpressions = [
    "Shape_Area >= 0",
    "Shape_Area < 5000000",
    "PREFECTURE = 'PROVINCE DE MEDIOUNA'",
    "PLAN_AMENA = 'PA HOMOLOGUE'",
  ];
    // SQL expressions pour les filtres (filters) : couche population
  const sqlExpressionPopulation = "TOTAL2004 > 100000 ";
  const sqlExpressionPopulation2 = " MÉNAGES200 > 30000";

  // Create a select element to hold SQL expressions : création d'un élement select , dans lequel on va mettre les expressions sql de filtres
  const selectFilter = document.createElement("select");
  sqlExpressions.forEach(function(sql) {
    let option = document.createElement("option");
    option.value = sql;
    option.innerHTML = sql === "Shape_Area >= 0" ? "Tous les couches" : sql;
    selectFilter.appendChild(option);
  });
 // Ajouter les expressions de filtrage de la couche population
  let optionPopulation = document.createElement("option");
  optionPopulation.value = sqlExpressionPopulation;
  optionPopulation.innerHTML = "Population 2004 > 100,000";
  selectFilter.appendChild(optionPopulation);

  let optionPopulation2= document.createElement("option");
  optionPopulation2.value = sqlExpressionPopulation2;
  optionPopulation2.innerHTML = "MENAGE 2004 > 30000";
  selectFilter.appendChild(optionPopulation2);
  view.ui.add(selectFilter, "top-right");

// Add a listener for the select element (Ajouter une event listener au filtre)
  selectFilter.addEventListener('change', function(event) {
    const selectedValue = event.target.value;
  
    communesLayer.definitionExpression = "";
    populationLayer.definitionExpression = "";
  
    if (selectedValue === sqlExpressionPopulation || selectedValue === sqlExpressionPopulation2) {
      populationLayer.definitionExpression = selectedValue;
    
    } else {
      communesLayer.definitionExpression = selectedValue;
    }
  });




///Parte 3 :  SQL QUERY 
    const parcelLayerSQL = [
      "-- Critère de recherche --",
      "PREFECTURE='PREFECTURE DE CASABLANCA'",
      "COMMUNE_AR='MUNICIPALITE BOUSKOURA'",
      "PLAN_AMENA='PA ENQUETE PUBLIQUE'",
      "Shape_Area>40000000",
      "PREFECTURE='PROVINCE DE NOUACEUR' and PLAN_AMENA='PA ENQUETE PUBLIQUE'"
    ];

  // Élément Select pour les requêtes SQL
    const sqlSelect = document.createElement("select");
    parcelLayerSQL.forEach(function(query) {
      let option = document.createElement("option");
      option.innerHTML = query;
      option.value = query === "-- Critère de recherche --" ? "" : query; // Pas de filtre pour la première option
      sqlSelect.appendChild(option);
    });
    view.ui.add(sqlSelect, "bottom-right");
  
    // Fonction pour exécuter la requête SQL et afficher les résultats
    function queryFeatureLayer(whereClause) {
      const parcelQuery = {
        where: whereClause,
        geometry: view.extent,
        outFields: ["PREFECTURE", "COMMUNE_AR", "PLAN_AMENA", "Shape_Area"],
        returnGeometry: true
      };
  
      communesLayer.queryFeatures(parcelQuery).then((results) => {
        displayResults(results);
      }).catch((error) => {
        console.error(error);
      });
    }
  
    // Fonction pour afficher les résultats de la requête
    function displayResults(results) {
        // Create a blue polygon
        const symbol = {
        type: "simple-fill",
        color: [ 226, 135, 67 ],
        outline: {
        color: "yellow",
        width: 1
        }
      };
      
      results.features.forEach((feature) => {
        feature.symbol = symbol;
        feature.popupTemplate = { // Définition du popupTemplate
          title: "Commune {COMMUNE_AR}",
          content: "Prefecture : {PREFECTURE} <br> Commune : {COMMUNE_AR} <br> Plan Aménagement : {PLAN_AMENA} <br> Surface : {Shape_Area}"
        };
        view.graphics.add(feature);
      });
    }
  
    // Mise à jour de l'écouteur d'événements pour le Select
    sqlSelect.addEventListener('change', function(event) {
      const whereClause = event.target.value;
      if (whereClause === "-- Critère de recherche --") {
        
        view.graphics.removeAll();
        view.popup.close();
      } else {
        queryFeatureLayer(whereClause);
      }
    });



    ///
    const graphicsLayerSketch = new GraphicsLayer();
    map.add(graphicsLayerSketch);
  
    // Créer et ajouter le widget Sketch à la vue
    const sketch = new Sketch({
      layer: graphicsLayerSketch,
      view: view,
      creationMode: "update"
    });
    view.ui.add(sketch, "top-right");
  
    // Fonction pour exécuter la requête spatiale sur la couche des communes
    function queryFeaturelayer(geometry) {
      const communeQuery = {
        spatialRelationship: "intersects",
        geometry: geometry,
        outFields: ["PREFECTURE", "COMMUNE_AR", "PLAN_AMENA", "Shape_Area"],
        returnGeometry: true
      };
  
      // Exécuter la requête et afficher les résultats
      communesLayer.queryFeatures(communeQuery).then((results) => {
        displayResults(results);
      }).catch((error) => {
        console.error(error);
      });
    }
  
    // Fonction pour afficher les résultats de la requête spatiale
    function displayResults(results) {
      const symbol = {
        type: "simple-fill",
        color: [ 20, 130, 200, 0.5 ],
        outline: {
          color: "white",
          width: 0.5
        }
      };
      
      view.graphics.removeAll();
      results.features.forEach((feature) => {
        feature.symbol = symbol;
        feature.popupTemplate = {
          title: "Commune {COMMUNE_AR}",
          content: "Prefecture : {PREFECTURE} <br> Commune : {COMMUNE_AR} <br> Plan Aménagement : {PLAN_AMENA} <br> Surface : {Shape_Area}"
        };
        view.graphics.add(feature);
      });
    }
  
    // Écouteur d'événements pour le Sketch
    sketch.on("update", (event) => {
      if (event.state === "start") {
        queryFeaturelayer(event.graphics[0].geometry);
      }
      if (event.state === "complete") {
        graphicsLayerSketch.remove(event.graphics[0]);
      }
      if (event.toolEventInfo && (event.toolEventInfo.type === "scale-stop" || event.toolEventInfo.type === "reshape-stop" || event.toolEventInfo.type === "move-stop")) {
        queryFeaturelayer(event.graphics[0].geometry);
      }
    });
  });
