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
          <Route
            exact
            path="/"
            component={wrapperHeader(Dashboard, 'Dashboard')}
          />
          <Route
            path={ClientRoutes.Breeds + '/create'}
            component={wrapperHeader(
              WrappedBreedCreateComponent,
              'Breeds Create'
            )}
          />
          <Route
            path={ClientRoutes.Breeds + '/edit/:id'}
            component={wrapperHeader(WrappedBreedEditComponent, 'Breeds Edit')}
          />
          <Route
            path={ClientRoutes.Breeds + '/:id'}
            component={wrapperHeader(
              WrappedBreedDetailComponent,
              'Breeds Detail'
            )}
          />
          <Route
            path={ClientRoutes.Breeds}
            component={wrapperHeader(
              WrappedBreedSearchComponent,
              'Breeds Search'
            )}
          />
          <Route
            path={ClientRoutes.PaymentTypes + '/create'}
            component={wrapperHeader(
              WrappedPaymentTypeCreateComponent,
              'Payment Types Create'
            )}
          />
          <Route
            path={ClientRoutes.PaymentTypes + '/edit/:id'}
            component={wrapperHeader(
              WrappedPaymentTypeEditComponent,
              'Payment Types Edit'
            )}
          />
          <Route
            path={ClientRoutes.PaymentTypes + '/:id'}
            component={wrapperHeader(
              WrappedPaymentTypeDetailComponent,
              'Payment Types Detail'
            )}
          />
          <Route
            path={ClientRoutes.PaymentTypes}
            component={wrapperHeader(
              WrappedPaymentTypeSearchComponent,
              'Payment Types Search'
            )}
          />
          <Route
            path={ClientRoutes.Pens + '/create'}
            component={wrapperHeader(WrappedPenCreateComponent, 'Pens Create')}
          />
          <Route
            path={ClientRoutes.Pens + '/edit/:id'}
            component={wrapperHeader(WrappedPenEditComponent, 'Pens Edit')}
          />
          <Route
            path={ClientRoutes.Pens + '/:id'}
            component={wrapperHeader(WrappedPenDetailComponent, 'Pens Detail')}
          />
          <Route
            path={ClientRoutes.Pens}
            component={wrapperHeader(WrappedPenSearchComponent, 'Pens Search')}
          />
          <Route
            path={ClientRoutes.Pets + '/create'}
            component={wrapperHeader(WrappedPetCreateComponent, 'Pets Create')}
          />
          <Route
            path={ClientRoutes.Pets + '/edit/:id'}
            component={wrapperHeader(WrappedPetEditComponent, 'Pets Edit')}
          />
          <Route
            path={ClientRoutes.Pets + '/:id'}
            component={wrapperHeader(WrappedPetDetailComponent, 'Pets Detail')}
          />
          <Route
            path={ClientRoutes.Pets}
            component={wrapperHeader(WrappedPetSearchComponent, 'Pets Search')}
          />
          <Route
            path={ClientRoutes.Sales + '/create'}
            component={wrapperHeader(
              WrappedSaleCreateComponent,
              'Sales Create'
            )}
          />
          <Route
            path={ClientRoutes.Sales + '/edit/:id'}
            component={wrapperHeader(WrappedSaleEditComponent, 'Sales Edit')}
          />
          <Route
            path={ClientRoutes.Sales + '/:id'}
            component={wrapperHeader(
              WrappedSaleDetailComponent,
              'Sales Detail'
            )}
          />
          <Route
            path={ClientRoutes.Sales}
            component={wrapperHeader(
              WrappedSaleSearchComponent,
              'Sales Search'
            )}
          />
          <Route
            path={ClientRoutes.Species + '/create'}
            component={wrapperHeader(
              WrappedSpeciesCreateComponent,
              'Species Create'
            )}
          />
          <Route
            path={ClientRoutes.Species + '/edit/:id'}
            component={wrapperHeader(
              WrappedSpeciesEditComponent,
              'Species Edit'
            )}
          />
          <Route
            path={ClientRoutes.Species + '/:id'}
            component={wrapperHeader(
              WrappedSpeciesDetailComponent,
              'Species Detail'
            )}
          />
          <Route
            path={ClientRoutes.Species}
            component={wrapperHeader(
              WrappedSpeciesSearchComponent,
              'Species Search'
            )}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>8f0f864b25c97d30207a2f74e89f021f</Hash>
</Codenesium>*/