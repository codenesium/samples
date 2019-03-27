import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { wrapperHeader } from './components/header';
import { wrapperAuthHeader } from './components/auth/authHeader';
import { AuthClientRoutes, ClientRoutes, Constants } from './constants';
import { WrappedLoginComponent } from './components/auth/loginForm';
import { WrappedLogoutComponent } from './components/auth/logoutForm';
import { WrappedRegisterComponent } from './components/auth/registerForm';
import { WrappedResetPasswordComponent } from './components/auth/resetPasswordForm';
import { WrappedConfirmPasswordResetComponent } from './components/auth/confirmPasswordResetForm';
import { WrappedConfirmRegistrationComponent } from './components/auth/confirmRegistrationForm';
import { WrappedChangePasswordComponent } from './components/auth/changePasswordForm';
import { WrappedChangeEmailComponent } from './components/auth/changeEmailForm';
import { WrappedConfirmChangeEmailComponent } from './components/auth/confirmChangeEmailForm';
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
import { WrappedCallStatusCreateComponent } from './components/callStatus/callStatusCreateForm';
import { WrappedCallStatusDetailComponent } from './components/callStatus/callStatusDetailForm';
import { WrappedCallStatusEditComponent } from './components/callStatus/callStatusEditForm';
import { WrappedCallStatusSearchComponent } from './components/callStatus/callStatusSearchForm';
import { WrappedCallTypeCreateComponent } from './components/callType/callTypeCreateForm';
import { WrappedCallTypeDetailComponent } from './components/callType/callTypeDetailForm';
import { WrappedCallTypeEditComponent } from './components/callType/callTypeEditForm';
import { WrappedCallTypeSearchComponent } from './components/callType/callTypeSearchForm';
import { WrappedNoteCreateComponent } from './components/note/noteCreateForm';
import { WrappedNoteDetailComponent } from './components/note/noteDetailForm';
import { WrappedNoteEditComponent } from './components/note/noteEditForm';
import { WrappedNoteSearchComponent } from './components/note/noteSearchForm';
import { WrappedOffCapabilityCreateComponent } from './components/offCapability/offCapabilityCreateForm';
import { WrappedOffCapabilityDetailComponent } from './components/offCapability/offCapabilityDetailForm';
import { WrappedOffCapabilityEditComponent } from './components/offCapability/offCapabilityEditForm';
import { WrappedOffCapabilitySearchComponent } from './components/offCapability/offCapabilitySearchForm';
import { WrappedOfficerCreateComponent } from './components/officer/officerCreateForm';
import { WrappedOfficerDetailComponent } from './components/officer/officerDetailForm';
import { WrappedOfficerEditComponent } from './components/officer/officerEditForm';
import { WrappedOfficerSearchComponent } from './components/officer/officerSearchForm';
import { WrappedOfficerCapabilitiesCreateComponent } from './components/officerCapabilities/officerCapabilitiesCreateForm';
import { WrappedOfficerCapabilitiesDetailComponent } from './components/officerCapabilities/officerCapabilitiesDetailForm';
import { WrappedOfficerCapabilitiesEditComponent } from './components/officerCapabilities/officerCapabilitiesEditForm';
import { WrappedOfficerCapabilitiesSearchComponent } from './components/officerCapabilities/officerCapabilitiesSearchForm';
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
import { WrappedVehCapabilityCreateComponent } from './components/vehCapability/vehCapabilityCreateForm';
import { WrappedVehCapabilityDetailComponent } from './components/vehCapability/vehCapabilityDetailForm';
import { WrappedVehCapabilityEditComponent } from './components/vehCapability/vehCapabilityEditForm';
import { WrappedVehCapabilitySearchComponent } from './components/vehCapability/vehCapabilitySearchForm';
import { WrappedVehicleCreateComponent } from './components/vehicle/vehicleCreateForm';
import { WrappedVehicleDetailComponent } from './components/vehicle/vehicleDetailForm';
import { WrappedVehicleEditComponent } from './components/vehicle/vehicleEditForm';
import { WrappedVehicleSearchComponent } from './components/vehicle/vehicleSearchForm';
import { WrappedVehicleCapabilitiesCreateComponent } from './components/vehicleCapabilities/vehicleCapabilitiesCreateForm';
import { WrappedVehicleCapabilitiesDetailComponent } from './components/vehicleCapabilities/vehicleCapabilitiesDetailForm';
import { WrappedVehicleCapabilitiesEditComponent } from './components/vehicleCapabilities/vehicleCapabilitiesEditForm';
import { WrappedVehicleCapabilitiesSearchComponent } from './components/vehicleCapabilities/vehicleCapabilitiesSearchForm';
import { WrappedVehicleOfficerCreateComponent } from './components/vehicleOfficer/vehicleOfficerCreateForm';
import { WrappedVehicleOfficerDetailComponent } from './components/vehicleOfficer/vehicleOfficerDetailForm';
import { WrappedVehicleOfficerEditComponent } from './components/vehicleOfficer/vehicleOfficerEditForm';
import { WrappedVehicleOfficerSearchComponent } from './components/vehicleOfficer/vehicleOfficerSearchForm';

