import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedDeviceCreateComponent } from './components/device/deviceCreateForm';
import { WrappedDeviceDetailComponent } from './components/device/deviceDetailForm';
import { WrappedDeviceEditComponent } from './components/device/deviceEditForm';
import { WrappedDeviceSearchComponent } from './components/device/deviceSearchForm';
import { WrappedDeviceActionCreateComponent } from './components/deviceAction/deviceActionCreateForm';
import { WrappedDeviceActionDetailComponent } from './components/deviceAction/deviceActionDetailForm';
import { WrappedDeviceActionEditComponent } from './components/deviceAction/deviceActionEditForm';
import { WrappedDeviceActionSearchComponent } from './components/deviceAction/deviceActionSearchForm';

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  },
};

export const AppRouter: React.StatelessComponent<{}> = () => {
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
            path={ClientRoutes.Devices + '/create'}
            component={wrapperHeader(
              WrappedDeviceCreateComponent,
              'Device Create'
            )}
          />
          <Route
            path={ClientRoutes.Devices + '/edit/:id'}
            component={wrapperHeader(WrappedDeviceEditComponent, 'Device Edit')}
          />
          <Route
            path={ClientRoutes.Devices + '/:id'}
            component={wrapperHeader(
              WrappedDeviceDetailComponent,
              'Device Detail'
            )}
          />
          <Route
            path={ClientRoutes.Devices}
            component={wrapperHeader(
              WrappedDeviceSearchComponent,
              'Device Search'
            )}
          />
          <Route
            path={ClientRoutes.DeviceActions + '/create'}
            component={wrapperHeader(
              WrappedDeviceActionCreateComponent,
              'Device Actions Create'
            )}
          />
          <Route
            path={ClientRoutes.DeviceActions + '/edit/:id'}
            component={wrapperHeader(
              WrappedDeviceActionEditComponent,
              'Device Actions Edit'
            )}
          />
          <Route
            path={ClientRoutes.DeviceActions + '/:id'}
            component={wrapperHeader(
              WrappedDeviceActionDetailComponent,
              'Device Actions Detail'
            )}
          />
          <Route
            path={ClientRoutes.DeviceActions}
            component={wrapperHeader(
              WrappedDeviceActionSearchComponent,
              'Device Actions Search'
            )}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>0b3dc331e4e87f20251d6481d22c7a7a</Hash>
</Codenesium>*/