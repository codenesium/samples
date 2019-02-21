import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedColumnSameAsFKTableCreateComponent } from './components/columnSameAsFKTable/columnSameAsFKTableCreateForm';
import { WrappedColumnSameAsFKTableDetailComponent } from './components/columnSameAsFKTable/columnSameAsFKTableDetailForm';
import { WrappedColumnSameAsFKTableEditComponent } from './components/columnSameAsFKTable/columnSameAsFKTableEditForm';
import { WrappedColumnSameAsFKTableSearchComponent } from './components/columnSameAsFKTable/columnSameAsFKTableSearchForm';					
import { WrappedIncludedColumnTestCreateComponent } from './components/includedColumnTest/includedColumnTestCreateForm';
import { WrappedIncludedColumnTestDetailComponent } from './components/includedColumnTest/includedColumnTestDetailForm';
import { WrappedIncludedColumnTestEditComponent } from './components/includedColumnTest/includedColumnTestEditForm';
import { WrappedIncludedColumnTestSearchComponent } from './components/includedColumnTest/includedColumnTestSearchForm';					
import { WrappedPersonCreateComponent } from './components/person/personCreateForm';
import { WrappedPersonDetailComponent } from './components/person/personDetailForm';
import { WrappedPersonEditComponent } from './components/person/personEditForm';
import { WrappedPersonSearchComponent } from './components/person/personSearchForm';					
import { WrappedRowVersionCheckCreateComponent } from './components/rowVersionCheck/rowVersionCheckCreateForm';
import { WrappedRowVersionCheckDetailComponent } from './components/rowVersionCheck/rowVersionCheckDetailForm';
import { WrappedRowVersionCheckEditComponent } from './components/rowVersionCheck/rowVersionCheckEditForm';
import { WrappedRowVersionCheckSearchComponent } from './components/rowVersionCheck/rowVersionCheckSearchForm';					
import { WrappedSelfReferenceCreateComponent } from './components/selfReference/selfReferenceCreateForm';
import { WrappedSelfReferenceDetailComponent } from './components/selfReference/selfReferenceDetailForm';
import { WrappedSelfReferenceEditComponent } from './components/selfReference/selfReferenceEditForm';
import { WrappedSelfReferenceSearchComponent } from './components/selfReference/selfReferenceSearchForm';					
import { WrappedTableCreateComponent } from './components/table/tableCreateForm';
import { WrappedTableDetailComponent } from './components/table/tableDetailForm';
import { WrappedTableEditComponent } from './components/table/tableEditForm';
import { WrappedTableSearchComponent } from './components/table/tableSearchForm';					
import { WrappedTestAllFieldTypeCreateComponent } from './components/testAllFieldType/testAllFieldTypeCreateForm';
import { WrappedTestAllFieldTypeDetailComponent } from './components/testAllFieldType/testAllFieldTypeDetailForm';
import { WrappedTestAllFieldTypeEditComponent } from './components/testAllFieldType/testAllFieldTypeEditForm';
import { WrappedTestAllFieldTypeSearchComponent } from './components/testAllFieldType/testAllFieldTypeSearchForm';					
import { WrappedTestAllFieldTypesNullableCreateComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableCreateForm';
import { WrappedTestAllFieldTypesNullableDetailComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableDetailForm';
import { WrappedTestAllFieldTypesNullableEditComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableEditForm';
import { WrappedTestAllFieldTypesNullableSearchComponent } from './components/testAllFieldTypesNullable/testAllFieldTypesNullableSearchForm';					
import { WrappedTimestampCheckCreateComponent } from './components/timestampCheck/timestampCheckCreateForm';
import { WrappedTimestampCheckDetailComponent } from './components/timestampCheck/timestampCheckDetailForm';
import { WrappedTimestampCheckEditComponent } from './components/timestampCheck/timestampCheckEditForm';
import { WrappedTimestampCheckSearchComponent } from './components/timestampCheck/timestampCheckSearchForm';					
import { WrappedVPersonCreateComponent } from './components/vPerson/vPersonCreateForm';
import { WrappedVPersonDetailComponent } from './components/vPerson/vPersonDetailForm';
import { WrappedVPersonEditComponent } from './components/vPerson/vPersonEditForm';
import { WrappedVPersonSearchComponent } from './components/vPerson/vPersonSearchForm';					

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
          <Route exact path="/" component={wrapperHeader(Dashboard)} />
		  <Route path={ClientRoutes.ColumnSameAsFKTables + "/create"} component={wrapperHeader(WrappedColumnSameAsFKTableCreateComponent)} />
                      <Route path={ClientRoutes.ColumnSameAsFKTables + "/edit/:id"} component={wrapperHeader(WrappedColumnSameAsFKTableEditComponent)} />
                      <Route path={ClientRoutes.ColumnSameAsFKTables + "/:id"} component={wrapperHeader(WrappedColumnSameAsFKTableDetailComponent)} />
                      <Route path={ClientRoutes.ColumnSameAsFKTables} component={wrapperHeader(WrappedColumnSameAsFKTableSearchComponent)} />
					<Route path={ClientRoutes.IncludedColumnTests + "/create"} component={wrapperHeader(WrappedIncludedColumnTestCreateComponent)} />
                      <Route path={ClientRoutes.IncludedColumnTests + "/edit/:id"} component={wrapperHeader(WrappedIncludedColumnTestEditComponent)} />
                      <Route path={ClientRoutes.IncludedColumnTests + "/:id"} component={wrapperHeader(WrappedIncludedColumnTestDetailComponent)} />
                      <Route path={ClientRoutes.IncludedColumnTests} component={wrapperHeader(WrappedIncludedColumnTestSearchComponent)} />
					<Route path={ClientRoutes.People + "/create"} component={wrapperHeader(WrappedPersonCreateComponent)} />
                      <Route path={ClientRoutes.People + "/edit/:id"} component={wrapperHeader(WrappedPersonEditComponent)} />
                      <Route path={ClientRoutes.People + "/:id"} component={wrapperHeader(WrappedPersonDetailComponent)} />
                      <Route path={ClientRoutes.People} component={wrapperHeader(WrappedPersonSearchComponent)} />
					<Route path={ClientRoutes.RowVersionChecks + "/create"} component={wrapperHeader(WrappedRowVersionCheckCreateComponent)} />
                      <Route path={ClientRoutes.RowVersionChecks + "/edit/:id"} component={wrapperHeader(WrappedRowVersionCheckEditComponent)} />
                      <Route path={ClientRoutes.RowVersionChecks + "/:id"} component={wrapperHeader(WrappedRowVersionCheckDetailComponent)} />
                      <Route path={ClientRoutes.RowVersionChecks} component={wrapperHeader(WrappedRowVersionCheckSearchComponent)} />
					<Route path={ClientRoutes.SelfReferences + "/create"} component={wrapperHeader(WrappedSelfReferenceCreateComponent)} />
                      <Route path={ClientRoutes.SelfReferences + "/edit/:id"} component={wrapperHeader(WrappedSelfReferenceEditComponent)} />
                      <Route path={ClientRoutes.SelfReferences + "/:id"} component={wrapperHeader(WrappedSelfReferenceDetailComponent)} />
                      <Route path={ClientRoutes.SelfReferences} component={wrapperHeader(WrappedSelfReferenceSearchComponent)} />
					<Route path={ClientRoutes.Tables + "/create"} component={wrapperHeader(WrappedTableCreateComponent)} />
                      <Route path={ClientRoutes.Tables + "/edit/:id"} component={wrapperHeader(WrappedTableEditComponent)} />
                      <Route path={ClientRoutes.Tables + "/:id"} component={wrapperHeader(WrappedTableDetailComponent)} />
                      <Route path={ClientRoutes.Tables} component={wrapperHeader(WrappedTableSearchComponent)} />
					<Route path={ClientRoutes.TestAllFieldTypes + "/create"} component={wrapperHeader(WrappedTestAllFieldTypeCreateComponent)} />
                      <Route path={ClientRoutes.TestAllFieldTypes + "/edit/:id"} component={wrapperHeader(WrappedTestAllFieldTypeEditComponent)} />
                      <Route path={ClientRoutes.TestAllFieldTypes + "/:id"} component={wrapperHeader(WrappedTestAllFieldTypeDetailComponent)} />
                      <Route path={ClientRoutes.TestAllFieldTypes} component={wrapperHeader(WrappedTestAllFieldTypeSearchComponent)} />
					<Route path={ClientRoutes.TestAllFieldTypesNullables + "/create"} component={wrapperHeader(WrappedTestAllFieldTypesNullableCreateComponent)} />
                      <Route path={ClientRoutes.TestAllFieldTypesNullables + "/edit/:id"} component={wrapperHeader(WrappedTestAllFieldTypesNullableEditComponent)} />
                      <Route path={ClientRoutes.TestAllFieldTypesNullables + "/:id"} component={wrapperHeader(WrappedTestAllFieldTypesNullableDetailComponent)} />
                      <Route path={ClientRoutes.TestAllFieldTypesNullables} component={wrapperHeader(WrappedTestAllFieldTypesNullableSearchComponent)} />
					<Route path={ClientRoutes.TimestampChecks + "/create"} component={wrapperHeader(WrappedTimestampCheckCreateComponent)} />
                      <Route path={ClientRoutes.TimestampChecks + "/edit/:id"} component={wrapperHeader(WrappedTimestampCheckEditComponent)} />
                      <Route path={ClientRoutes.TimestampChecks + "/:id"} component={wrapperHeader(WrappedTimestampCheckDetailComponent)} />
                      <Route path={ClientRoutes.TimestampChecks} component={wrapperHeader(WrappedTimestampCheckSearchComponent)} />
					<Route path={ClientRoutes.VPersons + "/create"} component={wrapperHeader(WrappedVPersonCreateComponent)} />
                      <Route path={ClientRoutes.VPersons + "/edit/:id"} component={wrapperHeader(WrappedVPersonEditComponent)} />
                      <Route path={ClientRoutes.VPersons + "/:id"} component={wrapperHeader(WrappedVPersonDetailComponent)} />
                      <Route path={ClientRoutes.VPersons} component={wrapperHeader(WrappedVPersonSearchComponent)} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>eddb5847c724149308454f691a1a5d80</Hash>
</Codenesium>*/