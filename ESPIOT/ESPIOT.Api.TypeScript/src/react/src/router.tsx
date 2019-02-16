import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import DeviceCreateComponent from './components/device/deviceCreateForm';
import DeviceDetailComponent from './components/device/deviceDetailForm';
import DeviceEditComponent from './components/device/deviceEditForm';
import DeviceSearchComponent from './components/device/deviceSearchForm';
import DeviceActionCreateComponent from './components/deviceAction/deviceActionCreateForm';
import DeviceActionDetailComponent from './components/deviceAction/deviceActionDetailForm';
import DeviceActionEditComponent from './components/deviceAction/deviceActionEditForm';
import DeviceActionSearchComponent from './components/deviceAction/deviceActionSearchForm';

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
            <Route path="/devices/create" component={DeviceCreateComponent} />
            <Route path="/devices/edit/:id" component={DeviceEditComponent} />
            <Route path="/devices/:id" component={DeviceDetailComponent} />
            <Route path="/devices" component={DeviceSearchComponent} />
            <Route
              path="/deviceactions/create"
              component={DeviceActionCreateComponent}
            />
            <Route
              path="/deviceactions/edit/:id"
              component={DeviceActionEditComponent}
            />
            <Route
              path="/deviceactions/:id"
              component={DeviceActionDetailComponent}
            />
            <Route
              path="/deviceactions"
              component={DeviceActionSearchComponent}
            />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>421222d6d0f22b08d817dc7db947d089</Hash>
</Codenesium>*/