const mapboxgl = window.mapboxgl;
const mapboxSdk = window.mapboxSdk;
const Maps = {
    data() {
        return {};
    },

    methods: {
        initMap() {
            mapboxgl.accessToken = "";//"pk.eyJ1Ijoia2V2ZWVuIiwiYSI6ImNscHJiem1tcjA4bzAybHM1MW0weWx0bHAifQ.W2vZRJzy5WLpmiwSB6PFOQ";
            const mapboxClient = mapboxSdk({
                accessToken: mapboxgl.accessToken,
            });
            mapboxClient.geocoding
                .forwardGeocode({
                    query: "Belo Horizonte, Minas Gerais, Brasil",
                    autocomplete: false,
                    limit: 1,
                })
                .send()
                .then((response) => {
                    if (
                        !response ||
                        !response.body ||
                        !response.body.features ||
                        !response.body.features.length
                    ) {
                        console.error("Invalid response:");
                        console.error(response);
                        return;
                    }
                    const feature = response.body.features[0];

                    const map = new mapboxgl.Map({
                        container: "map",
                        // Choose from Mapbox's core styles, or make your own style with Mapbox Studio
                        style: "mapbox://styles/mapbox/streets-v12",
                        center: feature.center,
                        zoom: 10,
                    });

                    // Create a marker and add it to the map.
                    new mapboxgl.Marker().setLngLat(feature.center).addTo(map);
                });
        },
    },

    mounted() {
        this.initMap();
    },

    template: /*html*/ `
        <div id='map' ></div>
	`,
};

export { Maps };
