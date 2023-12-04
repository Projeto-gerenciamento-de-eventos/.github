const computed = Vue.computed;
const Root = {
	data() {
		return {

		};
	},

	provide() {
		return {
			//usuarioLogado: computed(() => this.usuarioLogado),
		};
	},

	methods: {
	
	},

	async created() {
		
	},

	async mounted() {
		
	},

	template: /*html*/ `
        <div class="h-100 w-100">
            <navbar></navbar>
            <div class="d-flex flex-nowrap">
				<main class="bg-main w-100 h-100">
                    <router-view></router-view>
                </main>
            </div>
        </div>
    `,
};

export { Root };
