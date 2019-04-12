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
  static readonly DirectTweets = '/directtweets';
  static readonly Followers = '/followers';
  static readonly Followings = '/followings';
  static readonly Locations = '/locations';
  static readonly Messages = '/messages';
  static readonly Messengers = '/messengers';
  static readonly QuoteTweets = '/quotetweets';
  static readonly Replies = '/replies';
  static readonly Retweets = '/retweets';
  static readonly Tweets = '/tweets';
  static readonly Users = '/users';
}

export class ApiRoutes {
  static readonly DirectTweets = 'directtweets';
  static readonly Followers = 'followers';
  static readonly Followings = 'followings';
  static readonly Locations = 'locations';
  static readonly Messages = 'messages';
  static readonly Messengers = 'messengers';
  static readonly QuoteTweets = 'quotetweets';
  static readonly Replies = 'replies';
  static readonly Retweets = 'retweets';
  static readonly Tweets = 'tweets';
  static readonly Users = 'users';
}


/*<Codenesium>
    <Hash>09615c29c11f85892330ebfced5519a2</Hash>
</Codenesium>*/