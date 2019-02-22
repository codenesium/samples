import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedDirectTweetCreateComponent } from './components/directTweet/directTweetCreateForm';
import { WrappedDirectTweetDetailComponent } from './components/directTweet/directTweetDetailForm';
import { WrappedDirectTweetEditComponent } from './components/directTweet/directTweetEditForm';
import { WrappedDirectTweetSearchComponent } from './components/directTweet/directTweetSearchForm';
import { WrappedFollowerCreateComponent } from './components/follower/followerCreateForm';
import { WrappedFollowerDetailComponent } from './components/follower/followerDetailForm';
import { WrappedFollowerEditComponent } from './components/follower/followerEditForm';
import { WrappedFollowerSearchComponent } from './components/follower/followerSearchForm';
import { WrappedFollowingCreateComponent } from './components/following/followingCreateForm';
import { WrappedFollowingDetailComponent } from './components/following/followingDetailForm';
import { WrappedFollowingEditComponent } from './components/following/followingEditForm';
import { WrappedFollowingSearchComponent } from './components/following/followingSearchForm';
import { WrappedLocationCreateComponent } from './components/location/locationCreateForm';
import { WrappedLocationDetailComponent } from './components/location/locationDetailForm';
import { WrappedLocationEditComponent } from './components/location/locationEditForm';
import { WrappedLocationSearchComponent } from './components/location/locationSearchForm';
import { WrappedMessageCreateComponent } from './components/message/messageCreateForm';
import { WrappedMessageDetailComponent } from './components/message/messageDetailForm';
import { WrappedMessageEditComponent } from './components/message/messageEditForm';
import { WrappedMessageSearchComponent } from './components/message/messageSearchForm';
import { WrappedMessengerCreateComponent } from './components/messenger/messengerCreateForm';
import { WrappedMessengerDetailComponent } from './components/messenger/messengerDetailForm';
import { WrappedMessengerEditComponent } from './components/messenger/messengerEditForm';
import { WrappedMessengerSearchComponent } from './components/messenger/messengerSearchForm';
import { WrappedQuoteTweetCreateComponent } from './components/quoteTweet/quoteTweetCreateForm';
import { WrappedQuoteTweetDetailComponent } from './components/quoteTweet/quoteTweetDetailForm';
import { WrappedQuoteTweetEditComponent } from './components/quoteTweet/quoteTweetEditForm';
import { WrappedQuoteTweetSearchComponent } from './components/quoteTweet/quoteTweetSearchForm';
import { WrappedReplyCreateComponent } from './components/reply/replyCreateForm';
import { WrappedReplyDetailComponent } from './components/reply/replyDetailForm';
import { WrappedReplyEditComponent } from './components/reply/replyEditForm';
import { WrappedReplySearchComponent } from './components/reply/replySearchForm';
import { WrappedRetweetCreateComponent } from './components/retweet/retweetCreateForm';
import { WrappedRetweetDetailComponent } from './components/retweet/retweetDetailForm';
import { WrappedRetweetEditComponent } from './components/retweet/retweetEditForm';
import { WrappedRetweetSearchComponent } from './components/retweet/retweetSearchForm';
import { WrappedTweetCreateComponent } from './components/tweet/tweetCreateForm';
import { WrappedTweetDetailComponent } from './components/tweet/tweetDetailForm';
import { WrappedTweetEditComponent } from './components/tweet/tweetEditForm';
import { WrappedTweetSearchComponent } from './components/tweet/tweetSearchForm';
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';

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
        <SecureRoute
          path="/protected"
          component={() => '<div>secure route</div>'}
        />
        <Switch>
          <Route
            exact
            path="/"
            component={wrapperHeader(Dashboard, 'Dashboard')}
          />
          <Route
            path={ClientRoutes.DirectTweets + '/create'}
            component={wrapperHeader(
              WrappedDirectTweetCreateComponent,
              'DirectTweet Create'
            )}
          />
          <Route
            path={ClientRoutes.DirectTweets + '/edit/:id'}
            component={wrapperHeader(
              WrappedDirectTweetEditComponent,
              'DirectTweet Edit'
            )}
          />
          <Route
            path={ClientRoutes.DirectTweets + '/:id'}
            component={wrapperHeader(
              WrappedDirectTweetDetailComponent,
              'DirectTweet Detail'
            )}
          />
          <Route
            path={ClientRoutes.DirectTweets}
            component={wrapperHeader(
              WrappedDirectTweetSearchComponent,
              'DirectTweet Search'
            )}
          />
          <Route
            path={ClientRoutes.Followers + '/create'}
            component={wrapperHeader(
              WrappedFollowerCreateComponent,
              'Follower Create'
            )}
          />
          <Route
            path={ClientRoutes.Followers + '/edit/:id'}
            component={wrapperHeader(
              WrappedFollowerEditComponent,
              'Follower Edit'
            )}
          />
          <Route
            path={ClientRoutes.Followers + '/:id'}
            component={wrapperHeader(
              WrappedFollowerDetailComponent,
              'Follower Detail'
            )}
          />
          <Route
            path={ClientRoutes.Followers}
            component={wrapperHeader(
              WrappedFollowerSearchComponent,
              'Follower Search'
            )}
          />
          <Route
            path={ClientRoutes.Followings + '/create'}
            component={wrapperHeader(
              WrappedFollowingCreateComponent,
              'Following Create'
            )}
          />
          <Route
            path={ClientRoutes.Followings + '/edit/:id'}
            component={wrapperHeader(
              WrappedFollowingEditComponent,
              'Following Edit'
            )}
          />
          <Route
            path={ClientRoutes.Followings + '/:id'}
            component={wrapperHeader(
              WrappedFollowingDetailComponent,
              'Following Detail'
            )}
          />
          <Route
            path={ClientRoutes.Followings}
            component={wrapperHeader(
              WrappedFollowingSearchComponent,
              'Following Search'
            )}
          />
          <Route
            path={ClientRoutes.Locations + '/create'}
            component={wrapperHeader(
              WrappedLocationCreateComponent,
              'Location Create'
            )}
          />
          <Route
            path={ClientRoutes.Locations + '/edit/:id'}
            component={wrapperHeader(
              WrappedLocationEditComponent,
              'Location Edit'
            )}
          />
          <Route
            path={ClientRoutes.Locations + '/:id'}
            component={wrapperHeader(
              WrappedLocationDetailComponent,
              'Location Detail'
            )}
          />
          <Route
            path={ClientRoutes.Locations}
            component={wrapperHeader(
              WrappedLocationSearchComponent,
              'Location Search'
            )}
          />
          <Route
            path={ClientRoutes.Messages + '/create'}
            component={wrapperHeader(
              WrappedMessageCreateComponent,
              'Message Create'
            )}
          />
          <Route
            path={ClientRoutes.Messages + '/edit/:id'}
            component={wrapperHeader(
              WrappedMessageEditComponent,
              'Message Edit'
            )}
          />
          <Route
            path={ClientRoutes.Messages + '/:id'}
            component={wrapperHeader(
              WrappedMessageDetailComponent,
              'Message Detail'
            )}
          />
          <Route
            path={ClientRoutes.Messages}
            component={wrapperHeader(
              WrappedMessageSearchComponent,
              'Message Search'
            )}
          />
          <Route
            path={ClientRoutes.Messengers + '/create'}
            component={wrapperHeader(
              WrappedMessengerCreateComponent,
              'Messenger Create'
            )}
          />
          <Route
            path={ClientRoutes.Messengers + '/edit/:id'}
            component={wrapperHeader(
              WrappedMessengerEditComponent,
              'Messenger Edit'
            )}
          />
          <Route
            path={ClientRoutes.Messengers + '/:id'}
            component={wrapperHeader(
              WrappedMessengerDetailComponent,
              'Messenger Detail'
            )}
          />
          <Route
            path={ClientRoutes.Messengers}
            component={wrapperHeader(
              WrappedMessengerSearchComponent,
              'Messenger Search'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets + '/create'}
            component={wrapperHeader(
              WrappedQuoteTweetCreateComponent,
              'QuoteTweet Create'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets + '/edit/:id'}
            component={wrapperHeader(
              WrappedQuoteTweetEditComponent,
              'QuoteTweet Edit'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets + '/:id'}
            component={wrapperHeader(
              WrappedQuoteTweetDetailComponent,
              'QuoteTweet Detail'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets}
            component={wrapperHeader(
              WrappedQuoteTweetSearchComponent,
              'QuoteTweet Search'
            )}
          />
          <Route
            path={ClientRoutes.Replies + '/create'}
            component={wrapperHeader(
              WrappedReplyCreateComponent,
              'Reply Create'
            )}
          />
          <Route
            path={ClientRoutes.Replies + '/edit/:id'}
            component={wrapperHeader(WrappedReplyEditComponent, 'Reply Edit')}
          />
          <Route
            path={ClientRoutes.Replies + '/:id'}
            component={wrapperHeader(
              WrappedReplyDetailComponent,
              'Reply Detail'
            )}
          />
          <Route
            path={ClientRoutes.Replies}
            component={wrapperHeader(
              WrappedReplySearchComponent,
              'Reply Search'
            )}
          />
          <Route
            path={ClientRoutes.Retweets + '/create'}
            component={wrapperHeader(
              WrappedRetweetCreateComponent,
              'Retweet Create'
            )}
          />
          <Route
            path={ClientRoutes.Retweets + '/edit/:id'}
            component={wrapperHeader(
              WrappedRetweetEditComponent,
              'Retweet Edit'
            )}
          />
          <Route
            path={ClientRoutes.Retweets + '/:id'}
            component={wrapperHeader(
              WrappedRetweetDetailComponent,
              'Retweet Detail'
            )}
          />
          <Route
            path={ClientRoutes.Retweets}
            component={wrapperHeader(
              WrappedRetweetSearchComponent,
              'Retweet Search'
            )}
          />
          <Route
            path={ClientRoutes.Tweets + '/create'}
            component={wrapperHeader(
              WrappedTweetCreateComponent,
              'Tweet Create'
            )}
          />
          <Route
            path={ClientRoutes.Tweets + '/edit/:id'}
            component={wrapperHeader(WrappedTweetEditComponent, 'Tweet Edit')}
          />
          <Route
            path={ClientRoutes.Tweets + '/:id'}
            component={wrapperHeader(
              WrappedTweetDetailComponent,
              'Tweet Detail'
            )}
          />
          <Route
            path={ClientRoutes.Tweets}
            component={wrapperHeader(
              WrappedTweetSearchComponent,
              'Tweet Search'
            )}
          />
          <Route
            path={ClientRoutes.Users + '/create'}
            component={wrapperHeader(WrappedUserCreateComponent, 'User Create')}
          />
          <Route
            path={ClientRoutes.Users + '/edit/:id'}
            component={wrapperHeader(WrappedUserEditComponent, 'User Edit')}
          />
          <Route
            path={ClientRoutes.Users + '/:id'}
            component={wrapperHeader(WrappedUserDetailComponent, 'User Detail')}
          />
          <Route
            path={ClientRoutes.Users}
            component={wrapperHeader(WrappedUserSearchComponent, 'User Search')}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>1b0b61cb615b22abe03fe2e4daf42f31</Hash>
</Codenesium>*/