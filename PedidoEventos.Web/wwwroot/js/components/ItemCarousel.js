const ItemCarousel = {
    data() {
        return {};
    },

    methods: {
        acionarCarousel: function () {
            var multipleCardCarousel = document.querySelector(
                "#carouselExampleControls"
            );

            if (window.matchMedia("(min-width: 768px)").matches) {
                var carousel = new bootstrap.Carousel(multipleCardCarousel, {
                    interval: false,
                    wrap: false,
                });

                var carouselWidth =
                    document.querySelector(".carousel-inner").scrollWidth;
                var cardWidth =
                    document.querySelector(".carousel-item").offsetWidth;
                var scrollPosition = 0;

                document
                    .querySelector(
                        "#carouselExampleControls .carousel-control-next"
                    )
                    .addEventListener("click", function () {
                        if (scrollPosition < carouselWidth - cardWidth * 4) {
                            scrollPosition += cardWidth;
                            document
                                .querySelector(
                                    "#carouselExampleControls .carousel-inner"
                                )
                                .scrollTo({
                                    left: scrollPosition,
                                    behavior: "smooth", // Adiciona um comportamento suave à animação
                                    duration: 1000, // Ajuste o valor aqui para a duração desejada (em milissegundos)
                                });
                        }
                    });

                document
                    .querySelector(
                        "#carouselExampleControls .carousel-control-prev"
                    )
                    .addEventListener("click", function () {
                        if (scrollPosition > 0) {
                            scrollPosition -= cardWidth;
                            document
                                .querySelector(
                                    "#carouselExampleControls .carousel-inner"
                                )
                                .scrollTo({
                                    left: scrollPosition,
                                    behavior: "smooth", // Adiciona um comportamento suave à animação
                                    duration: 1000, // Ajuste o valor aqui para a duração desejada (em milissegundos)
                                });
                        }
                    });
            } else {
                multipleCardCarousel.classList.add("slide");
            }
        },
    },

    mounted() {
        this.acionarCarousel();
    },

    template: /*html*/ `
<div id='item-carousel'>
    <div id="carouselExampleControls" class="carousel">
    <div class="carousel-inner">
        <div class="carousel-item active">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 1</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 2</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 3</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 4</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 5</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 6</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 7</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 8</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <div class="carousel-item">
            <div class="card">
                <div class="img-wrapper"><img src="..." class="d-block w-100" alt="..."> </div>
                <div class="card-body">
                    <h5 class="card-title">Card title 9</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                        card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </button>
</div>
</div>
`,
};

export { ItemCarousel };
