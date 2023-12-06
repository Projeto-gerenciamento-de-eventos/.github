const Navbar = {

    inject: [],

    template: /*html*/`
      <nav class="navbar navbar-expand-lg bg-dark border-bottom border-body p-0">
        <div class="container-fluid">
        <i class="bi bi-globe-americas pe-2" style="font-size: 2rem; color: white;"></i>
        <a class="d-flex flex-inline navbar-brand link-secondary" href="#"><h2>G</h2>L Events</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active link-secondary" aria-current="page" href="#">Home</a>
        </li>
      </ul>
      <form class="d-flex" role="search">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-warning" type="submit">Search</button>
      </form>
    </div>
  </div>
</nav>
    `
};

export { Navbar }
