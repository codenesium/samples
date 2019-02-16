import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import BucketCreateComponent from './components/bucket/bucketCreateForm';
import BucketDetailComponent from './components/bucket/bucketDetailForm';
import BucketEditComponent from './components/bucket/bucketEditForm';
import BucketSearchComponent from './components/bucket/bucketSearchForm';
import FileCreateComponent from './components/file/fileCreateForm';
import FileDetailComponent from './components/file/fileDetailForm';
import FileEditComponent from './components/file/fileEditForm';
import FileSearchComponent from './components/file/fileSearchForm';
import FileTypeCreateComponent from './components/fileType/fileTypeCreateForm';
import FileTypeDetailComponent from './components/fileType/fileTypeDetailForm';
import FileTypeEditComponent from './components/fileType/fileTypeEditForm';
import FileTypeSearchComponent from './components/fileType/fileTypeSearchForm';

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
            <Route path="/buckets/create" component={BucketCreateComponent} />
            <Route path="/buckets/edit/:id" component={BucketEditComponent} />
            <Route path="/buckets/:id" component={BucketDetailComponent} />
            <Route path="/buckets" component={BucketSearchComponent} />
            <Route path="/files/create" component={FileCreateComponent} />
            <Route path="/files/edit/:id" component={FileEditComponent} />
            <Route path="/files/:id" component={FileDetailComponent} />
            <Route path="/files" component={FileSearchComponent} />
            <Route
              path="/filetypes/create"
              component={FileTypeCreateComponent}
            />
            <Route
              path="/filetypes/edit/:id"
              component={FileTypeEditComponent}
            />
            <Route path="/filetypes/:id" component={FileTypeDetailComponent} />
            <Route path="/filetypes" component={FileTypeSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>6a13c1737da4f7e40a674e9af34d3eec</Hash>
</Codenesium>*/