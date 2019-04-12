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
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
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
  static readonly Badges = '/badges';
  static readonly Comments = '/comments';
  static readonly LinkTypes = '/linktypes';
  static readonly PostHistories = '/posthistories';
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
  static readonly PostHistories = 'posthistories';
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
    <Hash>719f50be9bf52631679e9dccf99f2dc4</Hash>
</Codenesium>*/