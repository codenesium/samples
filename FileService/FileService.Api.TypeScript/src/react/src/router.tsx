import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
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

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  },
};

export const AppRouter: React.StatelessComponent<{}> = () => {
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
            path={ClientRoutes.Buckets + '/create'}
            component={wrapperHeader(
              WrappedBucketCreateComponent,
              'Buckets Create'
            )}
          />
          <Route
            path={ClientRoutes.Buckets + '/edit/:id'}
            component={wrapperHeader(
              WrappedBucketEditComponent,
              'Buckets Edit'
            )}
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
            component={wrapperHeader(
              WrappedFileCreateComponent,
              'Files Create'
            )}
          />
          <Route
            path={ClientRoutes.Files + '/edit/:id'}
            component={wrapperHeader(WrappedFileEditComponent, 'Files Edit')}
          />
          <Route
            path={ClientRoutes.Files + '/:id'}
            component={wrapperHeader(
              WrappedFileDetailComponent,
              'Files Detail'
            )}
          />
          <Route
            path={ClientRoutes.Files}
            component={wrapperHeader(
              WrappedFileSearchComponent,
              'Files Search'
            )}
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
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>80d86be552e7426e42123ff75dfd56e4</Hash>
</Codenesium>*/