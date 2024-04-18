
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
    basemap: "arcgis-topographic"  // Basemap of the map
  });

  const view = new MapView({
    map: map,
    center: [-7.62, 33.59],  // Center the map over Casablanca
    zoom: 13,
    container: "viewDiv"     // HTML container ID
  });

  const basemapToggle = new BasemapToggle({
    view: view,
    nextBasemap: "arcgis-imagery"
  });

  view.ui.add(basemapToggle, "bottom-right");

  // Communes Feature Layer
  const communesLayer = new FeatureLayer({
    url: "https://services9.arcgis.com/QrCXNBwrECXYB95b/arcgis/rest/services/communes/FeatureServer/0",
    outFields: ["PREFECTURE", "COMMUNE_AR", "Shape_Area"],
  });

  map.add(communesLayer);  // Adding the communes layer to the map

  // SQL expressions for filtering
  const sqlExpressions = [
    "Shape_Area>=0",
    "Shape_Area < 5000000",
    "PREFECTURE = 'PROVINCE DE MEDIOUNA'",
    "PLAN_AMENA = 'PA HOMOLOGUE'"
  ];

  // Create a select element to hold SQL expressions
  const selectFilter = document.createElement("select");
  sqlExpressions.forEach(function(sql) {
    if(sql=== "Shape_Area>=0"){
      let option = document.createElement("option");
      option.value = sql;
      option.innerHTML = "Tous les couches";
      selectFilter.appendChild(option);
  
    }
    else{
    let option = document.createElement("option");
    option.value = sql;
    option.innerHTML = sql;
    selectFilter.appendChild(option);
  }
  });
 
  // Add the select element to the view
  view.ui.add(selectFilter, "top-right");

  // Function to set the filter on the feature layer based on selected SQL expression
  function setFeatureLayerFilter(expression) {
    communesLayer.definitionExpression = expression;
  }

  // Event listener for select element changes
  selectFilter.addEventListener('change', function(event) {
    setFeatureLayerFilter(event.target.value);
  });

});
