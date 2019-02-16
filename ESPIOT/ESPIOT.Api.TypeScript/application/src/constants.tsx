export class Constants {
  static readonly BaseEndpoint = 'http://localhost:8000/';
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
  static readonly Devices = '/devices';
  static readonly DeviceActions = '/deviceactions';
}

export class ApiRoutes {
  static readonly Devices = 'devices';
  static readonly DeviceActions = 'deviceactions';
}


/*<Codenesium>
    <Hash>469f332a78d2ca9496d51ae93e8e885f</Hash>
</Codenesium>*/