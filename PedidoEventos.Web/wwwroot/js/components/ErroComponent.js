const ErroComponent = {
    props: ['titulo','texto'],

    template: /*html*/`
                    <div class="d-flex flex-column flex-wrap justify-content-center aling-items-center pt-2 h-90">
                        <div class="d-flex flex-column flex-wrap justify-content-center align-items-center">
                            <img class=" " src="../../imgs/img-precatito-duvida.png" style="width: auto;height: auto"></img>
                        </div>
                        <span class="title-3 text-center color-text-2 py-2">{{this.titulo}}</span>
                        <span class="title-4 text-center color-text-4 py-2">{{this.texto}}</span>
                    </div>
                    `
};

export { ErroComponent }
