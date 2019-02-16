import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import AdminCreateComponent from './components/admin/adminCreateForm';
import AdminDetailComponent from './components/admin/adminDetailForm';
import AdminEditComponent from './components/admin/adminEditForm';
import AdminSearchComponent from './components/admin/adminSearchForm';
import CityCreateComponent from './components/city/cityCreateForm';
import CityDetailComponent from './components/city/cityDetailForm';
import CityEditComponent from './components/city/cityEditForm';
import CitySearchComponent from './components/city/citySearchForm';
import CountryCreateComponent from './components/country/countryCreateForm';
import CountryDetailComponent from './components/country/countryDetailForm';
import CountryEditComponent from './components/country/countryEditForm';
import CountrySearchComponent from './components/country/countrySearchForm';
import CustomerCreateComponent from './components/customer/customerCreateForm';
import CustomerDetailComponent from './components/customer/customerDetailForm';
import CustomerEditComponent from './components/customer/customerEditForm';
import CustomerSearchComponent from './components/customer/customerSearchForm';
import EventCreateComponent from './components/event/eventCreateForm';
import EventDetailComponent from './components/event/eventDetailForm';
import EventEditComponent from './components/event/eventEditForm';
import EventSearchComponent from './components/event/eventSearchForm';
import ProvinceCreateComponent from './components/province/provinceCreateForm';
import ProvinceDetailComponent from './components/province/provinceDetailForm';
import ProvinceEditComponent from './components/province/provinceEditForm';
import ProvinceSearchComponent from './components/province/provinceSearchForm';
import SaleCreateComponent from './components/sale/saleCreateForm';
import SaleDetailComponent from './components/sale/saleDetailForm';
import SaleEditComponent from './components/sale/saleEditForm';
import SaleSearchComponent from './components/sale/saleSearchForm';
import SaleTicketCreateComponent from './components/saleTicket/saleTicketCreateForm';
import SaleTicketDetailComponent from './components/saleTicket/saleTicketDetailForm';
import SaleTicketEditComponent from './components/saleTicket/saleTicketEditForm';
import SaleTicketSearchComponent from './components/saleTicket/saleTicketSearchForm';
import TicketCreateComponent from './components/ticket/ticketCreateForm';
import TicketDetailComponent from './components/ticket/ticketDetailForm';
import TicketEditComponent from './components/ticket/ticketEditForm';
import TicketSearchComponent from './components/ticket/ticketSearchForm';
import TicketStatuCreateComponent from './components/ticketStatu/ticketStatuCreateForm';
import TicketStatuDetailComponent from './components/ticketStatu/ticketStatuDetailForm';
import TicketStatuEditComponent from './components/ticketStatu/ticketStatuEditForm';
import TicketStatuSearchComponent from './components/ticketStatu/ticketStatuSearchForm';
import TransactionCreateComponent from './components/transaction/transactionCreateForm';
import TransactionDetailComponent from './components/transaction/transactionDetailForm';
import TransactionEditComponent from './components/transaction/transactionEditForm';
import TransactionSearchComponent from './components/transaction/transactionSearchForm';
import TransactionStatuCreateComponent from './components/transactionStatu/transactionStatuCreateForm';
import TransactionStatuDetailComponent from './components/transactionStatu/transactionStatuDetailForm';
import TransactionStatuEditComponent from './components/transactionStatu/transactionStatuEditForm';
import TransactionStatuSearchComponent from './components/transactionStatu/transactionStatuSearchForm';
import VenueCreateComponent from './components/venue/venueCreateForm';
import VenueDetailComponent from './components/venue/venueDetailForm';
import VenueEditComponent from './components/venue/venueEditForm';
import VenueSearchComponent from './components/venue/venueSearchForm';

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
        <div className="container-fluid">
          <Route component={App} />
          <SecureRoute
            path="/protected"
            component={() => '<div>secure route</div>'}
          />
          <Switch>
            <Route exact path="/" component={Dashboard} />
            <Route path="/admins/create" component={AdminCreateComponent} />
            <Route path="/admins/edit/:id" component={AdminEditComponent} />
            <Route path="/admins/:id" component={AdminDetailComponent} />
            <Route path="/admins" component={AdminSearchComponent} />
            <Route path="/cities/create" component={CityCreateComponent} />
            <Route path="/cities/edit/:id" component={CityEditComponent} />
            <Route path="/cities/:id" component={CityDetailComponent} />
            <Route path="/cities" component={CitySearchComponent} />
            <Route
              path="/countries/create"
              component={CountryCreateComponent}
            />
            <Route
              path="/countries/edit/:id"
              component={CountryEditComponent}
            />
            <Route path="/countries/:id" component={CountryDetailComponent} />
            <Route path="/countries" component={CountrySearchComponent} />
            <Route
              path="/customers/create"
              component={CustomerCreateComponent}
            />
            <Route
              path="/customers/edit/:id"
              component={CustomerEditComponent}
            />
            <Route path="/customers/:id" component={CustomerDetailComponent} />
            <Route path="/customers" component={CustomerSearchComponent} />
            <Route path="/events/create" component={EventCreateComponent} />
            <Route path="/events/edit/:id" component={EventEditComponent} />
            <Route path="/events/:id" component={EventDetailComponent} />
            <Route path="/events" component={EventSearchComponent} />
            <Route
              path="/provinces/create"
              component={ProvinceCreateComponent}
            />
            <Route
              path="/provinces/edit/:id"
              component={ProvinceEditComponent}
            />
            <Route path="/provinces/:id" component={ProvinceDetailComponent} />
            <Route path="/provinces" component={ProvinceSearchComponent} />
            <Route path="/sales/create" component={SaleCreateComponent} />
            <Route path="/sales/edit/:id" component={SaleEditComponent} />
            <Route path="/sales/:id" component={SaleDetailComponent} />
            <Route path="/sales" component={SaleSearchComponent} />
            <Route
              path="/saletickets/create"
              component={SaleTicketCreateComponent}
            />
            <Route
              path="/saletickets/edit/:id"
              component={SaleTicketEditComponent}
            />
            <Route
              path="/saletickets/:id"
              component={SaleTicketDetailComponent}
            />
            <Route path="/saletickets" component={SaleTicketSearchComponent} />
            <Route path="/tickets/create" component={TicketCreateComponent} />
            <Route path="/tickets/edit/:id" component={TicketEditComponent} />
            <Route path="/tickets/:id" component={TicketDetailComponent} />
            <Route path="/tickets" component={TicketSearchComponent} />
            <Route
              path="/ticketstatus/create"
              component={TicketStatuCreateComponent}
            />
            <Route
              path="/ticketstatus/edit/:id"
              component={TicketStatuEditComponent}
            />
            <Route
              path="/ticketstatus/:id"
              component={TicketStatuDetailComponent}
            />
            <Route
              path="/ticketstatus"
              component={TicketStatuSearchComponent}
            />
            <Route
              path="/transactions/create"
              component={TransactionCreateComponent}
            />
            <Route
              path="/transactions/edit/:id"
              component={TransactionEditComponent}
            />
            <Route
              path="/transactions/:id"
              component={TransactionDetailComponent}
            />
            <Route
              path="/transactions"
              component={TransactionSearchComponent}
            />
            <Route
              path="/transactionstatus/create"
              component={TransactionStatuCreateComponent}
            />
            <Route
              path="/transactionstatus/edit/:id"
              component={TransactionStatuEditComponent}
            />
            <Route
              path="/transactionstatus/:id"
              component={TransactionStatuDetailComponent}
            />
            <Route
              path="/transactionstatus"
              component={TransactionStatuSearchComponent}
            />
            <Route path="/venues/create" component={VenueCreateComponent} />
            <Route path="/venues/edit/:id" component={VenueEditComponent} />
            <Route path="/venues/:id" component={VenueDetailComponent} />
            <Route path="/venues" component={VenueSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>52ecaa64a41ea7c5aceee1e54b1340ca</Hash>
</Codenesium>*/