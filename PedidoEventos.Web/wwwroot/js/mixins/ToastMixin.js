const ToastMixin = {

    methods: {
        mostrarToast(mensagem, tipo) {
            this.$toast.open({
                message: mensagem,
                type: tipo,
                duration: 200000,
                dismissible: true
            });
        }
    },
};

export { ToastMixin }
