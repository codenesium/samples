import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedVideoCreateComponent } from './components/video/videoCreateForm';
import { WrappedVideoDetailComponent } from './components/video/videoDetailForm';
import { WrappedVideoEditComponent } from './components/video/videoEditForm';
import { WrappedVideoSearchComponent } from './components/video/videoSearchForm';
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';
import { WrappedSubscriptionCreateComponent } from './components/subscription/subscriptionCreateForm';
import { WrappedSubscriptionDetailComponent } from './components/subscription/subscriptionDetailForm';
import { WrappedSubscriptionEditComponent } from './components/subscription/subscriptionEditForm';
import { WrappedSubscriptionSearchComponent } from './components/subscription/subscriptionSearchForm';

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
            path={ClientRoutes.Videos + '/create'}
            component={wrapperHeader(
              WrappedVideoCreateComponent,
              'Video Create'
            )}
          />
          <Route
            path={ClientRoutes.Videos + '/edit/:id'}
            component={wrapperHeader(WrappedVideoEditComponent, 'Video Edit')}
          />
          <Route
            path={ClientRoutes.Videos + '/:id'}
            component={wrapperHeader(
              WrappedVideoDetailComponent,
              'Video Detail'
            )}
          />
          <Route
            path={ClientRoutes.Videos}
            component={wrapperHeader(
              WrappedVideoSearchComponent,
              'Video Search'
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
          <Route
            path={ClientRoutes.Subscriptions + '/create'}
            component={wrapperHeader(
              WrappedSubscriptionCreateComponent,
              'Subscription Create'
            )}
          />
          <Route
            path={ClientRoutes.Subscriptions + '/edit/:id'}
            component={wrapperHeader(
              WrappedSubscriptionEditComponent,
              'Subscription Edit'
            )}
          />
          <Route
            path={ClientRoutes.Subscriptions + '/:id'}
            component={wrapperHeader(
              WrappedSubscriptionDetailComponent,
              'Subscription Detail'
            )}
          />
          <Route
            path={ClientRoutes.Subscriptions}
            component={wrapperHeader(
              WrappedSubscriptionSearchComponent,
              'Subscription Search'
            )}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>debbdf832444438b50452a68b199db6f</Hash>
</Codenesium>*/