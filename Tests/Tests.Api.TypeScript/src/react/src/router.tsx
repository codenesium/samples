import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import ColumnSameAsFKTableCreateComponent from './components/columnSameAsFKTable/columnSameAsFKTableCreateForm';
import ColumnSameAsFKTableDetailComponent from './components/columnSameAsFKTable/columnSameAsFKTableDetailForm';
import ColumnSameAsFKTableEditComponent from './components/columnSameAsFKTable/columnSameAsFKTableEditForm';
import ColumnSameAsFKTableSearchComponent from './components/columnSameAsFKTable/columnSameAsFKTableSearchForm';
import IncludedColumnTestCreateComponent from './components/includedColumnTest/includedColumnTestCreateForm';
import IncludedColumnTestDetailComponent from './components/includedColumnTest/includedColumnTestDetailForm';
import IncludedColumnTestEditComponent from './components/includedColumnTest/includedColumnTestEditForm';
import IncludedColumnTestSearchComponent from './components/includedColumnTest/includedColumnTestSearchForm';
import PersonCreateComponent from './components/person/personCreateForm';
import PersonDetailComponent from './components/person/personDetailForm';
import PersonEditComponent from './components/person/personEditForm';
import PersonSearchComponent from './components/person/personSearchForm';
import RowVersionCheckCreateComponent from './components/rowVersionCheck/rowVersionCheckCreateForm';
import RowVersionCheckDetailComponent from './components/rowVersionCheck/rowVersionCheckDetailForm';
import RowVersionCheckEditComponent from './components/rowVersionCheck/rowVersionCheckEditForm';
import RowVersionCheckSearchComponent from './components/rowVersionCheck/rowVersionCheckSearchForm';
import SelfReferenceCreateComponent from './components/selfReference/selfReferenceCreateForm';
import SelfReferenceDetailComponent from './components/selfReference/selfReferenceDetailForm';
import SelfReferenceEditComponent from './components/selfReference/selfReferenceEditForm';
import SelfReferenceSearchComponent from './components/selfReference/selfReferenceSearchForm';
import TableCreateComponent from './components/table/tableCreateForm';
import TableDetailComponent from './components/table/tableDetailForm';
import TableEditComponent from './components/table/tableEditForm';
import TableSearchComponent from './components/table/tableSearchForm';
import TestAllFieldTypeCreateComponent from './components/testAllFieldType/testAllFieldTypeCreateForm';
import TestAllFieldTypeDetailComponent from './components/testAllFieldType/testAllFieldTypeDetailForm';
import TestAllFieldTypeEditComponent from './components/testAllFieldType/testAllFieldTypeEditForm';
import TestAllFieldTypeSearchComponent from './components/testAllFieldType/testAllFieldTypeSearchForm';
import TestAllFieldTypesNullableCreateComponent from './components/testAllFieldTypesNullable/testAllFieldTypesNullableCreateForm';
import TestAllFieldTypesNullableDetailComponent from './components/testAllFieldTypesNullable/testAllFieldTypesNullableDetailForm';
import TestAllFieldTypesNullableEditComponent from './components/testAllFieldTypesNullable/testAllFieldTypesNullableEditForm';
import TestAllFieldTypesNullableSearchComponent from './components/testAllFieldTypesNullable/testAllFieldTypesNullableSearchForm';
import TimestampCheckCreateComponent from './components/timestampCheck/timestampCheckCreateForm';
import TimestampCheckDetailComponent from './components/timestampCheck/timestampCheckDetailForm';
import TimestampCheckEditComponent from './components/timestampCheck/timestampCheckEditForm';
import TimestampCheckSearchComponent from './components/timestampCheck/timestampCheckSearchForm';
import VPersonCreateComponent from './components/vPerson/vPersonCreateForm';
import VPersonDetailComponent from './components/vPerson/vPersonDetailForm';
import VPersonEditComponent from './components/vPerson/vPersonEditForm';
import VPersonSearchComponent from './components/vPerson/vPersonSearchForm';

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
            <Route
              path="/columnsameasfktables/create"
              component={ColumnSameAsFKTableCreateComponent}
            />
            <Route
              path="/columnsameasfktables/edit/:id"
              component={ColumnSameAsFKTableEditComponent}
            />
            <Route
              path="/columnsameasfktables/:id"
              component={ColumnSameAsFKTableDetailComponent}
            />
            <Route
              path="/columnsameasfktables"
              component={ColumnSameAsFKTableSearchComponent}
            />
            <Route
              path="/includedcolumntests/create"
              component={IncludedColumnTestCreateComponent}
            />
            <Route
              path="/includedcolumntests/edit/:id"
              component={IncludedColumnTestEditComponent}
            />
            <Route
              path="/includedcolumntests/:id"
              component={IncludedColumnTestDetailComponent}
            />
            <Route
              path="/includedcolumntests"
              component={IncludedColumnTestSearchComponent}
            />
            <Route path="/people/create" component={PersonCreateComponent} />
            <Route path="/people/edit/:id" component={PersonEditComponent} />
            <Route path="/people/:id" component={PersonDetailComponent} />
            <Route path="/people" component={PersonSearchComponent} />
            <Route
              path="/rowversionchecks/create"
              component={RowVersionCheckCreateComponent}
            />
            <Route
              path="/rowversionchecks/edit/:id"
              component={RowVersionCheckEditComponent}
            />
            <Route
              path="/rowversionchecks/:id"
              component={RowVersionCheckDetailComponent}
            />
            <Route
              path="/rowversionchecks"
              component={RowVersionCheckSearchComponent}
            />
            <Route
              path="/selfreferences/create"
              component={SelfReferenceCreateComponent}
            />
            <Route
              path="/selfreferences/edit/:id"
              component={SelfReferenceEditComponent}
            />
            <Route
              path="/selfreferences/:id"
              component={SelfReferenceDetailComponent}
            />
            <Route
              path="/selfreferences"
              component={SelfReferenceSearchComponent}
            />
            <Route path="/tables/create" component={TableCreateComponent} />
            <Route path="/tables/edit/:id" component={TableEditComponent} />
            <Route path="/tables/:id" component={TableDetailComponent} />
            <Route path="/tables" component={TableSearchComponent} />
            <Route
              path="/testallfieldtypes/create"
              component={TestAllFieldTypeCreateComponent}
            />
            <Route
              path="/testallfieldtypes/edit/:id"
              component={TestAllFieldTypeEditComponent}
            />
            <Route
              path="/testallfieldtypes/:id"
              component={TestAllFieldTypeDetailComponent}
            />
            <Route
              path="/testallfieldtypes"
              component={TestAllFieldTypeSearchComponent}
            />
            <Route
              path="/testallfieldtypesnullables/create"
              component={TestAllFieldTypesNullableCreateComponent}
            />
            <Route
              path="/testallfieldtypesnullables/edit/:id"
              component={TestAllFieldTypesNullableEditComponent}
            />
            <Route
              path="/testallfieldtypesnullables/:id"
              component={TestAllFieldTypesNullableDetailComponent}
            />
            <Route
              path="/testallfieldtypesnullables"
              component={TestAllFieldTypesNullableSearchComponent}
            />
            <Route
              path="/timestampchecks/create"
              component={TimestampCheckCreateComponent}
            />
            <Route
              path="/timestampchecks/edit/:id"
              component={TimestampCheckEditComponent}
            />
            <Route
              path="/timestampchecks/:id"
              component={TimestampCheckDetailComponent}
            />
            <Route
              path="/timestampchecks"
              component={TimestampCheckSearchComponent}
            />
            <Route path="/vpersons/create" component={VPersonCreateComponent} />
            <Route path="/vpersons/edit/:id" component={VPersonEditComponent} />
            <Route path="/vpersons/:id" component={VPersonDetailComponent} />
            <Route path="/vpersons" component={VPersonSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>13d494a765adb4b6bb4db39da4365771</Hash>
</Codenesium>*/