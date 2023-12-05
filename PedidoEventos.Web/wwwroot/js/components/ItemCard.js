const ItemCard = {
    data() {
        return {};
    },

    methods: {},

    mounted() {},

    template: /*html*/ `
    <div class="row">
      <div class="col-4">
        <img
          src="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain"
          class="d-block object-fit-cover"
          alt="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain">
      </div>
      <div class="col-8">
        <div class="container text-center">
          <div class="row">
            <div class="col-12">
              descricao
            </div>
          </div>
          <div class="row">
            <div class="col-8">
              locacalizacao
            </div>
            <div class="col-4">
              resgristo
            </div>
          </div>
        </div>
      </div>
    </div>
`,
};

export { ItemCard };
