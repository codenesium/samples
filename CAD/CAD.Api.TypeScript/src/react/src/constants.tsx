export class Constants {
  static readonly HostedBaseUrl =
    window.location.protocol + '//' + window.location.host;
  static readonly HostedSubDirectory =
    process.env.REACT_APP_HOST_SUBDIRECTORY === '/'
      ? ''
      : '/' + process.env.REACT_APP_HOST_SUBDIRECTORY;
  static readonly HostedUrl =
    Constants.HostedBaseUrl + Constants.HostedSubDirectory;
  static readonly BaseEndpoint =
    process.env.REACT_APP_API_URL == ''
      ? Constants.HostedUrl
      : process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'health';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class AuthClientRoutes {
  static readonly Login = '/login';
  static readonly Logout = '/logout';
  static readonly Register = '/register';
  static readonly ConfirmRegistration = '/confirmregistration';
  static readonly ResetPassword = '/resetpassword';
  static readonly ConfirmPasswordReset = '/confirmpasswordreset';
  static readonly ChangePassword = '/changepassword';
  static readonly ChangeEmail = '/changeemail';
  static readonly ConfirmChangeEmail = '/confirmchangeemail';
}

export class AuthApiRoutes {
  static readonly Login = 'auth/login';
  static readonly Register = 'auth/register';
  static readonly ConfirmRegistration = 'auth/confirmregistration';
  static readonly ResetPassword = 'auth/resetpassword';
  static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';
  static readonly ChangePassword = 'auth/changepassword';
  static readonly ChangeEmail = 'auth/changeemail';
  static readonly ConfirmChangeEmail = 'auth/confirmchangeemail';
}

export class ClientRoutes {
  static readonly Addresses = '/addresses';
  static readonly Calls = '/calls';
  static readonly CallAssignments = '/callassignments';
  static readonly CallDispositions = '/calldispositions';
  static readonly CallPersons = '/callpersons';
  static readonly CallStatus = '/callstatus';
  static readonly CallTypes = '/calltypes';
  static readonly Notes = '/notes';
  static readonly OffCapabilities = '/offcapabilities';
  static readonly Officers = '/officers';
  static readonly OfficerCapabilities = '/officercapabilities';
  static readonly People = '/people';
  static readonly PersonTypes = '/persontypes';
  static readonly Units = '/units';
  static readonly UnitDispositions = '/unitdispositions';
  static readonly UnitOfficers = '/unitofficers';
  static readonly VehCapabilities = '/vehcapabilities';
  static readonly Vehicles = '/vehicles';
  static readonly VehicleCapabilities = '/vehiclecapabilities';
  static readonly VehicleOfficers = '/vehicleofficers';
}

export class ApiRoutes {
  static readonly Addresses = 'addresses';
  static readonly Calls = 'calls';
  static readonly CallAssignments = 'callassignments';
  static readonly CallDispositions = 'calldispositions';
  static readonly CallPersons = 'callpersons';
  static readonly CallStatus = 'callstatus';
  static readonly CallTypes = 'calltypes';
  static readonly Notes = 'notes';
  static readonly OffCapabilities = 'offcapabilities';
  static readonly Officers = 'officers';
  static readonly OfficerCapabilities = 'officercapabilities';
  static readonly People = 'people';
  static readonly PersonTypes = 'persontypes';
  static readonly Units = 'units';
  static readonly UnitDispositions = 'unitdispositions';
  static readonly UnitOfficers = 'unitofficers';
  static readonly VehCapabilities = 'vehcapabilities';
  static readonly Vehicles = 'vehicles';
  static readonly VehicleCapabilities = 'vehiclecapabilities';
  static readonly VehicleOfficers = 'vehicleofficers';
}


/*<Codenesium>
    <Hash>d4f8cc208c9a10ac8062840a910740d4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/