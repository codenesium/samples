export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedBaseUrl =
    window.location.protocol + '//' + window.location.host;
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
  static readonly ColumnSameAsFKTables = '/columnsameasfktables';
  static readonly IncludedColumnTests = '/includedcolumntests';
  static readonly People = '/people';
  static readonly RowVersionChecks = '/rowversionchecks';
  static readonly SelfReferences = '/selfreferences';
  static readonly Tables = '/tables';
  static readonly TestAllFieldTypes = '/testallfieldtypes';
  static readonly TestAllFieldTypesNullables = '/testallfieldtypesnullables';
  static readonly TimestampChecks = '/timestampchecks';
  static readonly VPersons = '/vpersons';
}

export class ApiRoutes {
  static readonly ColumnSameAsFKTables = 'columnsameasfktables';
  static readonly IncludedColumnTests = 'includedcolumntests';
  static readonly People = 'people';
  static readonly RowVersionChecks = 'rowversionchecks';
  static readonly SelfReferences = 'selfreferences';
  static readonly Tables = 'tables';
  static readonly TestAllFieldTypes = 'testallfieldtypes';
  static readonly TestAllFieldTypesNullables = 'testallfieldtypesnullables';
  static readonly TimestampChecks = 'timestampchecks';
  static readonly VPersons = 'vpersons';
}


/*<Codenesium>
    <Hash>6151c60ec111b24292e33f81d4ab30e3</Hash>
</Codenesium>*/