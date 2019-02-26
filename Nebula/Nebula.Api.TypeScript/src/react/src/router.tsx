import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedChainCreateComponent } from './components/chain/chainCreateForm';
import { WrappedChainDetailComponent } from './components/chain/chainDetailForm';
import { WrappedChainEditComponent } from './components/chain/chainEditForm';
import { WrappedChainSearchComponent } from './components/chain/chainSearchForm';
import { WrappedChainStatusCreateComponent } from './components/chainStatus/chainStatusCreateForm';
import { WrappedChainStatusDetailComponent } from './components/chainStatus/chainStatusDetailForm';
import { WrappedChainStatusEditComponent } from './components/chainStatus/chainStatusEditForm';
import { WrappedChainStatusSearchComponent } from './components/chainStatus/chainStatusSearchForm';
import { WrappedClaspCreateComponent } from './components/clasp/claspCreateForm';
import { WrappedClaspDetailComponent } from './components/clasp/claspDetailForm';
import { WrappedClaspEditComponent } from './components/clasp/claspEditForm';
import { WrappedClaspSearchComponent } from './components/clasp/claspSearchForm';
import { WrappedLinkCreateComponent } from './components/link/linkCreateForm';
import { WrappedLinkDetailComponent } from './components/link/linkDetailForm';
import { WrappedLinkEditComponent } from './components/link/linkEditForm';
import { WrappedLinkSearchComponent } from './components/link/linkSearchForm';
import { WrappedLinkLogCreateComponent } from './components/linkLog/linkLogCreateForm';
import { WrappedLinkLogDetailComponent } from './components/linkLog/linkLogDetailForm';
import { WrappedLinkLogEditComponent } from './components/linkLog/linkLogEditForm';
import { WrappedLinkLogSearchComponent } from './components/linkLog/linkLogSearchForm';
import { WrappedLinkStatusCreateComponent } from './components/linkStatus/linkStatusCreateForm';
import { WrappedLinkStatusDetailComponent } from './components/linkStatus/linkStatusDetailForm';
import { WrappedLinkStatusEditComponent } from './components/linkStatus/linkStatusEditForm';
import { WrappedLinkStatusSearchComponent } from './components/linkStatus/linkStatusSearchForm';
import { WrappedMachineCreateComponent } from './components/machine/machineCreateForm';
import { WrappedMachineDetailComponent } from './components/machine/machineDetailForm';
import { WrappedMachineEditComponent } from './components/machine/machineEditForm';
import { WrappedMachineSearchComponent } from './components/machine/machineSearchForm';
import { WrappedOrganizationCreateComponent } from './components/organization/organizationCreateForm';
import { WrappedOrganizationDetailComponent } from './components/organization/organizationDetailForm';
import { WrappedOrganizationEditComponent } from './components/organization/organizationEditForm';
import { WrappedOrganizationSearchComponent } from './components/organization/organizationSearchForm';
import { WrappedTeamCreateComponent } from './components/team/teamCreateForm';
import { WrappedTeamDetailComponent } from './components/team/teamDetailForm';
import { WrappedTeamEditComponent } from './components/team/teamEditForm';
import { WrappedTeamSearchComponent } from './components/team/teamSearchForm';

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
            path={ClientRoutes.Chains + '/create'}
            component={wrapperHeader(
              WrappedChainCreateComponent,
              'Chain Create'
            )}
          />
          <Route
            path={ClientRoutes.Chains + '/edit/:id'}
            component={wrapperHeader(WrappedChainEditComponent, 'Chain Edit')}
          />
          <Route
            path={ClientRoutes.Chains + '/:id'}
            component={wrapperHeader(
              WrappedChainDetailComponent,
              'Chain Detail'
            )}
          />
          <Route
            path={ClientRoutes.Chains}
            component={wrapperHeader(
              WrappedChainSearchComponent,
              'Chain Search'
            )}
          />
          <Route
            path={ClientRoutes.ChainStatuses + '/create'}
            component={wrapperHeader(
              WrappedChainStatusCreateComponent,
              'ChainStatus Create'
            )}
          />
          <Route
            path={ClientRoutes.ChainStatuses + '/edit/:id'}
            component={wrapperHeader(
              WrappedChainStatusEditComponent,
              'ChainStatus Edit'
            )}
          />
          <Route
            path={ClientRoutes.ChainStatuses + '/:id'}
            component={wrapperHeader(
              WrappedChainStatusDetailComponent,
              'ChainStatus Detail'
            )}
          />
          <Route
            path={ClientRoutes.ChainStatuses}
            component={wrapperHeader(
              WrappedChainStatusSearchComponent,
              'ChainStatus Search'
            )}
          />
          <Route
            path={ClientRoutes.Clasps + '/create'}
            component={wrapperHeader(
              WrappedClaspCreateComponent,
              'Clasp Create'
            )}
          />
          <Route
            path={ClientRoutes.Clasps + '/edit/:id'}
            component={wrapperHeader(WrappedClaspEditComponent, 'Clasp Edit')}
          />
          <Route
            path={ClientRoutes.Clasps + '/:id'}
            component={wrapperHeader(
              WrappedClaspDetailComponent,
              'Clasp Detail'
            )}
          />
          <Route
            path={ClientRoutes.Clasps}
            component={wrapperHeader(
              WrappedClaspSearchComponent,
              'Clasp Search'
            )}
          />
          <Route
            path={ClientRoutes.Links + '/create'}
            component={wrapperHeader(WrappedLinkCreateComponent, 'Link Create')}
          />
          <Route
            path={ClientRoutes.Links + '/edit/:id'}
            component={wrapperHeader(WrappedLinkEditComponent, 'Link Edit')}
          />
          <Route
            path={ClientRoutes.Links + '/:id'}
            component={wrapperHeader(WrappedLinkDetailComponent, 'Link Detail')}
          />
          <Route
            path={ClientRoutes.Links}
            component={wrapperHeader(WrappedLinkSearchComponent, 'Link Search')}
          />
          <Route
            path={ClientRoutes.LinkLogs + '/create'}
            component={wrapperHeader(
              WrappedLinkLogCreateComponent,
              'LinkLog Create'
            )}
          />
          <Route
            path={ClientRoutes.LinkLogs + '/edit/:id'}
            component={wrapperHeader(
              WrappedLinkLogEditComponent,
              'LinkLog Edit'
            )}
          />
          <Route
            path={ClientRoutes.LinkLogs + '/:id'}
            component={wrapperHeader(
              WrappedLinkLogDetailComponent,
              'LinkLog Detail'
            )}
          />
          <Route
            path={ClientRoutes.LinkLogs}
            component={wrapperHeader(
              WrappedLinkLogSearchComponent,
              'LinkLog Search'
            )}
          />
          <Route
            path={ClientRoutes.LinkStatuses + '/create'}
            component={wrapperHeader(
              WrappedLinkStatusCreateComponent,
              'LinkStatus Create'
            )}
          />
          <Route
            path={ClientRoutes.LinkStatuses + '/edit/:id'}
            component={wrapperHeader(
              WrappedLinkStatusEditComponent,
              'LinkStatus Edit'
            )}
          />
          <Route
            path={ClientRoutes.LinkStatuses + '/:id'}
            component={wrapperHeader(
              WrappedLinkStatusDetailComponent,
              'LinkStatus Detail'
            )}
          />
          <Route
            path={ClientRoutes.LinkStatuses}
            component={wrapperHeader(
              WrappedLinkStatusSearchComponent,
              'LinkStatus Search'
            )}
          />
          <Route
            path={ClientRoutes.Machines + '/create'}
            component={wrapperHeader(
              WrappedMachineCreateComponent,
              'Machine Create'
            )}
          />
          <Route
            path={ClientRoutes.Machines + '/edit/:id'}
            component={wrapperHeader(
              WrappedMachineEditComponent,
              'Machine Edit'
            )}
          />
          <Route
            path={ClientRoutes.Machines + '/:id'}
            component={wrapperHeader(
              WrappedMachineDetailComponent,
              'Machine Detail'
            )}
          />
          <Route
            path={ClientRoutes.Machines}
            component={wrapperHeader(
              WrappedMachineSearchComponent,
              'Machine Search'
            )}
          />
          <Route
            path={ClientRoutes.Organizations + '/create'}
            component={wrapperHeader(
              WrappedOrganizationCreateComponent,
              'Organization Create'
            )}
          />
          <Route
            path={ClientRoutes.Organizations + '/edit/:id'}
            component={wrapperHeader(
              WrappedOrganizationEditComponent,
              'Organization Edit'
            )}
          />
          <Route
            path={ClientRoutes.Organizations + '/:id'}
            component={wrapperHeader(
              WrappedOrganizationDetailComponent,
              'Organization Detail'
            )}
          />
          <Route
            path={ClientRoutes.Organizations}
            component={wrapperHeader(
              WrappedOrganizationSearchComponent,
              'Organization Search'
            )}
          />
          <Route
            path={ClientRoutes.Teams + '/create'}
            component={wrapperHeader(WrappedTeamCreateComponent, 'Team Create')}
          />
          <Route
            path={ClientRoutes.Teams + '/edit/:id'}
            component={wrapperHeader(WrappedTeamEditComponent, 'Team Edit')}
          />
          <Route
            path={ClientRoutes.Teams + '/:id'}
            component={wrapperHeader(WrappedTeamDetailComponent, 'Team Detail')}
          />
          <Route
            path={ClientRoutes.Teams}
            component={wrapperHeader(WrappedTeamSearchComponent, 'Team Search')}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>a05143146c53166f540874008ac839ab</Hash>
</Codenesium>*/