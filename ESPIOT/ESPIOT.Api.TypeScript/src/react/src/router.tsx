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
import { WrappedDeviceCreateComponent } from './components/device/deviceCreateForm';
import { WrappedDeviceDetailComponent } from './components/device/deviceDetailForm';
import { WrappedDeviceEditComponent } from './components/device/deviceEditForm';
import { WrappedDeviceSearchComponent } from './components/device/deviceSearchForm';
import { WrappedDeviceActionCreateComponent } from './components/deviceAction/deviceActionCreateForm';
import { WrappedDeviceActionDetailComponent } from './components/deviceAction/deviceActionDetailForm';
import { WrappedDeviceActionEditComponent } from './components/deviceAction/deviceActionEditForm';
import { WrappedDeviceActionSearchComponent } from './components/deviceAction/deviceActionSearchForm';

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
          path={ClientRoutes.Devices + '/create'}
          component={wrapperHeader(
            WrappedDeviceCreateComponent,
            'Devices Create'
          )}
        />
        <Route
          path={ClientRoutes.Devices + '/edit/:id'}
          component={wrapperHeader(WrappedDeviceEditComponent, 'Devices Edit')}
        />
        <Route
          path={ClientRoutes.Devices + '/:id'}
          component={wrapperHeader(
            WrappedDeviceDetailComponent,
            'Devices Detail'
          )}
        />
        <Route
          path={ClientRoutes.Devices}
          component={wrapperHeader(
            WrappedDeviceSearchComponent,
            'Devices Search'
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
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>c726e06dd741dac9f63486613156ccb4</Hash>
</Codenesium>*/