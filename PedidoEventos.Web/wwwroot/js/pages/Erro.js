const Erro = {
    data() {
        return {
            mensagemErro: {
                titulo: '',
                texto: '',
            },

            codigoErro: null,
        }
    },

    methods: {
       carregarMensagemErro() {
            if(this.codigoErro == 1) {
                this.mensagemErro.titulo = "Telefonia desconectada";
                this.mensagemErro.texto = "Erro ao conectar com a telefonia.";
            }
            else if(this.codigoErro == 2) {
                this.mensagemErro.titulo = "Voip desconectado";
                this.mensagemErro.texto = "Erro ao conectar com o voip.";
            }
            
            this.mensagemErro.texto += "\n Entre em contato com a equipe de suporte.";

        }
    },

    created() {
        this.codigoErro = this.$route.params.codigoErro;
        this.carregarMensagemErro();
    },

	template: /*html*/ `
    <div class="row p-2 m-0">
        <div class="col-md-12 d-flex justify-content-center align-items-center">
            <erro-precatito v-bind="mensagemErro"></erro-precatito>
        </div>
    </div>
    `,
};

export { Erro };
