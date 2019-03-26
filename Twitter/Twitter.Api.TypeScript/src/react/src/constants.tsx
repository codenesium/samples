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
    <Hash>e00bb6be709da8fc10104d59bc998aae</Hash>
</Codenesium>*/