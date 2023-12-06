const Home = {
    data() {
        return {
        };
    },

    methods: {

    },

    created() {
    
    },


    template: /*html*/ `
		<div class="row w-100 h-100 p-2 m-0">
            <div class="card my-1" style=" background-image: url('https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain');background-size: cover;background-position: center;">
                <carousel></carousel>
            </div>
            <div class="card bg-warning my-1 p-1">
                <maps></maps>
            </div>
			<list-cards></list-cards>
            <div class="card bg-dark mt-1">
                <footer-view></footer-view>
            </div>
		</div>
	`,
};

export { Home };
