import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedBreedCreateComponent } from './components/breed/breedCreateForm';
import { WrappedBreedDetailComponent } from './components/breed/breedDetailForm';
import { WrappedBreedEditComponent } from './components/breed/breedEditForm';
import { WrappedBreedSearchComponent } from './components/breed/breedSearchForm';					
import { WrappedPaymentTypeCreateComponent } from './components/paymentType/paymentTypeCreateForm';
import { WrappedPaymentTypeDetailComponent } from './components/paymentType/paymentTypeDetailForm';
import { WrappedPaymentTypeEditComponent } from './components/paymentType/paymentTypeEditForm';
import { WrappedPaymentTypeSearchComponent } from './components/paymentType/paymentTypeSearchForm';					
import { WrappedPenCreateComponent } from './components/pen/penCreateForm';
import { WrappedPenDetailComponent } from './components/pen/penDetailForm';
import { WrappedPenEditComponent } from './components/pen/penEditForm';
import { WrappedPenSearchComponent } from './components/pen/penSearchForm';					
import { WrappedPetCreateComponent } from './components/pet/petCreateForm';
import { WrappedPetDetailComponent } from './components/pet/petDetailForm';
import { WrappedPetEditComponent } from './components/pet/petEditForm';
import { WrappedPetSearchComponent } from './components/pet/petSearchForm';					
import { WrappedSaleCreateComponent } from './components/sale/saleCreateForm';
import { WrappedSaleDetailComponent } from './components/sale/saleDetailForm';
import { WrappedSaleEditComponent } from './components/sale/saleEditForm';
import { WrappedSaleSearchComponent } from './components/sale/saleSearchForm';					
import { WrappedSpeciesCreateComponent } from './components/species/speciesCreateForm';
import { WrappedSpeciesDetailComponent } from './components/species/speciesDetailForm';
import { WrappedSpeciesEditComponent } from './components/species/speciesEditForm';
import { WrappedSpeciesSearchComponent } from './components/species/speciesSearchForm';					

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  }
}

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search)

  return (
    <BrowserRouter>   
	<Security issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}>
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard, "Dashboard")} />
		  <Route path={ClientRoutes.Breeds + "/create"} component={wrapperHeader(WrappedBreedCreateComponent, "Breed Create")} />
                      <Route path={ClientRoutes.Breeds + "/edit/:id"} component={wrapperHeader(WrappedBreedEditComponent, "Breed Edit")} />
                      <Route path={ClientRoutes.Breeds + "/:id"} component={wrapperHeader(WrappedBreedDetailComponent , "Breed Detail")} />
                      <Route path={ClientRoutes.Breeds} component={wrapperHeader(WrappedBreedSearchComponent, "Breed Search")} />
					<Route path={ClientRoutes.PaymentTypes + "/create"} component={wrapperHeader(WrappedPaymentTypeCreateComponent, "PaymentType Create")} />
                      <Route path={ClientRoutes.PaymentTypes + "/edit/:id"} component={wrapperHeader(WrappedPaymentTypeEditComponent, "PaymentType Edit")} />
                      <Route path={ClientRoutes.PaymentTypes + "/:id"} component={wrapperHeader(WrappedPaymentTypeDetailComponent , "PaymentType Detail")} />
                      <Route path={ClientRoutes.PaymentTypes} component={wrapperHeader(WrappedPaymentTypeSearchComponent, "PaymentType Search")} />
					<Route path={ClientRoutes.Pens + "/create"} component={wrapperHeader(WrappedPenCreateComponent, "Pen Create")} />
                      <Route path={ClientRoutes.Pens + "/edit/:id"} component={wrapperHeader(WrappedPenEditComponent, "Pen Edit")} />
                      <Route path={ClientRoutes.Pens + "/:id"} component={wrapperHeader(WrappedPenDetailComponent , "Pen Detail")} />
                      <Route path={ClientRoutes.Pens} component={wrapperHeader(WrappedPenSearchComponent, "Pen Search")} />
					<Route path={ClientRoutes.Pets + "/create"} component={wrapperHeader(WrappedPetCreateComponent, "Pet Create")} />
                      <Route path={ClientRoutes.Pets + "/edit/:id"} component={wrapperHeader(WrappedPetEditComponent, "Pet Edit")} />
                      <Route path={ClientRoutes.Pets + "/:id"} component={wrapperHeader(WrappedPetDetailComponent , "Pet Detail")} />
                      <Route path={ClientRoutes.Pets} component={wrapperHeader(WrappedPetSearchComponent, "Pet Search")} />
					<Route path={ClientRoutes.Sales + "/create"} component={wrapperHeader(WrappedSaleCreateComponent, "Sale Create")} />
                      <Route path={ClientRoutes.Sales + "/edit/:id"} component={wrapperHeader(WrappedSaleEditComponent, "Sale Edit")} />
                      <Route path={ClientRoutes.Sales + "/:id"} component={wrapperHeader(WrappedSaleDetailComponent , "Sale Detail")} />
                      <Route path={ClientRoutes.Sales} component={wrapperHeader(WrappedSaleSearchComponent, "Sale Search")} />
					<Route path={ClientRoutes.Species + "/create"} component={wrapperHeader(WrappedSpeciesCreateComponent, "Species Create")} />
                      <Route path={ClientRoutes.Species + "/edit/:id"} component={wrapperHeader(WrappedSpeciesEditComponent, "Species Edit")} />
                      <Route path={ClientRoutes.Species + "/:id"} component={wrapperHeader(WrappedSpeciesDetailComponent , "Species Detail")} />
                      <Route path={ClientRoutes.Species} component={wrapperHeader(WrappedSpeciesSearchComponent, "Species Search")} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>fee3b02b9dca69c08acae5ae440e8c32</Hash>
</Codenesium>*/