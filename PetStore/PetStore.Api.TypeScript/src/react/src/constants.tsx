export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedSubDirectory = process.env.REACT_APP_HOST_SUBDIRECTORY;
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
    <Hash>bfec9915ce001c39f12c1a963bb6d2e6</Hash>
</Codenesium>*/