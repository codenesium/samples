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
              'DirectTweets Create'
            )}
          />
          <Route
            path={ClientRoutes.DirectTweets + '/edit/:id'}
            component={wrapperHeader(
              WrappedDirectTweetEditComponent,
              'DirectTweets Edit'
            )}
          />
          <Route
            path={ClientRoutes.DirectTweets + '/:id'}
            component={wrapperHeader(
              WrappedDirectTweetDetailComponent,
              'DirectTweets Detail'
            )}
          />
          <Route
            path={ClientRoutes.DirectTweets}
            component={wrapperHeader(
              WrappedDirectTweetSearchComponent,
              'DirectTweets Search'
            )}
          />
          <Route
            path={ClientRoutes.Followers + '/create'}
            component={wrapperHeader(
              WrappedFollowerCreateComponent,
              'Followers Create'
            )}
          />
          <Route
            path={ClientRoutes.Followers + '/edit/:id'}
            component={wrapperHeader(
              WrappedFollowerEditComponent,
              'Followers Edit'
            )}
          />
          <Route
            path={ClientRoutes.Followers + '/:id'}
            component={wrapperHeader(
              WrappedFollowerDetailComponent,
              'Followers Detail'
            )}
          />
          <Route
            path={ClientRoutes.Followers}
            component={wrapperHeader(
              WrappedFollowerSearchComponent,
              'Followers Search'
            )}
          />
          <Route
            path={ClientRoutes.Followings + '/create'}
            component={wrapperHeader(
              WrappedFollowingCreateComponent,
              'Followings Create'
            )}
          />
          <Route
            path={ClientRoutes.Followings + '/edit/:id'}
            component={wrapperHeader(
              WrappedFollowingEditComponent,
              'Followings Edit'
            )}
          />
          <Route
            path={ClientRoutes.Followings + '/:id'}
            component={wrapperHeader(
              WrappedFollowingDetailComponent,
              'Followings Detail'
            )}
          />
          <Route
            path={ClientRoutes.Followings}
            component={wrapperHeader(
              WrappedFollowingSearchComponent,
              'Followings Search'
            )}
          />
          <Route
            path={ClientRoutes.Locations + '/create'}
            component={wrapperHeader(
              WrappedLocationCreateComponent,
              'Locations Create'
            )}
          />
          <Route
            path={ClientRoutes.Locations + '/edit/:id'}
            component={wrapperHeader(
              WrappedLocationEditComponent,
              'Locations Edit'
            )}
          />
          <Route
            path={ClientRoutes.Locations + '/:id'}
            component={wrapperHeader(
              WrappedLocationDetailComponent,
              'Locations Detail'
            )}
          />
          <Route
            path={ClientRoutes.Locations}
            component={wrapperHeader(
              WrappedLocationSearchComponent,
              'Locations Search'
            )}
          />
          <Route
            path={ClientRoutes.Messages + '/create'}
            component={wrapperHeader(
              WrappedMessageCreateComponent,
              'Messages Create'
            )}
          />
          <Route
            path={ClientRoutes.Messages + '/edit/:id'}
            component={wrapperHeader(
              WrappedMessageEditComponent,
              'Messages Edit'
            )}
          />
          <Route
            path={ClientRoutes.Messages + '/:id'}
            component={wrapperHeader(
              WrappedMessageDetailComponent,
              'Messages Detail'
            )}
          />
          <Route
            path={ClientRoutes.Messages}
            component={wrapperHeader(
              WrappedMessageSearchComponent,
              'Messages Search'
            )}
          />
          <Route
            path={ClientRoutes.Messengers + '/create'}
            component={wrapperHeader(
              WrappedMessengerCreateComponent,
              'Messengers Create'
            )}
          />
          <Route
            path={ClientRoutes.Messengers + '/edit/:id'}
            component={wrapperHeader(
              WrappedMessengerEditComponent,
              'Messengers Edit'
            )}
          />
          <Route
            path={ClientRoutes.Messengers + '/:id'}
            component={wrapperHeader(
              WrappedMessengerDetailComponent,
              'Messengers Detail'
            )}
          />
          <Route
            path={ClientRoutes.Messengers}
            component={wrapperHeader(
              WrappedMessengerSearchComponent,
              'Messengers Search'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets + '/create'}
            component={wrapperHeader(
              WrappedQuoteTweetCreateComponent,
              'QuoteTweets Create'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets + '/edit/:id'}
            component={wrapperHeader(
              WrappedQuoteTweetEditComponent,
              'QuoteTweets Edit'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets + '/:id'}
            component={wrapperHeader(
              WrappedQuoteTweetDetailComponent,
              'QuoteTweets Detail'
            )}
          />
          <Route
            path={ClientRoutes.QuoteTweets}
            component={wrapperHeader(
              WrappedQuoteTweetSearchComponent,
              'QuoteTweets Search'
            )}
          />
          <Route
            path={ClientRoutes.Replies + '/create'}
            component={wrapperHeader(
              WrappedReplyCreateComponent,
              'Replies Create'
            )}
          />
          <Route
            path={ClientRoutes.Replies + '/edit/:id'}
            component={wrapperHeader(WrappedReplyEditComponent, 'Replies Edit')}
          />
          <Route
            path={ClientRoutes.Replies + '/:id'}
            component={wrapperHeader(
              WrappedReplyDetailComponent,
              'Replies Detail'
            )}
          />
          <Route
            path={ClientRoutes.Replies}
            component={wrapperHeader(
              WrappedReplySearchComponent,
              'Replies Search'
            )}
          />
          <Route
            path={ClientRoutes.Retweets + '/create'}
            component={wrapperHeader(
              WrappedRetweetCreateComponent,
              'Retweets Create'
            )}
          />
          <Route
            path={ClientRoutes.Retweets + '/edit/:id'}
            component={wrapperHeader(
              WrappedRetweetEditComponent,
              'Retweets Edit'
            )}
          />
          <Route
            path={ClientRoutes.Retweets + '/:id'}
            component={wrapperHeader(
              WrappedRetweetDetailComponent,
              'Retweets Detail'
            )}
          />
          <Route
            path={ClientRoutes.Retweets}
            component={wrapperHeader(
              WrappedRetweetSearchComponent,
              'Retweets Search'
            )}
          />
          <Route
            path={ClientRoutes.Tweets + '/create'}
            component={wrapperHeader(
              WrappedTweetCreateComponent,
              'Tweets Create'
            )}
          />
          <Route
            path={ClientRoutes.Tweets + '/edit/:id'}
            component={wrapperHeader(WrappedTweetEditComponent, 'Tweets Edit')}
          />
          <Route
            path={ClientRoutes.Tweets + '/:id'}
            component={wrapperHeader(
              WrappedTweetDetailComponent,
              'Tweets Detail'
            )}
          />
          <Route
            path={ClientRoutes.Tweets}
            component={wrapperHeader(
              WrappedTweetSearchComponent,
              'Tweets Search'
            )}
          />
          <Route
            path={ClientRoutes.Users + '/create'}
            component={wrapperHeader(
              WrappedUserCreateComponent,
              'Users Create'
            )}
          />
          <Route
            path={ClientRoutes.Users + '/edit/:id'}
            component={wrapperHeader(WrappedUserEditComponent, 'Users Edit')}
          />
          <Route
            path={ClientRoutes.Users + '/:id'}
            component={wrapperHeader(
              WrappedUserDetailComponent,
              'Users Detail'
            )}
          />
          <Route
            path={ClientRoutes.Users}
            component={wrapperHeader(
              WrappedUserSearchComponent,
              'Users Search'
            )}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>f471900e7b08f0f2b60c8adaf450a769</Hash>
</Codenesium>*/