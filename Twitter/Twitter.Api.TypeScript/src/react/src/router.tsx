import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import DirectTweetCreateComponent from './components/directTweet/directTweetCreateForm';
import DirectTweetDetailComponent from './components/directTweet/directTweetDetailForm';
import DirectTweetEditComponent from './components/directTweet/directTweetEditForm';
import DirectTweetSearchComponent from './components/directTweet/directTweetSearchForm';
import FollowerCreateComponent from './components/follower/followerCreateForm';
import FollowerDetailComponent from './components/follower/followerDetailForm';
import FollowerEditComponent from './components/follower/followerEditForm';
import FollowerSearchComponent from './components/follower/followerSearchForm';
import FollowingCreateComponent from './components/following/followingCreateForm';
import FollowingDetailComponent from './components/following/followingDetailForm';
import FollowingEditComponent from './components/following/followingEditForm';
import FollowingSearchComponent from './components/following/followingSearchForm';
import LocationCreateComponent from './components/location/locationCreateForm';
import LocationDetailComponent from './components/location/locationDetailForm';
import LocationEditComponent from './components/location/locationEditForm';
import LocationSearchComponent from './components/location/locationSearchForm';
import MessageCreateComponent from './components/message/messageCreateForm';
import MessageDetailComponent from './components/message/messageDetailForm';
import MessageEditComponent from './components/message/messageEditForm';
import MessageSearchComponent from './components/message/messageSearchForm';
import MessengerCreateComponent from './components/messenger/messengerCreateForm';
import MessengerDetailComponent from './components/messenger/messengerDetailForm';
import MessengerEditComponent from './components/messenger/messengerEditForm';
import MessengerSearchComponent from './components/messenger/messengerSearchForm';
import QuoteTweetCreateComponent from './components/quoteTweet/quoteTweetCreateForm';
import QuoteTweetDetailComponent from './components/quoteTweet/quoteTweetDetailForm';
import QuoteTweetEditComponent from './components/quoteTweet/quoteTweetEditForm';
import QuoteTweetSearchComponent from './components/quoteTweet/quoteTweetSearchForm';
import ReplyCreateComponent from './components/reply/replyCreateForm';
import ReplyDetailComponent from './components/reply/replyDetailForm';
import ReplyEditComponent from './components/reply/replyEditForm';
import ReplySearchComponent from './components/reply/replySearchForm';
import RetweetCreateComponent from './components/retweet/retweetCreateForm';
import RetweetDetailComponent from './components/retweet/retweetDetailForm';
import RetweetEditComponent from './components/retweet/retweetEditForm';
import RetweetSearchComponent from './components/retweet/retweetSearchForm';
import TweetCreateComponent from './components/tweet/tweetCreateForm';
import TweetDetailComponent from './components/tweet/tweetDetailForm';
import TweetEditComponent from './components/tweet/tweetEditForm';
import TweetSearchComponent from './components/tweet/tweetSearchForm';
import UserCreateComponent from './components/user/userCreateForm';
import UserDetailComponent from './components/user/userDetailForm';
import UserEditComponent from './components/user/userEditForm';
import UserSearchComponent from './components/user/userSearchForm';

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  },
};

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search);

  return (
    <BrowserRouter>
      <Security
        issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}
      >
        <div className="container-fluid">
          <Route component={App} />
          <SecureRoute
            path="/protected"
            component={() => '<div>secure route</div>'}
          />
          <Switch>
            <Route exact path="/" component={Dashboard} />
            <Route
              path="/directtweets/create"
              component={DirectTweetCreateComponent}
            />
            <Route
              path="/directtweets/edit/:id"
              component={DirectTweetEditComponent}
            />
            <Route
              path="/directtweets/:id"
              component={DirectTweetDetailComponent}
            />
            <Route
              path="/directtweets"
              component={DirectTweetSearchComponent}
            />
            <Route
              path="/followers/create"
              component={FollowerCreateComponent}
            />
            <Route
              path="/followers/edit/:id"
              component={FollowerEditComponent}
            />
            <Route path="/followers/:id" component={FollowerDetailComponent} />
            <Route path="/followers" component={FollowerSearchComponent} />
            <Route
              path="/followings/create"
              component={FollowingCreateComponent}
            />
            <Route
              path="/followings/edit/:id"
              component={FollowingEditComponent}
            />
            <Route
              path="/followings/:id"
              component={FollowingDetailComponent}
            />
            <Route path="/followings" component={FollowingSearchComponent} />
            <Route
              path="/locations/create"
              component={LocationCreateComponent}
            />
            <Route
              path="/locations/edit/:id"
              component={LocationEditComponent}
            />
            <Route path="/locations/:id" component={LocationDetailComponent} />
            <Route path="/locations" component={LocationSearchComponent} />
            <Route path="/messages/create" component={MessageCreateComponent} />
            <Route path="/messages/edit/:id" component={MessageEditComponent} />
            <Route path="/messages/:id" component={MessageDetailComponent} />
            <Route path="/messages" component={MessageSearchComponent} />
            <Route
              path="/messengers/create"
              component={MessengerCreateComponent}
            />
            <Route
              path="/messengers/edit/:id"
              component={MessengerEditComponent}
            />
            <Route
              path="/messengers/:id"
              component={MessengerDetailComponent}
            />
            <Route path="/messengers" component={MessengerSearchComponent} />
            <Route
              path="/quotetweets/create"
              component={QuoteTweetCreateComponent}
            />
            <Route
              path="/quotetweets/edit/:id"
              component={QuoteTweetEditComponent}
            />
            <Route
              path="/quotetweets/:id"
              component={QuoteTweetDetailComponent}
            />
            <Route path="/quotetweets" component={QuoteTweetSearchComponent} />
            <Route path="/replies/create" component={ReplyCreateComponent} />
            <Route path="/replies/edit/:id" component={ReplyEditComponent} />
            <Route path="/replies/:id" component={ReplyDetailComponent} />
            <Route path="/replies" component={ReplySearchComponent} />
            <Route path="/retweets/create" component={RetweetCreateComponent} />
            <Route path="/retweets/edit/:id" component={RetweetEditComponent} />
            <Route path="/retweets/:id" component={RetweetDetailComponent} />
            <Route path="/retweets" component={RetweetSearchComponent} />
            <Route path="/tweets/create" component={TweetCreateComponent} />
            <Route path="/tweets/edit/:id" component={TweetEditComponent} />
            <Route path="/tweets/:id" component={TweetDetailComponent} />
            <Route path="/tweets" component={TweetSearchComponent} />
            <Route path="/users/create" component={UserCreateComponent} />
            <Route path="/users/edit/:id" component={UserEditComponent} />
            <Route path="/users/:id" component={UserDetailComponent} />
            <Route path="/users" component={UserSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>78f17a390afdf252bbbe17d57fe8af2b</Hash>
</Codenesium>*/