export const AppRouter: React.StatelessComponent<{}> = () => {
  return (
    <BrowserRouter basename={Constants.HostedSubDirectory}>
      <Switch>
        <Route
          exact
          path={AuthClientRoutes.ConfirmPasswordReset + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmPasswordResetComponent,
            'Confirm Password Reset'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmRegistration + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmRegistrationComponent,
            'Confirm Registration'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.Login}
          component={wrapperAuthHeader(WrappedLoginComponent, 'Login')}
        />
        <Route
          exact
          path={AuthClientRoutes.Logout}
          component={wrapperAuthHeader(WrappedLogoutComponent, 'Logout')}
        />
        <Route
          exact
          path={AuthClientRoutes.Register}
          component={wrapperAuthHeader(WrappedRegisterComponent, 'Register')}
        />
        <Route
          exact
          path={AuthClientRoutes.ResetPassword}
          component={wrapperAuthHeader(
            WrappedResetPasswordComponent,
            'Reset Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangePassword}
          component={wrapperHeader(
            WrappedChangePasswordComponent,
            'Change Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangeEmail}
          component={wrapperHeader(WrappedChangeEmailComponent, 'Change Email')}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmChangeEmail + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmChangeEmailComponent,
            'Confirm Email Change'
          )}
        />
        <Route
          exact
          path="/"
          component={wrapperHeader(Dashboard, 'Dashboard')}
        />
        <Route
          path={ClientRoutes.Addresses + '/create'}
          component={wrapperHeader(
            WrappedAddressCreateComponent,
            'Address Create'
          )}
        />
        <Route
          path={ClientRoutes.Addresses + '/edit/:id'}
          component={wrapperHeader(WrappedAddressEditComponent, 'Address Edit')}
        />
        <Route
          path={ClientRoutes.Addresses + '/:id'}
          component={wrapperHeader(
            WrappedAddressDetailComponent,
            'Address Detail'
          )}
        />
        <Route
          path={ClientRoutes.Addresses}
          component={wrapperHeader(
            WrappedAddressSearchComponent,
            'Address Search'
          )}
        />
        <Route
          path={ClientRoutes.Calls + '/create'}
          component={wrapperHeader(WrappedCallCreateComponent, 'Call Create')}
        />
        <Route
          path={ClientRoutes.Calls + '/edit/:id'}
          component={wrapperHeader(WrappedCallEditComponent, 'Call Edit')}
        />
        <Route
          path={ClientRoutes.Calls + '/:id'}
          component={wrapperHeader(WrappedCallDetailComponent, 'Call Detail')}
        />
        <Route
          path={ClientRoutes.Calls}
          component={wrapperHeader(WrappedCallSearchComponent, 'Call Search')}
        />
        <Route
          path={ClientRoutes.CallAssignments + '/create'}
          component={wrapperHeader(
            WrappedCallAssignmentCreateComponent,
            'Call Assignment Create'
          )}
        />
        <Route
          path={ClientRoutes.CallAssignments + '/edit/:id'}
          component={wrapperHeader(
            WrappedCallAssignmentEditComponent,
            'Call Assignment Edit'
          )}
        />
        <Route
          path={ClientRoutes.CallAssignments + '/:id'}
          component={wrapperHeader(
            WrappedCallAssignmentDetailComponent,
            'Call Assignment Detail'
          )}
        />
        <Route
          path={ClientRoutes.CallAssignments}
          component={wrapperHeader(
            WrappedCallAssignmentSearchComponent,
            'Call Assignment Search'
          )}
        />
        <Route
          path={ClientRoutes.CallDispositions + '/create'}
          component={wrapperHeader(
            WrappedCallDispositionCreateComponent,
            'Call Disposition Create'
          )}
        />
        <Route
          path={ClientRoutes.CallDispositions + '/edit/:id'}
          component={wrapperHeader(
            WrappedCallDispositionEditComponent,
            'Call Disposition Edit'
          )}
        />
        <Route
          path={ClientRoutes.CallDispositions + '/:id'}
          component={wrapperHeader(
            WrappedCallDispositionDetailComponent,
            'Call Disposition Detail'
          )}
        />
        <Route
          path={ClientRoutes.CallDispositions}
          component={wrapperHeader(
            WrappedCallDispositionSearchComponent,
            'Call Disposition Search'
          )}
        />
        <Route
          path={ClientRoutes.CallPersons + '/create'}
          component={wrapperHeader(
            WrappedCallPersonCreateComponent,
            'Call Person Create'
          )}
        />
        <Route
          path={ClientRoutes.CallPersons + '/edit/:id'}
          component={wrapperHeader(
            WrappedCallPersonEditComponent,
            'Call Person Edit'
          )}
        />
        <Route
          path={ClientRoutes.CallPersons + '/:id'}
          component={wrapperHeader(
            WrappedCallPersonDetailComponent,
            'Call Person Detail'
          )}
        />
        <Route
          path={ClientRoutes.CallPersons}
          component={wrapperHeader(
            WrappedCallPersonSearchComponent,
            'Call Person Search'
          )}
        />
        <Route
          path={ClientRoutes.CallStatus + '/create'}
          component={wrapperHeader(
            WrappedCallStatusCreateComponent,
            'Call Status Create'
          )}
        />
        <Route
          path={ClientRoutes.CallStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedCallStatusEditComponent,
            'Call Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.CallStatus + '/:id'}
          component={wrapperHeader(
            WrappedCallStatusDetailComponent,
            'Call Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.CallStatus}
          component={wrapperHeader(
            WrappedCallStatusSearchComponent,
            'Call Status Search'
          )}
        />
        <Route
          path={ClientRoutes.CallTypes + '/create'}
          component={wrapperHeader(
            WrappedCallTypeCreateComponent,
            'Call Type Create'
          )}
        />
        <Route
          path={ClientRoutes.CallTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedCallTypeEditComponent,
            'Call Type Edit'
          )}
        />
        <Route
          path={ClientRoutes.CallTypes + '/:id'}
          component={wrapperHeader(
            WrappedCallTypeDetailComponent,
            'Call Type Detail'
          )}
        />
        <Route
          path={ClientRoutes.CallTypes}
          component={wrapperHeader(
            WrappedCallTypeSearchComponent,
            'Call Type Search'
          )}
        />
        <Route
          path={ClientRoutes.Notes + '/create'}
          component={wrapperHeader(WrappedNoteCreateComponent, 'Note Create')}
        />
        <Route
          path={ClientRoutes.Notes + '/edit/:id'}
          component={wrapperHeader(WrappedNoteEditComponent, 'Note Edit')}
        />
        <Route
          path={ClientRoutes.Notes + '/:id'}
          component={wrapperHeader(WrappedNoteDetailComponent, 'Note Detail')}
        />
        <Route
          path={ClientRoutes.Notes}
          component={wrapperHeader(WrappedNoteSearchComponent, 'Note Search')}
        />
        <Route
          path={ClientRoutes.OffCapabilities + '/create'}
          component={wrapperHeader(
            WrappedOffCapabilityCreateComponent,
            'Off Capability Create'
          )}
        />
        <Route
          path={ClientRoutes.OffCapabilities + '/edit/:id'}
          component={wrapperHeader(
            WrappedOffCapabilityEditComponent,
            'Off Capability Edit'
          )}
        />
        <Route
          path={ClientRoutes.OffCapabilities + '/:id'}
          component={wrapperHeader(
            WrappedOffCapabilityDetailComponent,
            'Off Capability Detail'
          )}
        />
        <Route
          path={ClientRoutes.OffCapabilities}
          component={wrapperHeader(
            WrappedOffCapabilitySearchComponent,
            'Off Capability Search'
          )}
        />
        <Route
          path={ClientRoutes.Officers + '/create'}
          component={wrapperHeader(
            WrappedOfficerCreateComponent,
            'Officer Create'
          )}
        />
        <Route
          path={ClientRoutes.Officers + '/edit/:id'}
          component={wrapperHeader(WrappedOfficerEditComponent, 'Officer Edit')}
        />
        <Route
          path={ClientRoutes.Officers + '/:id'}
          component={wrapperHeader(
            WrappedOfficerDetailComponent,
            'Officer Detail'
          )}
        />
        <Route
          path={ClientRoutes.Officers}
          component={wrapperHeader(
            WrappedOfficerSearchComponent,
            'Officer Search'
          )}
        />
        <Route
          path={ClientRoutes.OfficerCapabilities + '/create'}
          component={wrapperHeader(
            WrappedOfficerCapabilitiesCreateComponent,
            'Officer Capabilities Create'
          )}
        />
        <Route
          path={ClientRoutes.OfficerCapabilities + '/edit/:id'}
          component={wrapperHeader(
            WrappedOfficerCapabilitiesEditComponent,
            'Officer Capabilities Edit'
          )}
        />
        <Route
          path={ClientRoutes.OfficerCapabilities + '/:id'}
          component={wrapperHeader(
            WrappedOfficerCapabilitiesDetailComponent,
            'Officer Capabilities Detail'
          )}
        />
        <Route
          path={ClientRoutes.OfficerCapabilities}
          component={wrapperHeader(
            WrappedOfficerCapabilitiesSearchComponent,
            'Officer Capabilities Search'
          )}
        />
        <Route
          path={ClientRoutes.People + '/create'}
          component={wrapperHeader(
            WrappedPersonCreateComponent,
            'Person Create'
          )}
        />
        <Route
          path={ClientRoutes.People + '/edit/:id'}
          component={wrapperHeader(WrappedPersonEditComponent, 'Person Edit')}
        />
        <Route
          path={ClientRoutes.People + '/:id'}
          component={wrapperHeader(
            WrappedPersonDetailComponent,
            'Person Detail'
          )}
        />
        <Route
          path={ClientRoutes.People}
          component={wrapperHeader(
            WrappedPersonSearchComponent,
            'Person Search'
          )}
        />
        <Route
          path={ClientRoutes.PersonTypes + '/create'}
          component={wrapperHeader(
            WrappedPersonTypeCreateComponent,
            'Person Type Create'
          )}
        />
        <Route
          path={ClientRoutes.PersonTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedPersonTypeEditComponent,
            'Person Type Edit'
          )}
        />
        <Route
          path={ClientRoutes.PersonTypes + '/:id'}
          component={wrapperHeader(
            WrappedPersonTypeDetailComponent,
            'Person Type Detail'
          )}
        />
        <Route
          path={ClientRoutes.PersonTypes}
          component={wrapperHeader(
            WrappedPersonTypeSearchComponent,
            'Person Type Search'
          )}
        />
        <Route
          path={ClientRoutes.Units + '/create'}
          component={wrapperHeader(WrappedUnitCreateComponent, 'Unit Create')}
        />
        <Route
          path={ClientRoutes.Units + '/edit/:id'}
          component={wrapperHeader(WrappedUnitEditComponent, 'Unit Edit')}
        />
        <Route
          path={ClientRoutes.Units + '/:id'}
          component={wrapperHeader(WrappedUnitDetailComponent, 'Unit Detail')}
        />
        <Route
          path={ClientRoutes.Units}
          component={wrapperHeader(WrappedUnitSearchComponent, 'Unit Search')}
        />
        <Route
          path={ClientRoutes.UnitDispositions + '/create'}
          component={wrapperHeader(
            WrappedUnitDispositionCreateComponent,
            'Unit Disposition Create'
          )}
        />
        <Route
          path={ClientRoutes.UnitDispositions + '/edit/:id'}
          component={wrapperHeader(
            WrappedUnitDispositionEditComponent,
            'Unit Disposition Edit'
          )}
        />
        <Route
          path={ClientRoutes.UnitDispositions + '/:id'}
          component={wrapperHeader(
            WrappedUnitDispositionDetailComponent,
            'Unit Disposition Detail'
          )}
        />
        <Route
          path={ClientRoutes.UnitDispositions}
          component={wrapperHeader(
            WrappedUnitDispositionSearchComponent,
            'Unit Disposition Search'
          )}
        />
        <Route
          path={ClientRoutes.UnitOfficers + '/create'}
          component={wrapperHeader(
            WrappedUnitOfficerCreateComponent,
            'Unit Officer Create'
          )}
        />
        <Route
          path={ClientRoutes.UnitOfficers + '/edit/:id'}
          component={wrapperHeader(
            WrappedUnitOfficerEditComponent,
            'Unit Officer Edit'
          )}
        />
        <Route
          path={ClientRoutes.UnitOfficers + '/:id'}
          component={wrapperHeader(
            WrappedUnitOfficerDetailComponent,
            'Unit Officer Detail'
          )}
        />
        <Route
          path={ClientRoutes.UnitOfficers}
          component={wrapperHeader(
            WrappedUnitOfficerSearchComponent,
            'Unit Officer Search'
          )}
        />
        <Route
          path={ClientRoutes.VehCapabilities + '/create'}
          component={wrapperHeader(
            WrappedVehCapabilityCreateComponent,
            'Veh Capability Create'
          )}
        />
        <Route
          path={ClientRoutes.VehCapabilities + '/edit/:id'}
          component={wrapperHeader(
            WrappedVehCapabilityEditComponent,
            'Veh Capability Edit'
          )}
        />
        <Route
          path={ClientRoutes.VehCapabilities + '/:id'}
          component={wrapperHeader(
            WrappedVehCapabilityDetailComponent,
            'Veh Capability Detail'
          )}
        />
        <Route
          path={ClientRoutes.VehCapabilities}
          component={wrapperHeader(
            WrappedVehCapabilitySearchComponent,
            'Veh Capability Search'
          )}
        />
        <Route
          path={ClientRoutes.Vehicles + '/create'}
          component={wrapperHeader(
            WrappedVehicleCreateComponent,
            'Vehicle Create'
          )}
        />
        <Route
          path={ClientRoutes.Vehicles + '/edit/:id'}
          component={wrapperHeader(WrappedVehicleEditComponent, 'Vehicle Edit')}
        />
        <Route
          path={ClientRoutes.Vehicles + '/:id'}
          component={wrapperHeader(
            WrappedVehicleDetailComponent,
            'Vehicle Detail'
          )}
        />
        <Route
          path={ClientRoutes.Vehicles}
          component={wrapperHeader(
            WrappedVehicleSearchComponent,
            'Vehicle Search'
          )}
        />
        <Route
          path={ClientRoutes.VehicleCapabilities + '/create'}
          component={wrapperHeader(
            WrappedVehicleCapabilitiesCreateComponent,
            'Vehicle Capabilities Create'
          )}
        />
        <Route
          path={ClientRoutes.VehicleCapabilities + '/edit/:id'}
          component={wrapperHeader(
            WrappedVehicleCapabilitiesEditComponent,
            'Vehicle Capabilities Edit'
          )}
        />
        <Route
          path={ClientRoutes.VehicleCapabilities + '/:id'}
          component={wrapperHeader(
            WrappedVehicleCapabilitiesDetailComponent,
            'Vehicle Capabilities Detail'
          )}
        />
        <Route
          path={ClientRoutes.VehicleCapabilities}
          component={wrapperHeader(
            WrappedVehicleCapabilitiesSearchComponent,
            'Vehicle Capabilities Search'
          )}
        />
        <Route
          path={ClientRoutes.VehicleOfficers + '/create'}
          component={wrapperHeader(
            WrappedVehicleOfficerCreateComponent,
            'Vehicle Officer Create'
          )}
        />
        <Route
          path={ClientRoutes.VehicleOfficers + '/edit/:id'}
          component={wrapperHeader(
            WrappedVehicleOfficerEditComponent,
            'Vehicle Officer Edit'
          )}
        />
        <Route
          path={ClientRoutes.VehicleOfficers + '/:id'}
          component={wrapperHeader(
            WrappedVehicleOfficerDetailComponent,
            'Vehicle Officer Detail'
          )}
        />
        <Route
          path={ClientRoutes.VehicleOfficers}
          component={wrapperHeader(
            WrappedVehicleOfficerSearchComponent,
            'Vehicle Officer Search'
          )}
        />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>997313518c3345338836146d8e955d59</Hash>
</Codenesium>*/