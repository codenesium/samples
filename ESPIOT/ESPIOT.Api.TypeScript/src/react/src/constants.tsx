export class Constants {
   static readonly BaseEndpoint = "http://www.codenesium.com:8080/user7303b0f5161f4149bf2959a488d359feESPIOT";
   // static readonly BaseEndpoint = 'http://www.codenesium.com:8080/user7303b0f5161f4149bf2959a488d359feESPIOT';
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
    <Hash>fadf9692c4f5c2ecbeac8aa59a0d373e</Hash>
</Codenesium>*/