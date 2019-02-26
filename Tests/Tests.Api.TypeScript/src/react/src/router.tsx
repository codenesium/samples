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
          <Route exact path="/" component={wrapperHeader(Dashboard, "Dashboard")} />
		  <Route path={ClientRoutes.ColumnSameAsFKTables + "/create"} component={wrapperHeader(WrappedColumnSameAsFKTableCreateComponent, "ColumnSameAsFKTables Create")} />
                      <Route path={ClientRoutes.ColumnSameAsFKTables + "/edit/:id"} component={wrapperHeader(WrappedColumnSameAsFKTableEditComponent, "ColumnSameAsFKTables Edit")} />
                      <Route path={ClientRoutes.ColumnSameAsFKTables + "/:id"} component={wrapperHeader(WrappedColumnSameAsFKTableDetailComponent , "ColumnSameAsFKTables Detail")} />
                      <Route path={ClientRoutes.ColumnSameAsFKTables} component={wrapperHeader(WrappedColumnSameAsFKTableSearchComponent, "ColumnSameAsFKTables Search")} />
					<Route path={ClientRoutes.IncludedColumnTests + "/create"} component={wrapperHeader(WrappedIncludedColumnTestCreateComponent, "IncludedColumnTests Create")} />
                      <Route path={ClientRoutes.IncludedColumnTests + "/edit/:id"} component={wrapperHeader(WrappedIncludedColumnTestEditComponent, "IncludedColumnTests Edit")} />
                      <Route path={ClientRoutes.IncludedColumnTests + "/:id"} component={wrapperHeader(WrappedIncludedColumnTestDetailComponent , "IncludedColumnTests Detail")} />
                      <Route path={ClientRoutes.IncludedColumnTests} component={wrapperHeader(WrappedIncludedColumnTestSearchComponent, "IncludedColumnTests Search")} />
					<Route path={ClientRoutes.People + "/create"} component={wrapperHeader(WrappedPersonCreateComponent, "People Create")} />
                      <Route path={ClientRoutes.People + "/edit/:id"} component={wrapperHeader(WrappedPersonEditComponent, "People Edit")} />
                      <Route path={ClientRoutes.People + "/:id"} component={wrapperHeader(WrappedPersonDetailComponent , "People Detail")} />
                      <Route path={ClientRoutes.People} component={wrapperHeader(WrappedPersonSearchComponent, "People Search")} />
					<Route path={ClientRoutes.RowVersionChecks + "/create"} component={wrapperHeader(WrappedRowVersionCheckCreateComponent, "RowVersionChecks Create")} />
                      <Route path={ClientRoutes.RowVersionChecks + "/edit/:id"} component={wrapperHeader(WrappedRowVersionCheckEditComponent, "RowVersionChecks Edit")} />
                      <Route path={ClientRoutes.RowVersionChecks + "/:id"} component={wrapperHeader(WrappedRowVersionCheckDetailComponent , "RowVersionChecks Detail")} />
                      <Route path={ClientRoutes.RowVersionChecks} component={wrapperHeader(WrappedRowVersionCheckSearchComponent, "RowVersionChecks Search")} />
					<Route path={ClientRoutes.SelfReferences + "/create"} component={wrapperHeader(WrappedSelfReferenceCreateComponent, "SelfReferences Create")} />
                      <Route path={ClientRoutes.SelfReferences + "/edit/:id"} component={wrapperHeader(WrappedSelfReferenceEditComponent, "SelfReferences Edit")} />
                      <Route path={ClientRoutes.SelfReferences + "/:id"} component={wrapperHeader(WrappedSelfReferenceDetailComponent , "SelfReferences Detail")} />
                      <Route path={ClientRoutes.SelfReferences} component={wrapperHeader(WrappedSelfReferenceSearchComponent, "SelfReferences Search")} />
					<Route path={ClientRoutes.Tables + "/create"} component={wrapperHeader(WrappedTableCreateComponent, "Tables Create")} />
                      <Route path={ClientRoutes.Tables + "/edit/:id"} component={wrapperHeader(WrappedTableEditComponent, "Tables Edit")} />
                      <Route path={ClientRoutes.Tables + "/:id"} component={wrapperHeader(WrappedTableDetailComponent , "Tables Detail")} />
                      <Route path={ClientRoutes.Tables} component={wrapperHeader(WrappedTableSearchComponent, "Tables Search")} />
					<Route path={ClientRoutes.TestAllFieldTypes + "/create"} component={wrapperHeader(WrappedTestAllFieldTypeCreateComponent, "TestAllFieldTypes Create")} />
                      <Route path={ClientRoutes.TestAllFieldTypes + "/edit/:id"} component={wrapperHeader(WrappedTestAllFieldTypeEditComponent, "TestAllFieldTypes Edit")} />
                      <Route path={ClientRoutes.TestAllFieldTypes + "/:id"} component={wrapperHeader(WrappedTestAllFieldTypeDetailComponent , "TestAllFieldTypes Detail")} />
                      <Route path={ClientRoutes.TestAllFieldTypes} component={wrapperHeader(WrappedTestAllFieldTypeSearchComponent, "TestAllFieldTypes Search")} />
					<Route path={ClientRoutes.TestAllFieldTypesNullables + "/create"} component={wrapperHeader(WrappedTestAllFieldTypesNullableCreateComponent, "TestAllFieldTypesNullables Create")} />
                      <Route path={ClientRoutes.TestAllFieldTypesNullables + "/edit/:id"} component={wrapperHeader(WrappedTestAllFieldTypesNullableEditComponent, "TestAllFieldTypesNullables Edit")} />
                      <Route path={ClientRoutes.TestAllFieldTypesNullables + "/:id"} component={wrapperHeader(WrappedTestAllFieldTypesNullableDetailComponent , "TestAllFieldTypesNullables Detail")} />
                      <Route path={ClientRoutes.TestAllFieldTypesNullables} component={wrapperHeader(WrappedTestAllFieldTypesNullableSearchComponent, "TestAllFieldTypesNullables Search")} />
					<Route path={ClientRoutes.TimestampChecks + "/create"} component={wrapperHeader(WrappedTimestampCheckCreateComponent, "TimestampChecks Create")} />
                      <Route path={ClientRoutes.TimestampChecks + "/edit/:id"} component={wrapperHeader(WrappedTimestampCheckEditComponent, "TimestampChecks Edit")} />
                      <Route path={ClientRoutes.TimestampChecks + "/:id"} component={wrapperHeader(WrappedTimestampCheckDetailComponent , "TimestampChecks Detail")} />
                      <Route path={ClientRoutes.TimestampChecks} component={wrapperHeader(WrappedTimestampCheckSearchComponent, "TimestampChecks Search")} />
					<Route path={ClientRoutes.VPersons + "/create"} component={wrapperHeader(WrappedVPersonCreateComponent, "VPersons Create")} />
                      <Route path={ClientRoutes.VPersons + "/edit/:id"} component={wrapperHeader(WrappedVPersonEditComponent, "VPersons Edit")} />
                      <Route path={ClientRoutes.VPersons + "/:id"} component={wrapperHeader(WrappedVPersonDetailComponent , "VPersons Detail")} />
                      <Route path={ClientRoutes.VPersons} component={wrapperHeader(WrappedVPersonSearchComponent, "VPersons Search")} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>01b80501889231e355c5b5cb89f7ba43</Hash>
</Codenesium>*/