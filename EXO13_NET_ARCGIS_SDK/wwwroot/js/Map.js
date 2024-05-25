/*import { apiKey1 } from '../../../Ressources/config.js';

require(["esri/config", "esri/Map", "esri/views/MapView", "esri/geometry/Extent", 
"esri/widgets/BasemapToggle", "esri/widgets/BasemapGallery",
 "esri/layers/FeatureLayer", "esri/layers/TileLayer", "esri/widgets/LayerList"],
 function (esriConfig, Map, MapView, Extent, BasemapToggle, BasemapGallery, 
FeatureLayer, TileLayer, LayerList) {
 esriConfig.apiKey = "AAPK7324697cbd7848de9b9a3ec4079db8ecvHN4GtuWJHgu6ndHccXKf0XdBDRP4W4PVbdn-TSi8E5xsXU7AMzVXVWDOzEsCkYy";
 
 const map = new Map({
 basemap: "arcgis-imagery"
 });
 const view = new MapView({
 map: map,
 container: "viewDiv",
 //extent: extent
 zoom: 13,
 center: [-7.62, 33.59]
 });
});
*/
require(["esri/Map", "esri/views/MapView"], function(Map, MapView) {
    var map = new Map({
        basemap: "topo-vector"
    });

    var view = new MapView({
        container: "viewDiv", // Reference to the scene div created in step 5
        map: map, // Reference to the map object created before the scene
        center: [-118.71511, 34.09042], // Longitude, latitude
        zoom: 11 // Zoom level
    });
});