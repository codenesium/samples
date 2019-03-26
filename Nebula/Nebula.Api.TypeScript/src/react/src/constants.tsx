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
  static readonly Chains = '/chains';
  static readonly ChainStatuses = '/chainstatuses';
  static readonly Clasps = '/clasps';
  static readonly Links = '/links';
  static readonly LinkLogs = '/linklogs';
  static readonly LinkStatuses = '/linkstatuses';
  static readonly Machines = '/machines';
  static readonly Organizations = '/organizations';
  static readonly Teams = '/teams';
}

export class ApiRoutes {
  static readonly Chains = 'chains';
  static readonly ChainStatuses = 'chainstatuses';
  static readonly Clasps = 'clasps';
  static readonly Links = 'links';
  static readonly LinkLogs = 'linklogs';
  static readonly LinkStatuses = 'linkstatuses';
  static readonly Machines = 'machines';
  static readonly Organizations = 'organizations';
  static readonly Teams = 'teams';
}


/*<Codenesium>
    <Hash>170664be6ce0828430b34ee5368bcec3</Hash>
</Codenesium>*/