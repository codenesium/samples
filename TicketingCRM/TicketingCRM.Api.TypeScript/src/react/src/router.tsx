import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
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
          <Route exact path="/" component={wrapperHeader(Dashboard)} />
          <Route
            path={ClientRoutes.Admins + '/create'}
            component={wrapperHeader(WrappedAdminCreateComponent)}
          />
          <Route
            path={ClientRoutes.Admins + '/edit/:id'}
            component={wrapperHeader(WrappedAdminEditComponent)}
          />
          <Route
            path={ClientRoutes.Admins + '/:id'}
            component={wrapperHeader(WrappedAdminDetailComponent)}
          />
          <Route
            path={ClientRoutes.Admins}
            component={wrapperHeader(WrappedAdminSearchComponent)}
          />
          <Route
            path={ClientRoutes.Cities + '/create'}
            component={wrapperHeader(WrappedCityCreateComponent)}
          />
          <Route
            path={ClientRoutes.Cities + '/edit/:id'}
            component={wrapperHeader(WrappedCityEditComponent)}
          />
          <Route
            path={ClientRoutes.Cities + '/:id'}
            component={wrapperHeader(WrappedCityDetailComponent)}
          />
          <Route
            path={ClientRoutes.Cities}
            component={wrapperHeader(WrappedCitySearchComponent)}
          />
          <Route
            path={ClientRoutes.Countries + '/create'}
            component={wrapperHeader(WrappedCountryCreateComponent)}
          />
          <Route
            path={ClientRoutes.Countries + '/edit/:id'}
            component={wrapperHeader(WrappedCountryEditComponent)}
          />
          <Route
            path={ClientRoutes.Countries + '/:id'}
            component={wrapperHeader(WrappedCountryDetailComponent)}
          />
          <Route
            path={ClientRoutes.Countries}
            component={wrapperHeader(WrappedCountrySearchComponent)}
          />
          <Route
            path={ClientRoutes.Customers + '/create'}
            component={wrapperHeader(WrappedCustomerCreateComponent)}
          />
          <Route
            path={ClientRoutes.Customers + '/edit/:id'}
            component={wrapperHeader(WrappedCustomerEditComponent)}
          />
          <Route
            path={ClientRoutes.Customers + '/:id'}
            component={wrapperHeader(WrappedCustomerDetailComponent)}
          />
          <Route
            path={ClientRoutes.Customers}
            component={wrapperHeader(WrappedCustomerSearchComponent)}
          />
          <Route
            path={ClientRoutes.Events + '/create'}
            component={wrapperHeader(WrappedEventCreateComponent)}
          />
          <Route
            path={ClientRoutes.Events + '/edit/:id'}
            component={wrapperHeader(WrappedEventEditComponent)}
          />
          <Route
            path={ClientRoutes.Events + '/:id'}
            component={wrapperHeader(WrappedEventDetailComponent)}
          />
          <Route
            path={ClientRoutes.Events}
            component={wrapperHeader(WrappedEventSearchComponent)}
          />
          <Route
            path={ClientRoutes.Provinces + '/create'}
            component={wrapperHeader(WrappedProvinceCreateComponent)}
          />
          <Route
            path={ClientRoutes.Provinces + '/edit/:id'}
            component={wrapperHeader(WrappedProvinceEditComponent)}
          />
          <Route
            path={ClientRoutes.Provinces + '/:id'}
            component={wrapperHeader(WrappedProvinceDetailComponent)}
          />
          <Route
            path={ClientRoutes.Provinces}
            component={wrapperHeader(WrappedProvinceSearchComponent)}
          />
          <Route
            path={ClientRoutes.Sales + '/create'}
            component={wrapperHeader(WrappedSaleCreateComponent)}
          />
          <Route
            path={ClientRoutes.Sales + '/edit/:id'}
            component={wrapperHeader(WrappedSaleEditComponent)}
          />
          <Route
            path={ClientRoutes.Sales + '/:id'}
            component={wrapperHeader(WrappedSaleDetailComponent)}
          />
          <Route
            path={ClientRoutes.Sales}
            component={wrapperHeader(WrappedSaleSearchComponent)}
          />
          <Route
            path={ClientRoutes.SaleTickets + '/create'}
            component={wrapperHeader(WrappedSaleTicketCreateComponent)}
          />
          <Route
            path={ClientRoutes.SaleTickets + '/edit/:id'}
            component={wrapperHeader(WrappedSaleTicketEditComponent)}
          />
          <Route
            path={ClientRoutes.SaleTickets + '/:id'}
            component={wrapperHeader(WrappedSaleTicketDetailComponent)}
          />
          <Route
            path={ClientRoutes.SaleTickets}
            component={wrapperHeader(WrappedSaleTicketSearchComponent)}
          />
          <Route
            path={ClientRoutes.Tickets + '/create'}
            component={wrapperHeader(WrappedTicketCreateComponent)}
          />
          <Route
            path={ClientRoutes.Tickets + '/edit/:id'}
            component={wrapperHeader(WrappedTicketEditComponent)}
          />
          <Route
            path={ClientRoutes.Tickets + '/:id'}
            component={wrapperHeader(WrappedTicketDetailComponent)}
          />
          <Route
            path={ClientRoutes.Tickets}
            component={wrapperHeader(WrappedTicketSearchComponent)}
          />
          <Route
            path={ClientRoutes.TicketStatus + '/create'}
            component={wrapperHeader(WrappedTicketStatusCreateComponent)}
          />
          <Route
            path={ClientRoutes.TicketStatus + '/edit/:id'}
            component={wrapperHeader(WrappedTicketStatusEditComponent)}
          />
          <Route
            path={ClientRoutes.TicketStatus + '/:id'}
            component={wrapperHeader(WrappedTicketStatusDetailComponent)}
          />
          <Route
            path={ClientRoutes.TicketStatus}
            component={wrapperHeader(WrappedTicketStatusSearchComponent)}
          />
          <Route
            path={ClientRoutes.Transactions + '/create'}
            component={wrapperHeader(WrappedTransactionCreateComponent)}
          />
          <Route
            path={ClientRoutes.Transactions + '/edit/:id'}
            component={wrapperHeader(WrappedTransactionEditComponent)}
          />
          <Route
            path={ClientRoutes.Transactions + '/:id'}
            component={wrapperHeader(WrappedTransactionDetailComponent)}
          />
          <Route
            path={ClientRoutes.Transactions}
            component={wrapperHeader(WrappedTransactionSearchComponent)}
          />
          <Route
            path={ClientRoutes.TransactionStatus + '/create'}
            component={wrapperHeader(WrappedTransactionStatusCreateComponent)}
          />
          <Route
            path={ClientRoutes.TransactionStatus + '/edit/:id'}
            component={wrapperHeader(WrappedTransactionStatusEditComponent)}
          />
          <Route
            path={ClientRoutes.TransactionStatus + '/:id'}
            component={wrapperHeader(WrappedTransactionStatusDetailComponent)}
          />
          <Route
            path={ClientRoutes.TransactionStatus}
            component={wrapperHeader(WrappedTransactionStatusSearchComponent)}
          />
          <Route
            path={ClientRoutes.Venues + '/create'}
            component={wrapperHeader(WrappedVenueCreateComponent)}
          />
          <Route
            path={ClientRoutes.Venues + '/edit/:id'}
            component={wrapperHeader(WrappedVenueEditComponent)}
          />
          <Route
            path={ClientRoutes.Venues + '/:id'}
            component={wrapperHeader(WrappedVenueDetailComponent)}
          />
          <Route
            path={ClientRoutes.Venues}
            component={wrapperHeader(WrappedVenueSearchComponent)}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>f66320f5f7e57531437d2380fc9391e2</Hash>
</Codenesium>*/