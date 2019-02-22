import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedAddressCreateComponent } from './components/address/addressCreateForm';
import { WrappedAddressDetailComponent } from './components/address/addressDetailForm';
import { WrappedAddressEditComponent } from './components/address/addressEditForm';
import { WrappedAddressSearchComponent } from './components/address/addressSearchForm';					
import { WrappedCallCreateComponent } from './components/call/callCreateForm';
import { WrappedCallDetailComponent } from './components/call/callDetailForm';
import { WrappedCallEditComponent } from './components/call/callEditForm';
import { WrappedCallSearchComponent } from './components/call/callSearchForm';					
import { WrappedCallAssignmentCreateComponent } from './components/callAssignment/callAssignmentCreateForm';
import { WrappedCallAssignmentDetailComponent } from './components/callAssignment/callAssignmentDetailForm';
import { WrappedCallAssignmentEditComponent } from './components/callAssignment/callAssignmentEditForm';
import { WrappedCallAssignmentSearchComponent } from './components/callAssignment/callAssignmentSearchForm';					
import { WrappedCallDispositionCreateComponent } from './components/callDisposition/callDispositionCreateForm';
import { WrappedCallDispositionDetailComponent } from './components/callDisposition/callDispositionDetailForm';
import { WrappedCallDispositionEditComponent } from './components/callDisposition/callDispositionEditForm';
import { WrappedCallDispositionSearchComponent } from './components/callDisposition/callDispositionSearchForm';					
import { WrappedCallPersonCreateComponent } from './components/callPerson/callPersonCreateForm';
import { WrappedCallPersonDetailComponent } from './components/callPerson/callPersonDetailForm';
import { WrappedCallPersonEditComponent } from './components/callPerson/callPersonEditForm';
import { WrappedCallPersonSearchComponent } from './components/callPerson/callPersonSearchForm';					
import { WrappedCallStatuCreateComponent } from './components/callStatu/callStatuCreateForm';
import { WrappedCallStatuDetailComponent } from './components/callStatu/callStatuDetailForm';
import { WrappedCallStatuEditComponent } from './components/callStatu/callStatuEditForm';
import { WrappedCallStatuSearchComponent } from './components/callStatu/callStatuSearchForm';					
import { WrappedCallTypeCreateComponent } from './components/callType/callTypeCreateForm';
import { WrappedCallTypeDetailComponent } from './components/callType/callTypeDetailForm';
import { WrappedCallTypeEditComponent } from './components/callType/callTypeEditForm';
import { WrappedCallTypeSearchComponent } from './components/callType/callTypeSearchForm';					
import { WrappedNoteCreateComponent } from './components/note/noteCreateForm';
import { WrappedNoteDetailComponent } from './components/note/noteDetailForm';
import { WrappedNoteEditComponent } from './components/note/noteEditForm';
import { WrappedNoteSearchComponent } from './components/note/noteSearchForm';					
import { WrappedOfficerCreateComponent } from './components/officer/officerCreateForm';
import { WrappedOfficerDetailComponent } from './components/officer/officerDetailForm';
import { WrappedOfficerEditComponent } from './components/officer/officerEditForm';
import { WrappedOfficerSearchComponent } from './components/officer/officerSearchForm';					
import { WrappedOfficerCapabilityCreateComponent } from './components/officerCapability/officerCapabilityCreateForm';
import { WrappedOfficerCapabilityDetailComponent } from './components/officerCapability/officerCapabilityDetailForm';
import { WrappedOfficerCapabilityEditComponent } from './components/officerCapability/officerCapabilityEditForm';
import { WrappedOfficerCapabilitySearchComponent } from './components/officerCapability/officerCapabilitySearchForm';					
import { WrappedOfficerRefCapabilityCreateComponent } from './components/officerRefCapability/officerRefCapabilityCreateForm';
import { WrappedOfficerRefCapabilityDetailComponent } from './components/officerRefCapability/officerRefCapabilityDetailForm';
import { WrappedOfficerRefCapabilityEditComponent } from './components/officerRefCapability/officerRefCapabilityEditForm';
import { WrappedOfficerRefCapabilitySearchComponent } from './components/officerRefCapability/officerRefCapabilitySearchForm';					
import { WrappedPersonCreateComponent } from './components/person/personCreateForm';
import { WrappedPersonDetailComponent } from './components/person/personDetailForm';
import { WrappedPersonEditComponent } from './components/person/personEditForm';
import { WrappedPersonSearchComponent } from './components/person/personSearchForm';					
import { WrappedPersonTypeCreateComponent } from './components/personType/personTypeCreateForm';
import { WrappedPersonTypeDetailComponent } from './components/personType/personTypeDetailForm';
import { WrappedPersonTypeEditComponent } from './components/personType/personTypeEditForm';
import { WrappedPersonTypeSearchComponent } from './components/personType/personTypeSearchForm';					
import { WrappedUnitCreateComponent } from './components/unit/unitCreateForm';
import { WrappedUnitDetailComponent } from './components/unit/unitDetailForm';
import { WrappedUnitEditComponent } from './components/unit/unitEditForm';
import { WrappedUnitSearchComponent } from './components/unit/unitSearchForm';					
import { WrappedUnitDispositionCreateComponent } from './components/unitDisposition/unitDispositionCreateForm';
import { WrappedUnitDispositionDetailComponent } from './components/unitDisposition/unitDispositionDetailForm';
import { WrappedUnitDispositionEditComponent } from './components/unitDisposition/unitDispositionEditForm';
import { WrappedUnitDispositionSearchComponent } from './components/unitDisposition/unitDispositionSearchForm';					
import { WrappedUnitOfficerCreateComponent } from './components/unitOfficer/unitOfficerCreateForm';
import { WrappedUnitOfficerDetailComponent } from './components/unitOfficer/unitOfficerDetailForm';
import { WrappedUnitOfficerEditComponent } from './components/unitOfficer/unitOfficerEditForm';
import { WrappedUnitOfficerSearchComponent } from './components/unitOfficer/unitOfficerSearchForm';					
import { WrappedVehicleCreateComponent } from './components/vehicle/vehicleCreateForm';
import { WrappedVehicleDetailComponent } from './components/vehicle/vehicleDetailForm';
import { WrappedVehicleEditComponent } from './components/vehicle/vehicleEditForm';
import { WrappedVehicleSearchComponent } from './components/vehicle/vehicleSearchForm';					
import { WrappedVehicleCapabilityCreateComponent } from './components/vehicleCapability/vehicleCapabilityCreateForm';
import { WrappedVehicleCapabilityDetailComponent } from './components/vehicleCapability/vehicleCapabilityDetailForm';
import { WrappedVehicleCapabilityEditComponent } from './components/vehicleCapability/vehicleCapabilityEditForm';
import { WrappedVehicleCapabilitySearchComponent } from './components/vehicleCapability/vehicleCapabilitySearchForm';					
import { WrappedVehicleOfficerCreateComponent } from './components/vehicleOfficer/vehicleOfficerCreateForm';
import { WrappedVehicleOfficerDetailComponent } from './components/vehicleOfficer/vehicleOfficerDetailForm';
import { WrappedVehicleOfficerEditComponent } from './components/vehicleOfficer/vehicleOfficerEditForm';
import { WrappedVehicleOfficerSearchComponent } from './components/vehicleOfficer/vehicleOfficerSearchForm';					
import { WrappedVehicleRefCapabilityCreateComponent } from './components/vehicleRefCapability/vehicleRefCapabilityCreateForm';
import { WrappedVehicleRefCapabilityDetailComponent } from './components/vehicleRefCapability/vehicleRefCapabilityDetailForm';
import { WrappedVehicleRefCapabilityEditComponent } from './components/vehicleRefCapability/vehicleRefCapabilityEditForm';
import { WrappedVehicleRefCapabilitySearchComponent } from './components/vehicleRefCapability/vehicleRefCapabilitySearchForm';					

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
		  <Route path={ClientRoutes.Addresses + "/create"} component={wrapperHeader(WrappedAddressCreateComponent, "Address Create")} />
                      <Route path={ClientRoutes.Addresses + "/edit/:id"} component={wrapperHeader(WrappedAddressEditComponent, "Address Edit")} />
                      <Route path={ClientRoutes.Addresses + "/:id"} component={wrapperHeader(WrappedAddressDetailComponent , "Address Detail")} />
                      <Route path={ClientRoutes.Addresses} component={wrapperHeader(WrappedAddressSearchComponent, "Address Search")} />
					<Route path={ClientRoutes.Calls + "/create"} component={wrapperHeader(WrappedCallCreateComponent, "Call Create")} />
                      <Route path={ClientRoutes.Calls + "/edit/:id"} component={wrapperHeader(WrappedCallEditComponent, "Call Edit")} />
                      <Route path={ClientRoutes.Calls + "/:id"} component={wrapperHeader(WrappedCallDetailComponent , "Call Detail")} />
                      <Route path={ClientRoutes.Calls} component={wrapperHeader(WrappedCallSearchComponent, "Call Search")} />
					<Route path={ClientRoutes.CallAssignments + "/create"} component={wrapperHeader(WrappedCallAssignmentCreateComponent, "CallAssignment Create")} />
                      <Route path={ClientRoutes.CallAssignments + "/edit/:id"} component={wrapperHeader(WrappedCallAssignmentEditComponent, "CallAssignment Edit")} />
                      <Route path={ClientRoutes.CallAssignments + "/:id"} component={wrapperHeader(WrappedCallAssignmentDetailComponent , "CallAssignment Detail")} />
                      <Route path={ClientRoutes.CallAssignments} component={wrapperHeader(WrappedCallAssignmentSearchComponent, "CallAssignment Search")} />
					<Route path={ClientRoutes.CallDispositions + "/create"} component={wrapperHeader(WrappedCallDispositionCreateComponent, "CallDisposition Create")} />
                      <Route path={ClientRoutes.CallDispositions + "/edit/:id"} component={wrapperHeader(WrappedCallDispositionEditComponent, "CallDisposition Edit")} />
                      <Route path={ClientRoutes.CallDispositions + "/:id"} component={wrapperHeader(WrappedCallDispositionDetailComponent , "CallDisposition Detail")} />
                      <Route path={ClientRoutes.CallDispositions} component={wrapperHeader(WrappedCallDispositionSearchComponent, "CallDisposition Search")} />
					<Route path={ClientRoutes.CallPersons + "/create"} component={wrapperHeader(WrappedCallPersonCreateComponent, "CallPerson Create")} />
                      <Route path={ClientRoutes.CallPersons + "/edit/:id"} component={wrapperHeader(WrappedCallPersonEditComponent, "CallPerson Edit")} />
                      <Route path={ClientRoutes.CallPersons + "/:id"} component={wrapperHeader(WrappedCallPersonDetailComponent , "CallPerson Detail")} />
                      <Route path={ClientRoutes.CallPersons} component={wrapperHeader(WrappedCallPersonSearchComponent, "CallPerson Search")} />
					<Route path={ClientRoutes.CallStatus + "/create"} component={wrapperHeader(WrappedCallStatuCreateComponent, "CallStatu Create")} />
                      <Route path={ClientRoutes.CallStatus + "/edit/:id"} component={wrapperHeader(WrappedCallStatuEditComponent, "CallStatu Edit")} />
                      <Route path={ClientRoutes.CallStatus + "/:id"} component={wrapperHeader(WrappedCallStatuDetailComponent , "CallStatu Detail")} />
                      <Route path={ClientRoutes.CallStatus} component={wrapperHeader(WrappedCallStatuSearchComponent, "CallStatu Search")} />
					<Route path={ClientRoutes.CallTypes + "/create"} component={wrapperHeader(WrappedCallTypeCreateComponent, "CallType Create")} />
                      <Route path={ClientRoutes.CallTypes + "/edit/:id"} component={wrapperHeader(WrappedCallTypeEditComponent, "CallType Edit")} />
                      <Route path={ClientRoutes.CallTypes + "/:id"} component={wrapperHeader(WrappedCallTypeDetailComponent , "CallType Detail")} />
                      <Route path={ClientRoutes.CallTypes} component={wrapperHeader(WrappedCallTypeSearchComponent, "CallType Search")} />
					<Route path={ClientRoutes.Notes + "/create"} component={wrapperHeader(WrappedNoteCreateComponent, "Note Create")} />
                      <Route path={ClientRoutes.Notes + "/edit/:id"} component={wrapperHeader(WrappedNoteEditComponent, "Note Edit")} />
                      <Route path={ClientRoutes.Notes + "/:id"} component={wrapperHeader(WrappedNoteDetailComponent , "Note Detail")} />
                      <Route path={ClientRoutes.Notes} component={wrapperHeader(WrappedNoteSearchComponent, "Note Search")} />
					<Route path={ClientRoutes.Officers + "/create"} component={wrapperHeader(WrappedOfficerCreateComponent, "Officer Create")} />
                      <Route path={ClientRoutes.Officers + "/edit/:id"} component={wrapperHeader(WrappedOfficerEditComponent, "Officer Edit")} />
                      <Route path={ClientRoutes.Officers + "/:id"} component={wrapperHeader(WrappedOfficerDetailComponent , "Officer Detail")} />
                      <Route path={ClientRoutes.Officers} component={wrapperHeader(WrappedOfficerSearchComponent, "Officer Search")} />
					<Route path={ClientRoutes.OfficerCapabilities + "/create"} component={wrapperHeader(WrappedOfficerCapabilityCreateComponent, "OfficerCapability Create")} />
                      <Route path={ClientRoutes.OfficerCapabilities + "/edit/:id"} component={wrapperHeader(WrappedOfficerCapabilityEditComponent, "OfficerCapability Edit")} />
                      <Route path={ClientRoutes.OfficerCapabilities + "/:id"} component={wrapperHeader(WrappedOfficerCapabilityDetailComponent , "OfficerCapability Detail")} />
                      <Route path={ClientRoutes.OfficerCapabilities} component={wrapperHeader(WrappedOfficerCapabilitySearchComponent, "OfficerCapability Search")} />
					<Route path={ClientRoutes.OfficerRefCapabilities + "/create"} component={wrapperHeader(WrappedOfficerRefCapabilityCreateComponent, "OfficerRefCapability Create")} />
                      <Route path={ClientRoutes.OfficerRefCapabilities + "/edit/:id"} component={wrapperHeader(WrappedOfficerRefCapabilityEditComponent, "OfficerRefCapability Edit")} />
                      <Route path={ClientRoutes.OfficerRefCapabilities + "/:id"} component={wrapperHeader(WrappedOfficerRefCapabilityDetailComponent , "OfficerRefCapability Detail")} />
                      <Route path={ClientRoutes.OfficerRefCapabilities} component={wrapperHeader(WrappedOfficerRefCapabilitySearchComponent, "OfficerRefCapability Search")} />
					<Route path={ClientRoutes.People + "/create"} component={wrapperHeader(WrappedPersonCreateComponent, "Person Create")} />
                      <Route path={ClientRoutes.People + "/edit/:id"} component={wrapperHeader(WrappedPersonEditComponent, "Person Edit")} />
                      <Route path={ClientRoutes.People + "/:id"} component={wrapperHeader(WrappedPersonDetailComponent , "Person Detail")} />
                      <Route path={ClientRoutes.People} component={wrapperHeader(WrappedPersonSearchComponent, "Person Search")} />
					<Route path={ClientRoutes.PersonTypes + "/create"} component={wrapperHeader(WrappedPersonTypeCreateComponent, "PersonType Create")} />
                      <Route path={ClientRoutes.PersonTypes + "/edit/:id"} component={wrapperHeader(WrappedPersonTypeEditComponent, "PersonType Edit")} />
                      <Route path={ClientRoutes.PersonTypes + "/:id"} component={wrapperHeader(WrappedPersonTypeDetailComponent , "PersonType Detail")} />
                      <Route path={ClientRoutes.PersonTypes} component={wrapperHeader(WrappedPersonTypeSearchComponent, "PersonType Search")} />
					<Route path={ClientRoutes.Units + "/create"} component={wrapperHeader(WrappedUnitCreateComponent, "Unit Create")} />
                      <Route path={ClientRoutes.Units + "/edit/:id"} component={wrapperHeader(WrappedUnitEditComponent, "Unit Edit")} />
                      <Route path={ClientRoutes.Units + "/:id"} component={wrapperHeader(WrappedUnitDetailComponent , "Unit Detail")} />
                      <Route path={ClientRoutes.Units} component={wrapperHeader(WrappedUnitSearchComponent, "Unit Search")} />
					<Route path={ClientRoutes.UnitDispositions + "/create"} component={wrapperHeader(WrappedUnitDispositionCreateComponent, "UnitDisposition Create")} />
                      <Route path={ClientRoutes.UnitDispositions + "/edit/:id"} component={wrapperHeader(WrappedUnitDispositionEditComponent, "UnitDisposition Edit")} />
                      <Route path={ClientRoutes.UnitDispositions + "/:id"} component={wrapperHeader(WrappedUnitDispositionDetailComponent , "UnitDisposition Detail")} />
                      <Route path={ClientRoutes.UnitDispositions} component={wrapperHeader(WrappedUnitDispositionSearchComponent, "UnitDisposition Search")} />
					<Route path={ClientRoutes.UnitOfficers + "/create"} component={wrapperHeader(WrappedUnitOfficerCreateComponent, "UnitOfficer Create")} />
                      <Route path={ClientRoutes.UnitOfficers + "/edit/:id"} component={wrapperHeader(WrappedUnitOfficerEditComponent, "UnitOfficer Edit")} />
                      <Route path={ClientRoutes.UnitOfficers + "/:id"} component={wrapperHeader(WrappedUnitOfficerDetailComponent , "UnitOfficer Detail")} />
                      <Route path={ClientRoutes.UnitOfficers} component={wrapperHeader(WrappedUnitOfficerSearchComponent, "UnitOfficer Search")} />
					<Route path={ClientRoutes.Vehicles + "/create"} component={wrapperHeader(WrappedVehicleCreateComponent, "Vehicle Create")} />
                      <Route path={ClientRoutes.Vehicles + "/edit/:id"} component={wrapperHeader(WrappedVehicleEditComponent, "Vehicle Edit")} />
                      <Route path={ClientRoutes.Vehicles + "/:id"} component={wrapperHeader(WrappedVehicleDetailComponent , "Vehicle Detail")} />
                      <Route path={ClientRoutes.Vehicles} component={wrapperHeader(WrappedVehicleSearchComponent, "Vehicle Search")} />
					<Route path={ClientRoutes.VehicleCapabilities + "/create"} component={wrapperHeader(WrappedVehicleCapabilityCreateComponent, "VehicleCapability Create")} />
                      <Route path={ClientRoutes.VehicleCapabilities + "/edit/:id"} component={wrapperHeader(WrappedVehicleCapabilityEditComponent, "VehicleCapability Edit")} />
                      <Route path={ClientRoutes.VehicleCapabilities + "/:id"} component={wrapperHeader(WrappedVehicleCapabilityDetailComponent , "VehicleCapability Detail")} />
                      <Route path={ClientRoutes.VehicleCapabilities} component={wrapperHeader(WrappedVehicleCapabilitySearchComponent, "VehicleCapability Search")} />
					<Route path={ClientRoutes.VehicleOfficers + "/create"} component={wrapperHeader(WrappedVehicleOfficerCreateComponent, "VehicleOfficer Create")} />
                      <Route path={ClientRoutes.VehicleOfficers + "/edit/:id"} component={wrapperHeader(WrappedVehicleOfficerEditComponent, "VehicleOfficer Edit")} />
                      <Route path={ClientRoutes.VehicleOfficers + "/:id"} component={wrapperHeader(WrappedVehicleOfficerDetailComponent , "VehicleOfficer Detail")} />
                      <Route path={ClientRoutes.VehicleOfficers} component={wrapperHeader(WrappedVehicleOfficerSearchComponent, "VehicleOfficer Search")} />
					<Route path={ClientRoutes.VehicleRefCapabilities + "/create"} component={wrapperHeader(WrappedVehicleRefCapabilityCreateComponent, "VehicleRefCapability Create")} />
                      <Route path={ClientRoutes.VehicleRefCapabilities + "/edit/:id"} component={wrapperHeader(WrappedVehicleRefCapabilityEditComponent, "VehicleRefCapability Edit")} />
                      <Route path={ClientRoutes.VehicleRefCapabilities + "/:id"} component={wrapperHeader(WrappedVehicleRefCapabilityDetailComponent , "VehicleRefCapability Detail")} />
                      <Route path={ClientRoutes.VehicleRefCapabilities} component={wrapperHeader(WrappedVehicleRefCapabilitySearchComponent, "VehicleRefCapability Search")} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>5545c76c611152fd41032754896c1512</Hash>
</Codenesium>*/