import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import ChainCreateComponent from './components/chain/chainCreateForm';
import ChainDetailComponent from './components/chain/chainDetailForm';
import ChainEditComponent from './components/chain/chainEditForm';
import ChainSearchComponent from './components/chain/chainSearchForm';
import ChainStatusCreateComponent from './components/chainStatus/chainStatusCreateForm';
import ChainStatusDetailComponent from './components/chainStatus/chainStatusDetailForm';
import ChainStatusEditComponent from './components/chainStatus/chainStatusEditForm';
import ChainStatusSearchComponent from './components/chainStatus/chainStatusSearchForm';
import ClaspCreateComponent from './components/clasp/claspCreateForm';
import ClaspDetailComponent from './components/clasp/claspDetailForm';
import ClaspEditComponent from './components/clasp/claspEditForm';
import ClaspSearchComponent from './components/clasp/claspSearchForm';
import LinkCreateComponent from './components/link/linkCreateForm';
import LinkDetailComponent from './components/link/linkDetailForm';
import LinkEditComponent from './components/link/linkEditForm';
import LinkSearchComponent from './components/link/linkSearchForm';
import LinkLogCreateComponent from './components/linkLog/linkLogCreateForm';
import LinkLogDetailComponent from './components/linkLog/linkLogDetailForm';
import LinkLogEditComponent from './components/linkLog/linkLogEditForm';
import LinkLogSearchComponent from './components/linkLog/linkLogSearchForm';
import LinkStatusCreateComponent from './components/linkStatus/linkStatusCreateForm';
import LinkStatusDetailComponent from './components/linkStatus/linkStatusDetailForm';
import LinkStatusEditComponent from './components/linkStatus/linkStatusEditForm';
import LinkStatusSearchComponent from './components/linkStatus/linkStatusSearchForm';
import MachineCreateComponent from './components/machine/machineCreateForm';
import MachineDetailComponent from './components/machine/machineDetailForm';
import MachineEditComponent from './components/machine/machineEditForm';
import MachineSearchComponent from './components/machine/machineSearchForm';
import OrganizationCreateComponent from './components/organization/organizationCreateForm';
import OrganizationDetailComponent from './components/organization/organizationDetailForm';
import OrganizationEditComponent from './components/organization/organizationEditForm';
import OrganizationSearchComponent from './components/organization/organizationSearchForm';
import TeamCreateComponent from './components/team/teamCreateForm';
import TeamDetailComponent from './components/team/teamDetailForm';
import TeamEditComponent from './components/team/teamEditForm';
import TeamSearchComponent from './components/team/teamSearchForm';

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
            <Route path="/chains/create" component={ChainCreateComponent} />
            <Route path="/chains/edit/:id" component={ChainEditComponent} />
            <Route path="/chains/:id" component={ChainDetailComponent} />
            <Route path="/chains" component={ChainSearchComponent} />
            <Route
              path="/chainstatuses/create"
              component={ChainStatusCreateComponent}
            />
            <Route
              path="/chainstatuses/edit/:id"
              component={ChainStatusEditComponent}
            />
            <Route
              path="/chainstatuses/:id"
              component={ChainStatusDetailComponent}
            />
            <Route
              path="/chainstatuses"
              component={ChainStatusSearchComponent}
            />
            <Route path="/clasps/create" component={ClaspCreateComponent} />
            <Route path="/clasps/edit/:id" component={ClaspEditComponent} />
            <Route path="/clasps/:id" component={ClaspDetailComponent} />
            <Route path="/clasps" component={ClaspSearchComponent} />
            <Route path="/links/create" component={LinkCreateComponent} />
            <Route path="/links/edit/:id" component={LinkEditComponent} />
            <Route path="/links/:id" component={LinkDetailComponent} />
            <Route path="/links" component={LinkSearchComponent} />
            <Route path="/linklogs/create" component={LinkLogCreateComponent} />
            <Route path="/linklogs/edit/:id" component={LinkLogEditComponent} />
            <Route path="/linklogs/:id" component={LinkLogDetailComponent} />
            <Route path="/linklogs" component={LinkLogSearchComponent} />
            <Route
              path="/linkstatuses/create"
              component={LinkStatusCreateComponent}
            />
            <Route
              path="/linkstatuses/edit/:id"
              component={LinkStatusEditComponent}
            />
            <Route
              path="/linkstatuses/:id"
              component={LinkStatusDetailComponent}
            />
            <Route path="/linkstatuses" component={LinkStatusSearchComponent} />
            <Route path="/machines/create" component={MachineCreateComponent} />
            <Route path="/machines/edit/:id" component={MachineEditComponent} />
            <Route path="/machines/:id" component={MachineDetailComponent} />
            <Route path="/machines" component={MachineSearchComponent} />
            <Route
              path="/organizations/create"
              component={OrganizationCreateComponent}
            />
            <Route
              path="/organizations/edit/:id"
              component={OrganizationEditComponent}
            />
            <Route
              path="/organizations/:id"
              component={OrganizationDetailComponent}
            />
            <Route
              path="/organizations"
              component={OrganizationSearchComponent}
            />
            <Route path="/teams/create" component={TeamCreateComponent} />
            <Route path="/teams/edit/:id" component={TeamEditComponent} />
            <Route path="/teams/:id" component={TeamDetailComponent} />
            <Route path="/teams" component={TeamSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>bd62a6422c5895d9e951434590c9fc1a</Hash>
</Codenesium>*/