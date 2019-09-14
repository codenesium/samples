import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { wrapperHeader } from './components/header';
import { wrapperAuthHeader } from './components/auth/authHeader';
import { AuthClientRoutes, ClientRoutes, Constants } from './constants';
import { WrappedLoginComponent } from './components/auth/loginForm';
import { WrappedLogoutComponent } from './components/auth/logoutForm';
import { WrappedRegisterComponent } from './components/auth/registerForm';
import { WrappedResetPasswordComponent } from './components/auth/resetPasswordForm';
import { WrappedConfirmPasswordResetComponent } from './components/auth/confirmPasswordResetForm';
import { WrappedConfirmRegistrationComponent } from './components/auth/confirmRegistrationForm';
import { WrappedChangePasswordComponent } from './components/auth/changePasswordForm';
import { WrappedChangeEmailComponent } from './components/auth/changeEmailForm';
import { WrappedConfirmChangeEmailComponent } from './components/auth/confirmChangeEmailForm';
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

export const AppRouter: React.StatelessComponent<{}> = () => {
  return (
    <BrowserRouter basename={Constants.HostedSubDirectory}>
      <Switch>
        <Route
          exact
          path={AuthClientRoutes.ConfirmPasswordReset + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmPasswordResetComponent,
            'Confirm Password Reset'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmRegistration + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmRegistrationComponent,
            'Confirm Registration'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.Login}
          component={wrapperAuthHeader(WrappedLoginComponent, 'Login')}
        />
        <Route
          exact
          path={AuthClientRoutes.Logout}
          component={wrapperAuthHeader(WrappedLogoutComponent, 'Logout')}
        />
        <Route
          exact
          path={AuthClientRoutes.Register}
          component={wrapperAuthHeader(WrappedRegisterComponent, 'Register')}
        />
        <Route
          exact
          path={AuthClientRoutes.ResetPassword}
          component={wrapperAuthHeader(
            WrappedResetPasswordComponent,
            'Reset Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangePassword}
          component={wrapperHeader(
            WrappedChangePasswordComponent,
            'Change Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangeEmail}
          component={wrapperHeader(WrappedChangeEmailComponent, 'Change Email')}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmChangeEmail + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmChangeEmailComponent,
            'Confirm Email Change'
          )}
        />
        <Route
          exact
          path="/"
          component={wrapperHeader(Dashboard, 'Dashboard')}
        />
        <Route
          path={ClientRoutes.Chains + '/create'}
          component={wrapperHeader(WrappedChainCreateComponent, 'Chain Create')}
        />
        <Route
          path={ClientRoutes.Chains + '/edit/:id'}
          component={wrapperHeader(WrappedChainEditComponent, 'Chain Edit')}
        />
        <Route
          path={ClientRoutes.Chains + '/:id'}
          component={wrapperHeader(WrappedChainDetailComponent, 'Chain Detail')}
        />
        <Route
          path={ClientRoutes.Chains}
          component={wrapperHeader(WrappedChainSearchComponent, 'Chain Search')}
        />
        <Route
          path={ClientRoutes.ChainStatus + '/create'}
          component={wrapperHeader(
            WrappedChainStatusCreateComponent,
            'Chain Status Create'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedChainStatusEditComponent,
            'Chain Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatus + '/:id'}
          component={wrapperHeader(
            WrappedChainStatusDetailComponent,
            'Chain Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatus}
          component={wrapperHeader(
            WrappedChainStatusSearchComponent,
            'Chain Status Search'
          )}
        />
        <Route
          path={ClientRoutes.Clasps + '/create'}
          component={wrapperHeader(WrappedClaspCreateComponent, 'Clasp Create')}
        />
        <Route
          path={ClientRoutes.Clasps + '/edit/:id'}
          component={wrapperHeader(WrappedClaspEditComponent, 'Clasp Edit')}
        />
        <Route
          path={ClientRoutes.Clasps + '/:id'}
          component={wrapperHeader(WrappedClaspDetailComponent, 'Clasp Detail')}
        />
        <Route
          path={ClientRoutes.Clasps}
          component={wrapperHeader(WrappedClaspSearchComponent, 'Clasp Search')}
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
            'Link Log Create'
          )}
        />
        <Route
          path={ClientRoutes.LinkLogs + '/edit/:id'}
          component={wrapperHeader(
            WrappedLinkLogEditComponent,
            'Link Log Edit'
          )}
        />
        <Route
          path={ClientRoutes.LinkLogs + '/:id'}
          component={wrapperHeader(
            WrappedLinkLogDetailComponent,
            'Link Log Detail'
          )}
        />
        <Route
          path={ClientRoutes.LinkLogs}
          component={wrapperHeader(
            WrappedLinkLogSearchComponent,
            'Link Log Search'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatus + '/create'}
          component={wrapperHeader(
            WrappedLinkStatusCreateComponent,
            'Link Status Create'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedLinkStatusEditComponent,
            'Link Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatus + '/:id'}
          component={wrapperHeader(
            WrappedLinkStatusDetailComponent,
            'Link Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatus}
          component={wrapperHeader(
            WrappedLinkStatusSearchComponent,
            'Link Status Search'
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
          component={wrapperHeader(WrappedMachineEditComponent, 'Machine Edit')}
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
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>1a06d77c8c74254226394181d9345879</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/