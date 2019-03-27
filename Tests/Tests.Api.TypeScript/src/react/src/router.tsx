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
import { WrappedColumnSameAsFKTableCreateComponent } from './components/columnSameAsFKTable/columnSameAsFKTableCreateForm';
import { WrappedColumnSameAsFKTableDetailComponent } from './components/columnSameAsFKTable/columnSameAsFKTableDetailForm';
import { WrappedColumnSameAsFKTableEditComponent } from './components/columnSameAsFKTable/columnSameAsFKTableEditForm';
import { WrappedColumnSameAsFKTableSearchComponent } from './components/columnSameAsFKTable/columnSameAsFKTableSearchForm';
import { WrappedIncludedColumnTestCreateComponent } from './components/includedColumnTest/includedColumnTestCreateForm';
import { WrappedIncludedColumnTestDetailComponent } from './components/includedColumnTest/includedColumnTestDetailForm';
import { WrappedIncludedColumnTestEditComponent } from './components/includedColumnTest/includedColumnTestEditForm';
import { WrappedIncludedColumnTestSearchComponent } from './components/includedColumnTest/includedColumnTestSearchForm';
import { WrappedPersonCreateComponent } from './components/person/personCreateForm';
import { WrappedPersonDetailComponent } from './components/person/personDetailForm';
import { WrappedPersonEditComponent } from './components/person/personEditForm';
import { WrappedPersonSearchComponent } from './components/person/personSearchForm';
import { WrappedRowVersionCheckCreateComponent } from './components/rowVersionCheck/rowVersionCheckCreateForm';
import { WrappedRowVersionCheckDetailComponent } from './components/rowVersionCheck/rowVersionCheckDetailForm';
import { WrappedRowVersionCheckEditComponent } from './components/rowVersionCheck/rowVersionCheckEditForm';
import { WrappedRowVersionCheckSearchComponent } from './components/rowVersionCheck/rowVersionCheckSearchForm';
import { WrappedSelfReferenceCreateComponent } from './components/selfReference/selfReferenceCreateForm';
import { WrappedSelfReferenceDetailComponent } from './components/selfReference/selfReferenceDetailForm';
import { WrappedSelfReferenceEditComponent } from './components/selfReference/selfReferenceEditForm';
import { WrappedSelfReferenceSearchComponent } from './components/selfReference/selfReferenceSearchForm';
import { WrappedTableCreateComponent } from './components/table/tableCreateForm';
import { WrappedTableDetailComponent } from './components/table/tableDetailForm';
import { WrappedTableEditComponent } from './components/table/tableEditForm';
import { WrappedTableSearchComponent } from './components/table/tableSearchForm';
import { WrappedTestAllFieldTypeCreateComponent } from './components/testAllFieldType/testAllFieldTypeCreateForm';
import { WrappedTestAllFieldTypeDetailComponent } from './components/testAllFieldType/testAllFieldTypeDetailForm';
import { WrappedTestAllFieldTypeEditComponent } from './components/testAllFieldType/testAllFieldTypeEditForm';
import { WrappedTestAllFieldTypeSearchComponent } from './components/testAllFieldType/testAllFieldTypeSearchForm';
import { WrappedTestAllFieldTypesNullableCreateComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableCreateForm';
import { WrappedTestAllFieldTypesNullableDetailComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableDetailForm';
import { WrappedTestAllFieldTypesNullableEditComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableEditForm';
import { WrappedTestAllFieldTypesNullableSearchComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableSearchForm';
import { WrappedTimestampCheckCreateComponent } from './components/timestampCheck/timestampCheckCreateForm';
import { WrappedTimestampCheckDetailComponent } from './components/timestampCheck/timestampCheckDetailForm';
import { WrappedTimestampCheckEditComponent } from './components/timestampCheck/timestampCheckEditForm';
import { WrappedTimestampCheckSearchComponent } from './components/timestampCheck/timestampCheckSearchForm';
import { WrappedVPersonCreateComponent } from './components/vPerson/vPersonCreateForm';
import { WrappedVPersonDetailComponent } from './components/vPerson/vPersonDetailForm';
import { WrappedVPersonEditComponent } from './components/vPerson/vPersonEditForm';
import { WrappedVPersonSearchComponent } from './components/vPerson/vPersonSearchForm';

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
          path={ClientRoutes.ColumnSameAsFKTables + '/create'}
          component={wrapperHeader(
            WrappedColumnSameAsFKTableCreateComponent,
            'Column Same As F K Table Create'
          )}
        />
        <Route
          path={ClientRoutes.ColumnSameAsFKTables + '/edit/:id'}
          component={wrapperHeader(
            WrappedColumnSameAsFKTableEditComponent,
            'Column Same As F K Table Edit'
          )}
        />
        <Route
          path={ClientRoutes.ColumnSameAsFKTables + '/:id'}
          component={wrapperHeader(
            WrappedColumnSameAsFKTableDetailComponent,
            'Column Same As F K Table Detail'
          )}
        />
        <Route
          path={ClientRoutes.ColumnSameAsFKTables}
          component={wrapperHeader(
            WrappedColumnSameAsFKTableSearchComponent,
            'Column Same As F K Table Search'
          )}
        />
        <Route
          path={ClientRoutes.IncludedColumnTests + '/create'}
          component={wrapperHeader(
            WrappedIncludedColumnTestCreateComponent,
            'Included Column Test Create'
          )}
        />
        <Route
          path={ClientRoutes.IncludedColumnTests + '/edit/:id'}
          component={wrapperHeader(
            WrappedIncludedColumnTestEditComponent,
            'Included Column Test Edit'
          )}
        />
        <Route
          path={ClientRoutes.IncludedColumnTests + '/:id'}
          component={wrapperHeader(
            WrappedIncludedColumnTestDetailComponent,
            'Included Column Test Detail'
          )}
        />
        <Route
          path={ClientRoutes.IncludedColumnTests}
          component={wrapperHeader(
            WrappedIncludedColumnTestSearchComponent,
            'Included Column Test Search'
          )}
        />
        <Route
          path={ClientRoutes.People + '/create'}
          component={wrapperHeader(
            WrappedPersonCreateComponent,
            'P E R S O N Create'
          )}
        />
        <Route
          path={ClientRoutes.People + '/edit/:id'}
          component={wrapperHeader(
            WrappedPersonEditComponent,
            'P E R S O N Edit'
          )}
        />
        <Route
          path={ClientRoutes.People + '/:id'}
          component={wrapperHeader(
            WrappedPersonDetailComponent,
            'P E R S O N Detail'
          )}
        />
        <Route
          path={ClientRoutes.People}
          component={wrapperHeader(
            WrappedPersonSearchComponent,
            'P E R S O N Search'
          )}
        />
        <Route
          path={ClientRoutes.RowVersionChecks + '/create'}
          component={wrapperHeader(
            WrappedRowVersionCheckCreateComponent,
            'Row Version Check Create'
          )}
        />
        <Route
          path={ClientRoutes.RowVersionChecks + '/edit/:id'}
          component={wrapperHeader(
            WrappedRowVersionCheckEditComponent,
            'Row Version Check Edit'
          )}
        />
        <Route
          path={ClientRoutes.RowVersionChecks + '/:id'}
          component={wrapperHeader(
            WrappedRowVersionCheckDetailComponent,
            'Row Version Check Detail'
          )}
        />
        <Route
          path={ClientRoutes.RowVersionChecks}
          component={wrapperHeader(
            WrappedRowVersionCheckSearchComponent,
            'Row Version Check Search'
          )}
        />
        <Route
          path={ClientRoutes.SelfReferences + '/create'}
          component={wrapperHeader(
            WrappedSelfReferenceCreateComponent,
            'Self Reference Create'
          )}
        />
        <Route
          path={ClientRoutes.SelfReferences + '/edit/:id'}
          component={wrapperHeader(
            WrappedSelfReferenceEditComponent,
            'Self Reference Edit'
          )}
        />
        <Route
          path={ClientRoutes.SelfReferences + '/:id'}
          component={wrapperHeader(
            WrappedSelfReferenceDetailComponent,
            'Self Reference Detail'
          )}
        />
        <Route
          path={ClientRoutes.SelfReferences}
          component={wrapperHeader(
            WrappedSelfReferenceSearchComponent,
            'Self Reference Search'
          )}
        />
        <Route
          path={ClientRoutes.Tables + '/create'}
          component={wrapperHeader(
            WrappedTableCreateComponent,
            'Tables Create'
          )}
        />
        <Route
          path={ClientRoutes.Tables + '/edit/:id'}
          component={wrapperHeader(WrappedTableEditComponent, 'Tables Edit')}
        />
        <Route
          path={ClientRoutes.Tables + '/:id'}
          component={wrapperHeader(
            WrappedTableDetailComponent,
            'Tables Detail'
          )}
        />
        <Route
          path={ClientRoutes.Tables}
          component={wrapperHeader(
            WrappedTableSearchComponent,
            'Tables Search'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypes + '/create'}
          component={wrapperHeader(
            WrappedTestAllFieldTypeCreateComponent,
            'Test All Field Types Create'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedTestAllFieldTypeEditComponent,
            'Test All Field Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypes + '/:id'}
          component={wrapperHeader(
            WrappedTestAllFieldTypeDetailComponent,
            'Test All Field Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypes}
          component={wrapperHeader(
            WrappedTestAllFieldTypeSearchComponent,
            'Test All Field Types Search'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypesNullables + '/create'}
          component={wrapperHeader(
            WrappedTestAllFieldTypesNullableCreateComponent,
            'Test All Field Types Nullable Create'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypesNullables + '/edit/:id'}
          component={wrapperHeader(
            WrappedTestAllFieldTypesNullableEditComponent,
            'Test All Field Types Nullable Edit'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypesNullables + '/:id'}
          component={wrapperHeader(
            WrappedTestAllFieldTypesNullableDetailComponent,
            'Test All Field Types Nullable Detail'
          )}
        />
        <Route
          path={ClientRoutes.TestAllFieldTypesNullables}
          component={wrapperHeader(
            WrappedTestAllFieldTypesNullableSearchComponent,
            'Test All Field Types Nullable Search'
          )}
        />
        <Route
          path={ClientRoutes.TimestampChecks + '/create'}
          component={wrapperHeader(
            WrappedTimestampCheckCreateComponent,
            'Timestamp Check Create'
          )}
        />
        <Route
          path={ClientRoutes.TimestampChecks + '/edit/:id'}
          component={wrapperHeader(
            WrappedTimestampCheckEditComponent,
            'Timestamp Check Edit'
          )}
        />
        <Route
          path={ClientRoutes.TimestampChecks + '/:id'}
          component={wrapperHeader(
            WrappedTimestampCheckDetailComponent,
            'Timestamp Check Detail'
          )}
        />
        <Route
          path={ClientRoutes.TimestampChecks}
          component={wrapperHeader(
            WrappedTimestampCheckSearchComponent,
            'Timestamp Check Search'
          )}
        />
        <Route
          path={ClientRoutes.VPersons + '/create'}
          component={wrapperHeader(
            WrappedVPersonCreateComponent,
            'V Person Create'
          )}
        />
        <Route
          path={ClientRoutes.VPersons + '/edit/:id'}
          component={wrapperHeader(
            WrappedVPersonEditComponent,
            'V Person Edit'
          )}
        />
        <Route
          path={ClientRoutes.VPersons + '/:id'}
          component={wrapperHeader(
            WrappedVPersonDetailComponent,
            'V Person Detail'
          )}
        />
        <Route
          path={ClientRoutes.VPersons}
          component={wrapperHeader(
            WrappedVPersonSearchComponent,
            'V Person Search'
          )}
        />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>100e0a5470561bf3311f2b31ad9f3b4d</Hash>
</Codenesium>*/