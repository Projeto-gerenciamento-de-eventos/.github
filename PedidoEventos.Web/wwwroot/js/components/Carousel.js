const Carousel = {

	template: /*html*/ `
    <div id="carouselExampleDark" class="carousel carousel-dark slide">
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>
  <div class="carousel-inner">
    <div class="carousel-item  active" data-bs-interval="2000">
      <div class="d-flex justify-content-center ">
        <img
          src="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain"
          class="d-block object-fit-cover"
          style="height: 300px;"
          alt="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain">
      </div>
      <div class="carousel-caption d-none d-md-block text-white">
          <h5>Second slide label</h5>
          <p>Some representative placeholder content for the second slide.</p>
      </div>
    </div>
    <div class="carousel-item " data-bs-interval="2000">
      <div class="d-flex justify-content-center ">
        <img
          src="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain"
          class="d-block object-fit-cover"
          style="height: 300px;"
          alt="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain">
      </div>
      <div class="carousel-caption d-none d-md-block text-white">
          <h5>Second slide label</h5>
          <p>Some representative placeholder content for the second slide.</p>
      </div>
    </div>
    <div class="carousel-item " data-bs-interval="2000">
      <div class="d-flex justify-content-center ">
        <img
          src="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain"
          class="d-block object-fit-cover"
          style="height: 300px;"
          alt="https://th.bing.com/th/id/OIP.FVNjlHidrI6zkYeZWi-oCgHaE7?rs=1&pid=ImgDetMain">
      </div>
      <div class="carousel-caption d-none d-md-block text-white">
          <h5>Second slide label</h5>
          <p>Some representative placeholder content for the second slide.</p>
      </div>
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
`,
};

export { Carousel };
