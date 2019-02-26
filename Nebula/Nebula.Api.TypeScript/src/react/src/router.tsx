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
  }
}

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search)

  return (
    <BrowserRouter>   
	<Security issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}>
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard, "Dashboard")} />
		  <Route path={ClientRoutes.Chains + "/create"} component={wrapperHeader(WrappedChainCreateComponent, "Chains Create")} />
                      <Route path={ClientRoutes.Chains + "/edit/:id"} component={wrapperHeader(WrappedChainEditComponent, "Chains Edit")} />
                      <Route path={ClientRoutes.Chains + "/:id"} component={wrapperHeader(WrappedChainDetailComponent , "Chains Detail")} />
                      <Route path={ClientRoutes.Chains} component={wrapperHeader(WrappedChainSearchComponent, "Chains Search")} />
					<Route path={ClientRoutes.ChainStatuses + "/create"} component={wrapperHeader(WrappedChainStatusCreateComponent, "ChainStatuses Create")} />
                      <Route path={ClientRoutes.ChainStatuses + "/edit/:id"} component={wrapperHeader(WrappedChainStatusEditComponent, "ChainStatuses Edit")} />
                      <Route path={ClientRoutes.ChainStatuses + "/:id"} component={wrapperHeader(WrappedChainStatusDetailComponent , "ChainStatuses Detail")} />
                      <Route path={ClientRoutes.ChainStatuses} component={wrapperHeader(WrappedChainStatusSearchComponent, "ChainStatuses Search")} />
					<Route path={ClientRoutes.Clasps + "/create"} component={wrapperHeader(WrappedClaspCreateComponent, "Clasps Create")} />
                      <Route path={ClientRoutes.Clasps + "/edit/:id"} component={wrapperHeader(WrappedClaspEditComponent, "Clasps Edit")} />
                      <Route path={ClientRoutes.Clasps + "/:id"} component={wrapperHeader(WrappedClaspDetailComponent , "Clasps Detail")} />
                      <Route path={ClientRoutes.Clasps} component={wrapperHeader(WrappedClaspSearchComponent, "Clasps Search")} />
					<Route path={ClientRoutes.Links + "/create"} component={wrapperHeader(WrappedLinkCreateComponent, "Links Create")} />
                      <Route path={ClientRoutes.Links + "/edit/:id"} component={wrapperHeader(WrappedLinkEditComponent, "Links Edit")} />
                      <Route path={ClientRoutes.Links + "/:id"} component={wrapperHeader(WrappedLinkDetailComponent , "Links Detail")} />
                      <Route path={ClientRoutes.Links} component={wrapperHeader(WrappedLinkSearchComponent, "Links Search")} />
					<Route path={ClientRoutes.LinkLogs + "/create"} component={wrapperHeader(WrappedLinkLogCreateComponent, "LinkLogs Create")} />
                      <Route path={ClientRoutes.LinkLogs + "/edit/:id"} component={wrapperHeader(WrappedLinkLogEditComponent, "LinkLogs Edit")} />
                      <Route path={ClientRoutes.LinkLogs + "/:id"} component={wrapperHeader(WrappedLinkLogDetailComponent , "LinkLogs Detail")} />
                      <Route path={ClientRoutes.LinkLogs} component={wrapperHeader(WrappedLinkLogSearchComponent, "LinkLogs Search")} />
					<Route path={ClientRoutes.LinkStatuses + "/create"} component={wrapperHeader(WrappedLinkStatusCreateComponent, "LinkStatuses Create")} />
                      <Route path={ClientRoutes.LinkStatuses + "/edit/:id"} component={wrapperHeader(WrappedLinkStatusEditComponent, "LinkStatuses Edit")} />
                      <Route path={ClientRoutes.LinkStatuses + "/:id"} component={wrapperHeader(WrappedLinkStatusDetailComponent , "LinkStatuses Detail")} />
                      <Route path={ClientRoutes.LinkStatuses} component={wrapperHeader(WrappedLinkStatusSearchComponent, "LinkStatuses Search")} />
					<Route path={ClientRoutes.Machines + "/create"} component={wrapperHeader(WrappedMachineCreateComponent, "Machines Create")} />
                      <Route path={ClientRoutes.Machines + "/edit/:id"} component={wrapperHeader(WrappedMachineEditComponent, "Machines Edit")} />
                      <Route path={ClientRoutes.Machines + "/:id"} component={wrapperHeader(WrappedMachineDetailComponent , "Machines Detail")} />
                      <Route path={ClientRoutes.Machines} component={wrapperHeader(WrappedMachineSearchComponent, "Machines Search")} />
					<Route path={ClientRoutes.Organizations + "/create"} component={wrapperHeader(WrappedOrganizationCreateComponent, "Organizations Create")} />
                      <Route path={ClientRoutes.Organizations + "/edit/:id"} component={wrapperHeader(WrappedOrganizationEditComponent, "Organizations Edit")} />
                      <Route path={ClientRoutes.Organizations + "/:id"} component={wrapperHeader(WrappedOrganizationDetailComponent , "Organizations Detail")} />
                      <Route path={ClientRoutes.Organizations} component={wrapperHeader(WrappedOrganizationSearchComponent, "Organizations Search")} />
					<Route path={ClientRoutes.Teams + "/create"} component={wrapperHeader(WrappedTeamCreateComponent, "Teams Create")} />
                      <Route path={ClientRoutes.Teams + "/edit/:id"} component={wrapperHeader(WrappedTeamEditComponent, "Teams Edit")} />
                      <Route path={ClientRoutes.Teams + "/:id"} component={wrapperHeader(WrappedTeamDetailComponent , "Teams Detail")} />
                      <Route path={ClientRoutes.Teams} component={wrapperHeader(WrappedTeamSearchComponent, "Teams Search")} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>2d6136dba6e6802054561cd601c85ec8</Hash>
</Codenesium>*/