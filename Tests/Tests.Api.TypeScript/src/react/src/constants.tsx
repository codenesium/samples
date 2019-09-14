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
    <Hash>ad9f4e22509e849ea274467a3052bce5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/