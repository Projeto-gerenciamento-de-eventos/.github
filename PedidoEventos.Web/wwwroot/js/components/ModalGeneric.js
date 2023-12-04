const ModalGeneric = {
	props: [
		"modalId",
		"icone",
		"styleIcone",
		"titulo",
		"tamanhoModal",
		"permitirFechar",
	],

	template: /*html*/ `
        <div class="modal fade" v-bind:id="modalId" aria-hidden="true" data-bs-backdrop="static">
            <div class="modal-dialog modal-dialog-scrollable" v-bind:class='tamanhoModal'>
                <div class="card" style="border-style: none">
                    <div class="modal-content" style="max-height: 90vh;"> 
                        <div class="modal-body p-0">
                            <div class="d-flex flex-inline justify-content-between align-items-center p-2 px-3">\
                                <div class="d-flex flex-inline justify-content-between align-items-center"> 
                                    <i class="me-3" v-bind:class="icone" v-bind:style="styleIcone"></i>
                                    <span class="text-5 color-text-4">{{titulo}}</span>
                                </div>
                                <div>
                                    <button
                                        v-if="permitirFechar"
                                        type="button"
                                        class="btn-close"
                                        data-bs-dismiss="modal"
                                        aria-label="Close">
                                    </button>
                                </div>
                            </div>
                            <div class="p-0 py-3 px-4">
                                <slot name= "conteudo"></slot>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    `,
};

export { ModalGeneric };
