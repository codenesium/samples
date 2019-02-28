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
    <Hash>efea0846ae337460185b0d9326e32759</Hash>
</Codenesium>*/