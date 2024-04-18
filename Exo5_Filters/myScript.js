require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/widgets/BasemapToggle",
  "esri/layers/FeatureLayer"
], function(
  esriConfig, Map, MapView, BasemapToggle, FeatureLayer
) {
  
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

  // Communes Feature Layer
  const communesLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
    outFields: ["PREFECTURE", "COMMUNE_AR", "Shape_Area"]
  });

  const popupPopulation = {
    title: "Population Data",
    content: "Total 1994: {TOTAL1994}, Total 2004: {TOTAL2004}"
  };

  // Population Feature Layer
  const populationLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/casa_population1/FeatureServer/0",
    outFields: ["PREFECTURE","TOTAL1994", "TOTAL2004","MÉNAGES200"],
    popupTemplate: popupPopulation
  });

  map.add(communesLayer); 
  map.add(populationLayer);

  // SQL expressions for filtering
  const sqlExpressions = [
    "Shape_Area >= 0",
    "Shape_Area < 5000000",
    "PREFECTURE = 'PROVINCE DE MEDIOUNA'",
    "PLAN_AMENA = 'PA HOMOLOGUE'",
  ];
  const sqlExpressionPopulation = "TOTAL2004 > 100000 and MÉNAGES200> 30000";


  // Create a select element to hold SQL expressions
  const selectFilter = document.createElement("select");
  sqlExpressions.forEach(function(sql) {
    let option = document.createElement("option");
    option.value = sql;
    option.innerHTML = sql === "Shape_Area >= 0" ? "Tous les couches" : sql;
    selectFilter.appendChild(option);
  });
  let optionPopulation = document.createElement("option");
optionPopulation.value = sqlExpressionPopulation;
optionPopulation.innerHTML = "Population 2004 > 100,000 and MENAGE 2004 > 3000";
selectFilter.appendChild(optionPopulation);



  // Add the select element to the view
  view.ui.add(selectFilter, "top-right");

  // Function to set the filter on the feature layer based on selected SQL expression
  function setFeatureLayerFilter(expression) {
    communesLayer.definitionExpression = expression;
    if (expression.includes("TOTAL2004")) {  // Check if the expression involves population data
      populationLayer.definitionExpression = expression;
    } else {
      populationLayer.definitionExpression = "";  // Reset population layer if not relevant
    }
  }

  // Event listener for select element changes
  selectFilter.addEventListener('change', function(event) {
    const selectedValue = event.target.value;
  
    // Reset both layers' definition expression
    communesLayer.definitionExpression = "";
    populationLayer.definitionExpression = "";
  
    // Check if the selected value is for the population layer
    if (selectedValue === sqlExpressionPopulation) {
      populationLayer.definitionExpression = selectedValue;
      populationLayer.queryFeatures({
        where: selectedValue,
        returnGeometry: false,
        outFields: ["PREFECTURE"]
      })
      .then(function(results) {
        // Extract PREFECTURE values and create a list
        const prefectures = results.features.map(feature => feature.attributes.PREFECTURE);
        // Create a unique list if necessary
        const uniquePrefectures = [...new Set(prefectures)];
        // Construct an SQL expression for the communesLayer
        const communesWhereClause = uniquePrefectures.map(prefecture => `'${prefecture}'`).join(",");
        const sqlCommunes = `PREFECTURE IN (${communesWhereClause})`;
        // Apply the filter to the communesLayer
        communesLayer.definitionExpression = sqlCommunes;
      })
      .catch(function(error) {
        console.error("Error querying population layer:", error);
      });
    } else {
      // If not, it's for the communes layer
      communesLayer.definitionExpression = selectedValue;
    }
  });

});
