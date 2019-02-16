import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import BreedCreateComponent from './components/breed/breedCreateForm';
import BreedDetailComponent from './components/breed/breedDetailForm';
import BreedEditComponent from './components/breed/breedEditForm';
import BreedSearchComponent from './components/breed/breedSearchForm';
import PaymentTypeCreateComponent from './components/paymentType/paymentTypeCreateForm';
import PaymentTypeDetailComponent from './components/paymentType/paymentTypeDetailForm';
import PaymentTypeEditComponent from './components/paymentType/paymentTypeEditForm';
import PaymentTypeSearchComponent from './components/paymentType/paymentTypeSearchForm';
import PenCreateComponent from './components/pen/penCreateForm';
import PenDetailComponent from './components/pen/penDetailForm';
import PenEditComponent from './components/pen/penEditForm';
import PenSearchComponent from './components/pen/penSearchForm';
import PetCreateComponent from './components/pet/petCreateForm';
import PetDetailComponent from './components/pet/petDetailForm';
import PetEditComponent from './components/pet/petEditForm';
import PetSearchComponent from './components/pet/petSearchForm';
import SaleCreateComponent from './components/sale/saleCreateForm';
import SaleDetailComponent from './components/sale/saleDetailForm';
import SaleEditComponent from './components/sale/saleEditForm';
import SaleSearchComponent from './components/sale/saleSearchForm';
import SpeciesCreateComponent from './components/species/speciesCreateForm';
import SpeciesDetailComponent from './components/species/speciesDetailForm';
import SpeciesEditComponent from './components/species/speciesEditForm';
import SpeciesSearchComponent from './components/species/speciesSearchForm';

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
            <Route path="/breeds/create" component={BreedCreateComponent} />
            <Route path="/breeds/edit/:id" component={BreedEditComponent} />
            <Route path="/breeds/:id" component={BreedDetailComponent} />
            <Route path="/breeds" component={BreedSearchComponent} />
            <Route
              path="/paymenttypes/create"
              component={PaymentTypeCreateComponent}
            />
            <Route
              path="/paymenttypes/edit/:id"
              component={PaymentTypeEditComponent}
            />
            <Route
              path="/paymenttypes/:id"
              component={PaymentTypeDetailComponent}
            />
            <Route
              path="/paymenttypes"
              component={PaymentTypeSearchComponent}
            />
            <Route path="/pens/create" component={PenCreateComponent} />
            <Route path="/pens/edit/:id" component={PenEditComponent} />
            <Route path="/pens/:id" component={PenDetailComponent} />
            <Route path="/pens" component={PenSearchComponent} />
            <Route path="/pets/create" component={PetCreateComponent} />
            <Route path="/pets/edit/:id" component={PetEditComponent} />
            <Route path="/pets/:id" component={PetDetailComponent} />
            <Route path="/pets" component={PetSearchComponent} />
            <Route path="/sales/create" component={SaleCreateComponent} />
            <Route path="/sales/edit/:id" component={SaleEditComponent} />
            <Route path="/sales/:id" component={SaleDetailComponent} />
            <Route path="/sales" component={SaleSearchComponent} />
            <Route path="/species/create" component={SpeciesCreateComponent} />
            <Route path="/species/edit/:id" component={SpeciesEditComponent} />
            <Route path="/species/:id" component={SpeciesDetailComponent} />
            <Route path="/species" component={SpeciesSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>ef13c50c9c35dfaf2cf748b993015759</Hash>
</Codenesium>*/