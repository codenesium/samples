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
          path={ClientRoutes.Videos + '/create'}
          component={wrapperHeader(
            WrappedVideoCreateComponent,
            'Videos Create'
          )}
        />
        <Route
          path={ClientRoutes.Videos + '/edit/:id'}
          component={wrapperHeader(WrappedVideoEditComponent, 'Videos Edit')}
        />
        <Route
          path={ClientRoutes.Videos + '/:id'}
          component={wrapperHeader(
            WrappedVideoDetailComponent,
            'Videos Detail'
          )}
        />
        <Route
          path={ClientRoutes.Videos}
          component={wrapperHeader(
            WrappedVideoSearchComponent,
            'Videos Search'
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
            'Subscriptions Create'
          )}
        />
        <Route
          path={ClientRoutes.Subscriptions + '/edit/:id'}
          component={wrapperHeader(
            WrappedSubscriptionEditComponent,
            'Subscriptions Edit'
          )}
        />
        <Route
          path={ClientRoutes.Subscriptions + '/:id'}
          component={wrapperHeader(
            WrappedSubscriptionDetailComponent,
            'Subscriptions Detail'
          )}
        />
        <Route
          path={ClientRoutes.Subscriptions}
          component={wrapperHeader(
            WrappedSubscriptionSearchComponent,
            'Subscriptions Search'
          )}
        />
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>3013bec2c9a29e77bd47de196c2fa11c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/