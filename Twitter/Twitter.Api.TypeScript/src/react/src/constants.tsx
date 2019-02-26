export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
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
    <Hash>54984b9845f9afab1c335832df3c7292</Hash>
</Codenesium>*/