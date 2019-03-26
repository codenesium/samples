export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedBaseUrl = location.protocol + '//' + location.host;
  static readonly HostedSubDirectory =
    process.env.REACT_APP_HOST_SUBDIRECTORY == '/'
      ? ''
      : '/' + process.env.REACT_APP_HOST_SUBDIRECTORY;
  static readonly HostedUrl =
    Constants.HostedBaseUrl + Constants.HostedSubDirectory;
}

export class AuthClientRoutes {
  static readonly Login = '/login';
  static readonly Logout = '/logout';
  static readonly Register = '/register';
  static readonly ResetPassword = '/resetpassword';
  static readonly ConfirmRegistration = '/confirmregistration';
  static readonly ConfirmPasswordReset = '/confirmpasswordreset';
  static readonly ChangePassword = '/changepassword';
}

export class AuthApiRoutes {
  static readonly Login = 'auth/login';
  static readonly Register = 'auth/register';
  static readonly ResetPassword = 'auth/resetpassword';
  static readonly ConfirmRegistration = 'auth/confirmregistration';
  static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';
  static readonly ChangePassword = 'auth/changepassword';
}

export class ClientRoutes {
  static readonly Addresses = '/addresses';
  static readonly Calls = '/calls';
  static readonly CallDispositions = '/calldispositions';
  static readonly CallPersons = '/callpersons';
  static readonly CallStatus = '/callstatus';
  static readonly CallTypes = '/calltypes';
  static readonly Notes = '/notes';
  static readonly Officers = '/officers';
  static readonly OfficerCapabilities = '/officercapabilities';
  static readonly People = '/people';
  static readonly PersonTypes = '/persontypes';
  static readonly Units = '/units';
  static readonly UnitDispositions = '/unitdispositions';
  static readonly Vehicles = '/vehicles';
  static readonly VehicleCapabilities = '/vehiclecapabilities';
}

export class ApiRoutes {
  static readonly Addresses = 'addresses';
  static readonly Calls = 'calls';
  static readonly CallDispositions = 'calldispositions';
  static readonly CallPersons = 'callpersons';
  static readonly CallStatus = 'callstatus';
  static readonly CallTypes = 'calltypes';
  static readonly Notes = 'notes';
  static readonly Officers = 'officers';
  static readonly OfficerCapabilities = 'officercapabilities';
  static readonly People = 'people';
  static readonly PersonTypes = 'persontypes';
  static readonly Units = 'units';
  static readonly UnitDispositions = 'unitdispositions';
  static readonly Vehicles = 'vehicles';
  static readonly VehicleCapabilities = 'vehiclecapabilities';
}


/*<Codenesium>
    <Hash>bc2e6f5e55a430397489af334b68c2f9</Hash>
</Codenesium>*/