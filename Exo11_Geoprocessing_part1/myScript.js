require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/geometry/Extent",
  "esri/widgets/BasemapToggle",
  "esri/layers/GraphicsLayer",
  "esri/Graphic",
  "esri/rest/support/RouteParameters",
  "esri/rest/support/FeatureSet",
  "esri/layers/RouteLayer",
  "esri/rest/route",
  "esri/Graphic",
  "esri/widgets/Sketch"
], function (esriConfig, Map, MapView, Extent, BasemapToggle, GraphicsLayer, Graphic, RouteParameters, FeatureSet, RouteLayer, route, Graphic, Sketch) {
  // Configuration de l'API
  esriConfig.apiKey = "AAPKf984b22aa3974c1c9c6465ccb7a53c3dom8v9T2ttdgZUpzwQU0D_iAI7I5gkxkjdg4DReBwHW_dO3RImAR1V5A6_8uOQxOd";

  // Création de la carte
  const map = new Map({
      basemap: "arcgis-topographic"
  });

  // Création d'une couche pour afficher l'itinéraire
  const routeLayer = new GraphicsLayer();
  map.add(routeLayer);

  // Paramètres de l'itinéraire
  const routeParams = new RouteParameters({
      apiKey: "AAPKf984b22aa3974c1c9c6465ccb7a53c3dom8v9T2ttdgZUpzwQU0D_iAI7I5gkxkjdg4DReBwHW_dO3RImAR1V5A6_8uOQxOd",
      stops: new FeatureSet(),
      outSpatialReference: {
          wkid: 3857
      }
  });

  const routeUrl = "https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World";; 
  

  // Symboles pour les points d'arrêt et de départ
  const stopSymbol = {
      type: "simple-marker",
      style: "cross",
      size: 15,
      outline: {
          width: 4
      }
  };

  // Symbole pour l'itinéraire
  const routeSymbol = {
      type: "simple-line",
      color: [0, 0, 255, 0.5],
      width: 5
  };

  // Création de la vue de la carte
  const view = new MapView({
      map: map,
      container: "viewDiv",
      extent: new Extent({
          xmin: -894598.725692621,
          ymin: 3969275.0537849413,
          xmax: -783555.9138073823,
          ymax: 4006819.994959998,
          spatialReference: 102100
      })
  });

  // Ajout du basemap toggle
  const basemapToggle = new BasemapToggle({
      view: view,
      nextBasemap: "arcgis-imagery"
  });
  view.ui.add(basemapToggle, { position: "top-right" });

  // Ajout du widget Sketch
  const sketchWidget = new Sketch({
      view: view,
      layer: routeLayer
  });
  view.ui.add(sketchWidget, "top-right");

  // Fonction pour ajouter un point d'arrêt lorsque l'utilisateur clique sur la carte
  view.on("click", addStop);

  function addStop(event) {
      const stop = new Graphic({
          geometry: event.mapPoint,
          symbol: stopSymbol
      });
      routeLayer.add(stop);
      routeParams.stops.features.push(stop);

      if (routeParams.stops.features.length >= 2) {
          // Résolution de l'itinéraire
          route.solve(routeUrl, routeParams).then(showRoute);
      }
  }

  // Fonction pour afficher l'itinéraire sur la carte
  function showRoute(data) {
      const routeResult = data.routeResults[0].route;
      routeResult.symbol = routeSymbol;
      routeLayer.add(routeResult);
    }
});