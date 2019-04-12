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
import { WrappedBucketCreateComponent } from './components/bucket/bucketCreateForm';
import { WrappedBucketDetailComponent } from './components/bucket/bucketDetailForm';
import { WrappedBucketEditComponent } from './components/bucket/bucketEditForm';
import { WrappedBucketSearchComponent } from './components/bucket/bucketSearchForm';
import { WrappedFileCreateComponent } from './components/file/fileCreateForm';
import { WrappedFileDetailComponent } from './components/file/fileDetailForm';
import { WrappedFileEditComponent } from './components/file/fileEditForm';
import { WrappedFileSearchComponent } from './components/file/fileSearchForm';
import { WrappedFileTypeCreateComponent } from './components/fileType/fileTypeCreateForm';
import { WrappedFileTypeDetailComponent } from './components/fileType/fileTypeDetailForm';
import { WrappedFileTypeEditComponent } from './components/fileType/fileTypeEditForm';
import { WrappedFileTypeSearchComponent } from './components/fileType/fileTypeSearchForm';

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
          path={ClientRoutes.Buckets + '/create'}
          component={wrapperHeader(
            WrappedBucketCreateComponent,
            'Buckets Create'
          )}
        />
        <Route
          path={ClientRoutes.Buckets + '/edit/:id'}
          component={wrapperHeader(WrappedBucketEditComponent, 'Buckets Edit')}
        />
        <Route
          path={ClientRoutes.Buckets + '/:id'}
          component={wrapperHeader(
            WrappedBucketDetailComponent,
            'Buckets Detail'
          )}
        />
        <Route
          path={ClientRoutes.Buckets}
          component={wrapperHeader(
            WrappedBucketSearchComponent,
            'Buckets Search'
          )}
        />
        <Route
          path={ClientRoutes.Files + '/create'}
          component={wrapperHeader(WrappedFileCreateComponent, 'Files Create')}
        />
        <Route
          path={ClientRoutes.Files + '/edit/:id'}
          component={wrapperHeader(WrappedFileEditComponent, 'Files Edit')}
        />
        <Route
          path={ClientRoutes.Files + '/:id'}
          component={wrapperHeader(WrappedFileDetailComponent, 'Files Detail')}
        />
        <Route
          path={ClientRoutes.Files}
          component={wrapperHeader(WrappedFileSearchComponent, 'Files Search')}
        />
        <Route
          path={ClientRoutes.FileTypes + '/create'}
          component={wrapperHeader(
            WrappedFileTypeCreateComponent,
            'File Types Create'
          )}
        />
        <Route
          path={ClientRoutes.FileTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedFileTypeEditComponent,
            'File Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.FileTypes + '/:id'}
          component={wrapperHeader(
            WrappedFileTypeDetailComponent,
            'File Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.FileTypes}
          component={wrapperHeader(
            WrappedFileTypeSearchComponent,
            'File Types Search'
          )}
        />
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>44f8f22a24cae89df4755928c25f89cb</Hash>
</Codenesium>*/