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
  static readonly Chains = '/chains';
  static readonly ChainStatus = '/chainstatus';
  static readonly Clasps = '/clasps';
  static readonly Links = '/links';
  static readonly LinkLogs = '/linklogs';
  static readonly LinkStatus = '/linkstatus';
  static readonly Machines = '/machines';
  static readonly MachineRefTeams = '/machinerefteams';
  static readonly Organizations = '/organizations';
  static readonly Teams = '/teams';
  static readonly VersionInfoes = '/versioninfoes';
}

export class ApiRoutes {
  static readonly Chains = 'chains';
  static readonly ChainStatus = 'chainstatus';
  static readonly Clasps = 'clasps';
  static readonly Links = 'links';
  static readonly LinkLogs = 'linklogs';
  static readonly LinkStatus = 'linkstatus';
  static readonly Machines = 'machines';
  static readonly MachineRefTeams = 'machinerefteams';
  static readonly Organizations = 'organizations';
  static readonly Teams = 'teams';
  static readonly VersionInfoes = 'versioninfoes';
}


/*<Codenesium>
    <Hash>ef8157ed4d2745147c922da6002f5914</Hash>
</Codenesium>*/