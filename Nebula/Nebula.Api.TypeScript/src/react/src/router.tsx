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
          path="/"
          component={wrapperHeader(Dashboard, 'Dashboard')}
        />
        <Route
          path={ClientRoutes.Chains + '/create'}
          component={wrapperHeader(
            WrappedChainCreateComponent,
            'Chains Create'
          )}
        />
        <Route
          path={ClientRoutes.Chains + '/edit/:id'}
          component={wrapperHeader(WrappedChainEditComponent, 'Chains Edit')}
        />
        <Route
          path={ClientRoutes.Chains + '/:id'}
          component={wrapperHeader(
            WrappedChainDetailComponent,
            'Chains Detail'
          )}
        />
        <Route
          path={ClientRoutes.Chains}
          component={wrapperHeader(
            WrappedChainSearchComponent,
            'Chains Search'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatuses + '/create'}
          component={wrapperHeader(
            WrappedChainStatusCreateComponent,
            'Chain Status Create'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatuses + '/edit/:id'}
          component={wrapperHeader(
            WrappedChainStatusEditComponent,
            'Chain Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatuses + '/:id'}
          component={wrapperHeader(
            WrappedChainStatusDetailComponent,
            'Chain Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.ChainStatuses}
          component={wrapperHeader(
            WrappedChainStatusSearchComponent,
            'Chain Status Search'
          )}
        />
        <Route
          path={ClientRoutes.Clasps + '/create'}
          component={wrapperHeader(
            WrappedClaspCreateComponent,
            'Clasps Create'
          )}
        />
        <Route
          path={ClientRoutes.Clasps + '/edit/:id'}
          component={wrapperHeader(WrappedClaspEditComponent, 'Clasps Edit')}
        />
        <Route
          path={ClientRoutes.Clasps + '/:id'}
          component={wrapperHeader(
            WrappedClaspDetailComponent,
            'Clasps Detail'
          )}
        />
        <Route
          path={ClientRoutes.Clasps}
          component={wrapperHeader(
            WrappedClaspSearchComponent,
            'Clasps Search'
          )}
        />
        <Route
          path={ClientRoutes.Links + '/create'}
          component={wrapperHeader(WrappedLinkCreateComponent, 'Links Create')}
        />
        <Route
          path={ClientRoutes.Links + '/edit/:id'}
          component={wrapperHeader(WrappedLinkEditComponent, 'Links Edit')}
        />
        <Route
          path={ClientRoutes.Links + '/:id'}
          component={wrapperHeader(WrappedLinkDetailComponent, 'Links Detail')}
        />
        <Route
          path={ClientRoutes.Links}
          component={wrapperHeader(WrappedLinkSearchComponent, 'Links Search')}
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
          path={ClientRoutes.LinkStatuses + '/create'}
          component={wrapperHeader(
            WrappedLinkStatusCreateComponent,
            'Link Status Create'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatuses + '/edit/:id'}
          component={wrapperHeader(
            WrappedLinkStatusEditComponent,
            'Link Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatuses + '/:id'}
          component={wrapperHeader(
            WrappedLinkStatusDetailComponent,
            'Link Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.LinkStatuses}
          component={wrapperHeader(
            WrappedLinkStatusSearchComponent,
            'Link Status Search'
          )}
        />
        <Route
          path={ClientRoutes.Machines + '/create'}
          component={wrapperHeader(
            WrappedMachineCreateComponent,
            'Machines Create'
          )}
        />
        <Route
          path={ClientRoutes.Machines + '/edit/:id'}
          component={wrapperHeader(
            WrappedMachineEditComponent,
            'Machines Edit'
          )}
        />
        <Route
          path={ClientRoutes.Machines + '/:id'}
          component={wrapperHeader(
            WrappedMachineDetailComponent,
            'Machines Detail'
          )}
        />
        <Route
          path={ClientRoutes.Machines}
          component={wrapperHeader(
            WrappedMachineSearchComponent,
            'Machines Search'
          )}
        />
        <Route
          path={ClientRoutes.Organizations + '/create'}
          component={wrapperHeader(
            WrappedOrganizationCreateComponent,
            'Organizations Create'
          )}
        />
        <Route
          path={ClientRoutes.Organizations + '/edit/:id'}
          component={wrapperHeader(
            WrappedOrganizationEditComponent,
            'Organizations Edit'
          )}
        />
        <Route
          path={ClientRoutes.Organizations + '/:id'}
          component={wrapperHeader(
            WrappedOrganizationDetailComponent,
            'Organizations Detail'
          )}
        />
        <Route
          path={ClientRoutes.Organizations}
          component={wrapperHeader(
            WrappedOrganizationSearchComponent,
            'Organizations Search'
          )}
        />
        <Route
          path={ClientRoutes.Teams + '/create'}
          component={wrapperHeader(WrappedTeamCreateComponent, 'Teams Create')}
        />
        <Route
          path={ClientRoutes.Teams + '/edit/:id'}
          component={wrapperHeader(WrappedTeamEditComponent, 'Teams Edit')}
        />
        <Route
          path={ClientRoutes.Teams + '/:id'}
          component={wrapperHeader(WrappedTeamDetailComponent, 'Teams Detail')}
        />
        <Route
          path={ClientRoutes.Teams}
          component={wrapperHeader(WrappedTeamSearchComponent, 'Teams Search')}
        />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>ec87f2b4641a94af3ef94f7f26fc43be</Hash>
</Codenesium>*/