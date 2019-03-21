export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
   static readonly HostedSubDirectory = process.env.REACT_APP_HOST_SUBDIRECTORY;
}

export class AuthClientRoutes
{
    static readonly Login = '/auth/login';
    static readonly Register = '/auth/register';	
    static readonly ResetPassword = '/auth/resetpassword';	
    static readonly ConfirmRegistration = '/auth/confirmregistration';	
    static readonly ConfirmPasswordReset = '/auth/confirmpasswordreset';	
}

export class AuthApiRoutes
{
    static readonly Login = 'auth/login';	
    static readonly Register = 'auth/register';	
    static readonly ResetPassword = 'auth/resetpassword';
    static readonly ConfirmRegistration = 'auth/confirmregistration';
    static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';	
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
    <Hash>131d76004299bc6373e9bbc4fd3a6b46</Hash>
</Codenesium>*/