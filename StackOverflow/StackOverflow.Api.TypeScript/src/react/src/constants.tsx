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
  static readonly Badges = '/badges';
  static readonly Comments = '/comments';
  static readonly LinkTypes = '/linktypes';
  static readonly PostHistory = '/posthistory';
  static readonly PostHistoryTypes = '/posthistorytypes';
  static readonly PostLinks = '/postlinks';
  static readonly Posts = '/posts';
  static readonly PostTypes = '/posttypes';
  static readonly Tags = '/tags';
  static readonly Users = '/users';
  static readonly Votes = '/votes';
  static readonly VoteTypes = '/votetypes';
}

export class ApiRoutes {
  static readonly Badges = 'badges';
  static readonly Comments = 'comments';
  static readonly LinkTypes = 'linktypes';
  static readonly PostHistory = 'posthistory';
  static readonly PostHistoryTypes = 'posthistorytypes';
  static readonly PostLinks = 'postlinks';
  static readonly Posts = 'posts';
  static readonly PostTypes = 'posttypes';
  static readonly Tags = 'tags';
  static readonly Users = 'users';
  static readonly Votes = 'votes';
  static readonly VoteTypes = 'votetypes';
}


/*<Codenesium>
    <Hash>efc7dc8ca504ff24bd2c71bff895ba96</Hash>
</Codenesium>*/