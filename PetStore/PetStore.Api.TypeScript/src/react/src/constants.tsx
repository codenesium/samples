export class Constants {
  static readonly BaseEndpoint = 'https://codenesium.ngrok.io/user7303b0f5161f4149bf2959a488d359fePetStore/';
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
    <Hash>e48a2734b98e64255b997c6d6cdff6ec</Hash>
</Codenesium>*/