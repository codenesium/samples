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
import { WrappedAdminCreateComponent } from './components/admin/adminCreateForm';
import { WrappedAdminDetailComponent } from './components/admin/adminDetailForm';
import { WrappedAdminEditComponent } from './components/admin/adminEditForm';
import { WrappedAdminSearchComponent } from './components/admin/adminSearchForm';
import { WrappedCityCreateComponent } from './components/city/cityCreateForm';
import { WrappedCityDetailComponent } from './components/city/cityDetailForm';
import { WrappedCityEditComponent } from './components/city/cityEditForm';
import { WrappedCitySearchComponent } from './components/city/citySearchForm';
import { WrappedCountryCreateComponent } from './components/country/countryCreateForm';
import { WrappedCountryDetailComponent } from './components/country/countryDetailForm';
import { WrappedCountryEditComponent } from './components/country/countryEditForm';
import { WrappedCountrySearchComponent } from './components/country/countrySearchForm';
import { WrappedCustomerCreateComponent } from './components/customer/customerCreateForm';
import { WrappedCustomerDetailComponent } from './components/customer/customerDetailForm';
import { WrappedCustomerEditComponent } from './components/customer/customerEditForm';
import { WrappedCustomerSearchComponent } from './components/customer/customerSearchForm';
import { WrappedEventCreateComponent } from './components/event/eventCreateForm';
import { WrappedEventDetailComponent } from './components/event/eventDetailForm';
import { WrappedEventEditComponent } from './components/event/eventEditForm';
import { WrappedEventSearchComponent } from './components/event/eventSearchForm';
import { WrappedProvinceCreateComponent } from './components/province/provinceCreateForm';
import { WrappedProvinceDetailComponent } from './components/province/provinceDetailForm';
import { WrappedProvinceEditComponent } from './components/province/provinceEditForm';
import { WrappedProvinceSearchComponent } from './components/province/provinceSearchForm';
import { WrappedSaleCreateComponent } from './components/sale/saleCreateForm';
import { WrappedSaleDetailComponent } from './components/sale/saleDetailForm';
import { WrappedSaleEditComponent } from './components/sale/saleEditForm';
import { WrappedSaleSearchComponent } from './components/sale/saleSearchForm';
import { WrappedSaleTicketCreateComponent } from './components/saleTicket/saleTicketCreateForm';
import { WrappedSaleTicketDetailComponent } from './components/saleTicket/saleTicketDetailForm';
import { WrappedSaleTicketEditComponent } from './components/saleTicket/saleTicketEditForm';
import { WrappedSaleTicketSearchComponent } from './components/saleTicket/saleTicketSearchForm';
import { WrappedTicketCreateComponent } from './components/ticket/ticketCreateForm';
import { WrappedTicketDetailComponent } from './components/ticket/ticketDetailForm';
import { WrappedTicketEditComponent } from './components/ticket/ticketEditForm';
import { WrappedTicketSearchComponent } from './components/ticket/ticketSearchForm';
import { WrappedTicketStatusCreateComponent } from './components/ticketStatus/ticketStatusCreateForm';
import { WrappedTicketStatusDetailComponent } from './components/ticketStatus/ticketStatusDetailForm';
import { WrappedTicketStatusEditComponent } from './components/ticketStatus/ticketStatusEditForm';
import { WrappedTicketStatusSearchComponent } from './components/ticketStatus/ticketStatusSearchForm';
import { WrappedTransactionCreateComponent } from './components/transaction/transactionCreateForm';
import { WrappedTransactionDetailComponent } from './components/transaction/transactionDetailForm';
import { WrappedTransactionEditComponent } from './components/transaction/transactionEditForm';
import { WrappedTransactionSearchComponent } from './components/transaction/transactionSearchForm';
import { WrappedTransactionStatusCreateComponent } from './components/transactionStatus/transactionStatusCreateForm';
import { WrappedTransactionStatusDetailComponent } from './components/transactionStatus/transactionStatusDetailForm';
import { WrappedTransactionStatusEditComponent } from './components/transactionStatus/transactionStatusEditForm';
import { WrappedTransactionStatusSearchComponent } from './components/transactionStatus/transactionStatusSearchForm';
import { WrappedVenueCreateComponent } from './components/venue/venueCreateForm';
import { WrappedVenueDetailComponent } from './components/venue/venueDetailForm';
import { WrappedVenueEditComponent } from './components/venue/venueEditForm';
import { WrappedVenueSearchComponent } from './components/venue/venueSearchForm';

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
          path={ClientRoutes.Admins + '/create'}
          component={wrapperHeader(
            WrappedAdminCreateComponent,
            'Admins Create'
          )}
        />
        <Route
          path={ClientRoutes.Admins + '/edit/:id'}
          component={wrapperHeader(WrappedAdminEditComponent, 'Admins Edit')}
        />
        <Route
          path={ClientRoutes.Admins + '/:id'}
          component={wrapperHeader(
            WrappedAdminDetailComponent,
            'Admins Detail'
          )}
        />
        <Route
          path={ClientRoutes.Admins}
          component={wrapperHeader(
            WrappedAdminSearchComponent,
            'Admins Search'
          )}
        />
        <Route
          path={ClientRoutes.Cities + '/create'}
          component={wrapperHeader(WrappedCityCreateComponent, 'Cities Create')}
        />
        <Route
          path={ClientRoutes.Cities + '/edit/:id'}
          component={wrapperHeader(WrappedCityEditComponent, 'Cities Edit')}
        />
        <Route
          path={ClientRoutes.Cities + '/:id'}
          component={wrapperHeader(WrappedCityDetailComponent, 'Cities Detail')}
        />
        <Route
          path={ClientRoutes.Cities}
          component={wrapperHeader(WrappedCitySearchComponent, 'Cities Search')}
        />
        <Route
          path={ClientRoutes.Countries + '/create'}
          component={wrapperHeader(
            WrappedCountryCreateComponent,
            'Countries Create'
          )}
        />
        <Route
          path={ClientRoutes.Countries + '/edit/:id'}
          component={wrapperHeader(
            WrappedCountryEditComponent,
            'Countries Edit'
          )}
        />
        <Route
          path={ClientRoutes.Countries + '/:id'}
          component={wrapperHeader(
            WrappedCountryDetailComponent,
            'Countries Detail'
          )}
        />
        <Route
          path={ClientRoutes.Countries}
          component={wrapperHeader(
            WrappedCountrySearchComponent,
            'Countries Search'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/create'}
          component={wrapperHeader(
            WrappedCustomerCreateComponent,
            'Customers Create'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/edit/:id'}
          component={wrapperHeader(
            WrappedCustomerEditComponent,
            'Customers Edit'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/:id'}
          component={wrapperHeader(
            WrappedCustomerDetailComponent,
            'Customers Detail'
          )}
        />
        <Route
          path={ClientRoutes.Customers}
          component={wrapperHeader(
            WrappedCustomerSearchComponent,
            'Customers Search'
          )}
        />
        <Route
          path={ClientRoutes.Events + '/create'}
          component={wrapperHeader(
            WrappedEventCreateComponent,
            'Events Create'
          )}
        />
        <Route
          path={ClientRoutes.Events + '/edit/:id'}
          component={wrapperHeader(WrappedEventEditComponent, 'Events Edit')}
        />
        <Route
          path={ClientRoutes.Events + '/:id'}
          component={wrapperHeader(
            WrappedEventDetailComponent,
            'Events Detail'
          )}
        />
        <Route
          path={ClientRoutes.Events}
          component={wrapperHeader(
            WrappedEventSearchComponent,
            'Events Search'
          )}
        />
        <Route
          path={ClientRoutes.Provinces + '/create'}
          component={wrapperHeader(
            WrappedProvinceCreateComponent,
            'Provinces Create'
          )}
        />
        <Route
          path={ClientRoutes.Provinces + '/edit/:id'}
          component={wrapperHeader(
            WrappedProvinceEditComponent,
            'Provinces Edit'
          )}
        />
        <Route
          path={ClientRoutes.Provinces + '/:id'}
          component={wrapperHeader(
            WrappedProvinceDetailComponent,
            'Provinces Detail'
          )}
        />
        <Route
          path={ClientRoutes.Provinces}
          component={wrapperHeader(
            WrappedProvinceSearchComponent,
            'Provinces Search'
          )}
        />
        <Route
          path={ClientRoutes.Sales + '/create'}
          component={wrapperHeader(WrappedSaleCreateComponent, 'Sales Create')}
        />
        <Route
          path={ClientRoutes.Sales + '/edit/:id'}
          component={wrapperHeader(WrappedSaleEditComponent, 'Sales Edit')}
        />
        <Route
          path={ClientRoutes.Sales + '/:id'}
          component={wrapperHeader(WrappedSaleDetailComponent, 'Sales Detail')}
        />
        <Route
          path={ClientRoutes.Sales}
          component={wrapperHeader(WrappedSaleSearchComponent, 'Sales Search')}
        />
        <Route
          path={ClientRoutes.SaleTickets + '/create'}
          component={wrapperHeader(
            WrappedSaleTicketCreateComponent,
            'Sale Tickets Create'
          )}
        />
        <Route
          path={ClientRoutes.SaleTickets + '/edit/:id'}
          component={wrapperHeader(
            WrappedSaleTicketEditComponent,
            'Sale Tickets Edit'
          )}
        />
        <Route
          path={ClientRoutes.SaleTickets + '/:id'}
          component={wrapperHeader(
            WrappedSaleTicketDetailComponent,
            'Sale Tickets Detail'
          )}
        />
        <Route
          path={ClientRoutes.SaleTickets}
          component={wrapperHeader(
            WrappedSaleTicketSearchComponent,
            'Sale Tickets Search'
          )}
        />
        <Route
          path={ClientRoutes.Tickets + '/create'}
          component={wrapperHeader(
            WrappedTicketCreateComponent,
            'Tickets Create'
          )}
        />
        <Route
          path={ClientRoutes.Tickets + '/edit/:id'}
          component={wrapperHeader(WrappedTicketEditComponent, 'Tickets Edit')}
        />
        <Route
          path={ClientRoutes.Tickets + '/:id'}
          component={wrapperHeader(
            WrappedTicketDetailComponent,
            'Tickets Detail'
          )}
        />
        <Route
          path={ClientRoutes.Tickets}
          component={wrapperHeader(
            WrappedTicketSearchComponent,
            'Tickets Search'
          )}
        />
        <Route
          path={ClientRoutes.TicketStatus + '/create'}
          component={wrapperHeader(
            WrappedTicketStatusCreateComponent,
            'Ticket Status Create'
          )}
        />
        <Route
          path={ClientRoutes.TicketStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedTicketStatusEditComponent,
            'Ticket Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.TicketStatus + '/:id'}
          component={wrapperHeader(
            WrappedTicketStatusDetailComponent,
            'Ticket Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.TicketStatus}
          component={wrapperHeader(
            WrappedTicketStatusSearchComponent,
            'Ticket Status Search'
          )}
        />
        <Route
          path={ClientRoutes.Transactions + '/create'}
          component={wrapperHeader(
            WrappedTransactionCreateComponent,
            'Transactions Create'
          )}
        />
        <Route
          path={ClientRoutes.Transactions + '/edit/:id'}
          component={wrapperHeader(
            WrappedTransactionEditComponent,
            'Transactions Edit'
          )}
        />
        <Route
          path={ClientRoutes.Transactions + '/:id'}
          component={wrapperHeader(
            WrappedTransactionDetailComponent,
            'Transactions Detail'
          )}
        />
        <Route
          path={ClientRoutes.Transactions}
          component={wrapperHeader(
            WrappedTransactionSearchComponent,
            'Transactions Search'
          )}
        />
        <Route
          path={ClientRoutes.TransactionStatus + '/create'}
          component={wrapperHeader(
            WrappedTransactionStatusCreateComponent,
            'Transaction Status Create'
          )}
        />
        <Route
          path={ClientRoutes.TransactionStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedTransactionStatusEditComponent,
            'Transaction Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.TransactionStatus + '/:id'}
          component={wrapperHeader(
            WrappedTransactionStatusDetailComponent,
            'Transaction Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.TransactionStatus}
          component={wrapperHeader(
            WrappedTransactionStatusSearchComponent,
            'Transaction Status Search'
          )}
        />
        <Route
          path={ClientRoutes.Venues + '/create'}
          component={wrapperHeader(
            WrappedVenueCreateComponent,
            'Venues Create'
          )}
        />
        <Route
          path={ClientRoutes.Venues + '/edit/:id'}
          component={wrapperHeader(WrappedVenueEditComponent, 'Venues Edit')}
        />
        <Route
          path={ClientRoutes.Venues + '/:id'}
          component={wrapperHeader(
            WrappedVenueDetailComponent,
            'Venues Detail'
          )}
        />
        <Route
          path={ClientRoutes.Venues}
          component={wrapperHeader(
            WrappedVenueSearchComponent,
            'Venues Search'
          )}
        />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>576ef3450b89abb3d2ac25b770140e17</Hash>
</Codenesium>*/