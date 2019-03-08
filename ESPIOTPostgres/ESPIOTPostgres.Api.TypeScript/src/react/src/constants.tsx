export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
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
    <Hash>442fae53986dd7174b46b4cbab00132d</Hash>
</Codenesium>*/