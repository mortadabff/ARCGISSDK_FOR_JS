require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/widgets/BasemapToggle",
  "esri/layers/FeatureLayer",
  "esri/layers/GraphicsLayer", // Load GraphicsLayer module
  "esri/Graphic",              // Load Graphic module
  "esri/geometry/Point",      // Load Point geometry module
  "esri/geometry/Polyline",   // Load Polyline geometry module
  "esri/geometry/Polygon",    // Load Polygon geometry module
  "esri/widgets/Sketch"       // Load Sketch widget module
], function(
  esriConfig, Map, MapView, BasemapToggle, FeatureLayer,
  GraphicsLayer, Graphic, Point, Polyline, Polygon, Sketch
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

  const graphicsLayer = new GraphicsLayer();
  map.add(graphicsLayer); // Adding the graphics layer to the map

   // Point Graphic
   const point = new Point({
    longitude: -7.62,
    latitude: 33.59
  });

  let symbol = {
    type: "simple-marker",
    style: "diamond",
    color: "blue",
    size: "8px",
    outline: {
      color: [255, 255, 0],
      width: 3
    }
  };

  const attributes = {
    Nom: "Graphic",
    Description: "Un graphic point"
  };

  const popupPoint = {
    title: "{Nom}",
    content: "{Description}"
  };

  const pointGraphic = new Graphic({
    geometry: point,
    symbol: symbol,
    attributes: attributes,
    popupTemplate: popupPoint
  });

  graphicsLayer.add(pointGraphic);

  // Polyline Graphic
  const polyline = new Polyline({
    paths: [
      [-7.66, 33.54],
      [-7.64, 33.56],
      [-7.57, 33.58]
    ]
  });

  const simpleLineSymbol = {
    type: "simple-line",
    color: "blue",
    width: 2
  };

  const lineGraphic = new Graphic({
    geometry: polyline,
    symbol: simpleLineSymbol
  });

  graphicsLayer.add(lineGraphic);

  // Polygon Graphic
  const polygon = new Polygon({
    rings: [
      [-7.51, 33.61],
      [-7.47, 33.64],
      [-7.45, 33.61],
      [-7.48, 33.60]
    ]
  });

  const simpleFillSymbol = {
    type: "simple-fill",
    color: "blue",
    outline: {
      color: [255, 255, 255],
      width: 1
    }
  };

  const polygonGraphic = new Graphic({
    geometry: polygon,
    symbol: simpleFillSymbol
  });

  graphicsLayer.add(polygonGraphic);

  // Sketch widget
  let sketch = new Sketch({
    layer: graphicsLayer,
    view: view
  });

  view.ui.add(sketch, "top-left");
});
