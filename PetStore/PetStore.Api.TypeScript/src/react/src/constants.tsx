export class Constants {
  static readonly BaseEndpoint = 'http://www.codenesium.com:8080/user7303b0f5161f4149bf2959a488d359fePetStore';
  // static readonly BaseEndpoint = 'http://www.codenesium.com:8080/user7303b0f5161f4149bf2959a488d359fePetStore';
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
  static readonly Breeds = '/breeds';
  static readonly PaymentTypes = '/paymenttypes';
  static readonly Pens = '/pens';
  static readonly Pets = '/pets';
  static readonly Sales = '/sales';
  static readonly Species = '/species';
}

export class ApiRoutes {
  static readonly Breeds = 'breeds';
  static readonly PaymentTypes = 'paymenttypes';
  static readonly Pens = 'pens';
  static readonly Pets = 'pets';
  static readonly Sales = 'sales';
  static readonly Species = 'species';
}


/*<Codenesium>
    <Hash>ae478f3c5e9453b20f62d83aa1dddfe2</Hash>
</Codenesium>*/