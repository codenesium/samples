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
import { WrappedCustomerCreateComponent } from './components/customer/customerCreateForm';
import { WrappedCustomerDetailComponent } from './components/customer/customerDetailForm';
import { WrappedCustomerEditComponent } from './components/customer/customerEditForm';
import { WrappedCustomerSearchComponent } from './components/customer/customerSearchForm';
import { WrappedProductCreateComponent } from './components/product/productCreateForm';
import { WrappedProductDetailComponent } from './components/product/productDetailForm';
import { WrappedProductEditComponent } from './components/product/productEditForm';
import { WrappedProductSearchComponent } from './components/product/productSearchForm';
import { WrappedSaleCreateComponent } from './components/sale/saleCreateForm';
import { WrappedSaleDetailComponent } from './components/sale/saleDetailForm';
import { WrappedSaleEditComponent } from './components/sale/saleEditForm';
import { WrappedSaleSearchComponent } from './components/sale/saleSearchForm';

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
          path={ClientRoutes.Customers + '/create'}
          component={wrapperHeader(
            WrappedCustomerCreateComponent,
            'Customer Create'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/edit/:id'}
          component={wrapperHeader(
            WrappedCustomerEditComponent,
            'Customer Edit'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/:id'}
          component={wrapperHeader(
            WrappedCustomerDetailComponent,
            'Customer Detail'
          )}
        />
        <Route
          path={ClientRoutes.Customers}
          component={wrapperHeader(
            WrappedCustomerSearchComponent,
            'Customer Search'
          )}
        />
        <Route
          path={ClientRoutes.Products + '/create'}
          component={wrapperHeader(
            WrappedProductCreateComponent,
            'Product Create'
          )}
        />
        <Route
          path={ClientRoutes.Products + '/edit/:id'}
          component={wrapperHeader(WrappedProductEditComponent, 'Product Edit')}
        />
        <Route
          path={ClientRoutes.Products + '/:id'}
          component={wrapperHeader(
            WrappedProductDetailComponent,
            'Product Detail'
          )}
        />
        <Route
          path={ClientRoutes.Products}
          component={wrapperHeader(
            WrappedProductSearchComponent,
            'Product Search'
          )}
        />
        <Route
          path={ClientRoutes.Sales + '/create'}
          component={wrapperHeader(WrappedSaleCreateComponent, 'Sale Create')}
        />
        <Route
          path={ClientRoutes.Sales + '/edit/:id'}
          component={wrapperHeader(WrappedSaleEditComponent, 'Sale Edit')}
        />
        <Route
          path={ClientRoutes.Sales + '/:id'}
          component={wrapperHeader(WrappedSaleDetailComponent, 'Sale Detail')}
        />
        <Route
          path={ClientRoutes.Sales}
          component={wrapperHeader(WrappedSaleSearchComponent, 'Sale Search')}
        />
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>60972b73278a3a6383d3a200dbae1479</Hash>
</Codenesium>*/