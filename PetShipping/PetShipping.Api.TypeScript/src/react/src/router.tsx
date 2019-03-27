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
import { WrappedAirlineCreateComponent } from './components/airline/airlineCreateForm';
import { WrappedAirlineDetailComponent } from './components/airline/airlineDetailForm';
import { WrappedAirlineEditComponent } from './components/airline/airlineEditForm';
import { WrappedAirlineSearchComponent } from './components/airline/airlineSearchForm';
import { WrappedAirTransportCreateComponent } from './components/airTransport/airTransportCreateForm';
import { WrappedAirTransportDetailComponent } from './components/airTransport/airTransportDetailForm';
import { WrappedAirTransportEditComponent } from './components/airTransport/airTransportEditForm';
import { WrappedAirTransportSearchComponent } from './components/airTransport/airTransportSearchForm';
import { WrappedBreedCreateComponent } from './components/breed/breedCreateForm';
import { WrappedBreedDetailComponent } from './components/breed/breedDetailForm';
import { WrappedBreedEditComponent } from './components/breed/breedEditForm';
import { WrappedBreedSearchComponent } from './components/breed/breedSearchForm';
import { WrappedCountryCreateComponent } from './components/country/countryCreateForm';
import { WrappedCountryDetailComponent } from './components/country/countryDetailForm';
import { WrappedCountryEditComponent } from './components/country/countryEditForm';
import { WrappedCountrySearchComponent } from './components/country/countrySearchForm';
import { WrappedCountryRequirementCreateComponent } from './components/countryRequirement/countryRequirementCreateForm';
import { WrappedCountryRequirementDetailComponent } from './components/countryRequirement/countryRequirementDetailForm';
import { WrappedCountryRequirementEditComponent } from './components/countryRequirement/countryRequirementEditForm';
import { WrappedCountryRequirementSearchComponent } from './components/countryRequirement/countryRequirementSearchForm';
import { WrappedCustomerCreateComponent } from './components/customer/customerCreateForm';
import { WrappedCustomerDetailComponent } from './components/customer/customerDetailForm';
import { WrappedCustomerEditComponent } from './components/customer/customerEditForm';
import { WrappedCustomerSearchComponent } from './components/customer/customerSearchForm';
import { WrappedCustomerCommunicationCreateComponent } from './components/customerCommunication/customerCommunicationCreateForm';
import { WrappedCustomerCommunicationDetailComponent } from './components/customerCommunication/customerCommunicationDetailForm';
import { WrappedCustomerCommunicationEditComponent } from './components/customerCommunication/customerCommunicationEditForm';
import { WrappedCustomerCommunicationSearchComponent } from './components/customerCommunication/customerCommunicationSearchForm';
import { WrappedDestinationCreateComponent } from './components/destination/destinationCreateForm';
import { WrappedDestinationDetailComponent } from './components/destination/destinationDetailForm';
import { WrappedDestinationEditComponent } from './components/destination/destinationEditForm';
import { WrappedDestinationSearchComponent } from './components/destination/destinationSearchForm';
import { WrappedEmployeeCreateComponent } from './components/employee/employeeCreateForm';
import { WrappedEmployeeDetailComponent } from './components/employee/employeeDetailForm';
import { WrappedEmployeeEditComponent } from './components/employee/employeeEditForm';
import { WrappedEmployeeSearchComponent } from './components/employee/employeeSearchForm';
import { WrappedHandlerCreateComponent } from './components/handler/handlerCreateForm';
import { WrappedHandlerDetailComponent } from './components/handler/handlerDetailForm';
import { WrappedHandlerEditComponent } from './components/handler/handlerEditForm';
import { WrappedHandlerSearchComponent } from './components/handler/handlerSearchForm';
import { WrappedHandlerPipelineStepCreateComponent } from './components/handlerPipelineStep/handlerPipelineStepCreateForm';
import { WrappedHandlerPipelineStepDetailComponent } from './components/handlerPipelineStep/handlerPipelineStepDetailForm';
import { WrappedHandlerPipelineStepEditComponent } from './components/handlerPipelineStep/handlerPipelineStepEditForm';
import { WrappedHandlerPipelineStepSearchComponent } from './components/handlerPipelineStep/handlerPipelineStepSearchForm';
import { WrappedOtherTransportCreateComponent } from './components/otherTransport/otherTransportCreateForm';
import { WrappedOtherTransportDetailComponent } from './components/otherTransport/otherTransportDetailForm';
import { WrappedOtherTransportEditComponent } from './components/otherTransport/otherTransportEditForm';
import { WrappedOtherTransportSearchComponent } from './components/otherTransport/otherTransportSearchForm';
import { WrappedPetCreateComponent } from './components/pet/petCreateForm';
import { WrappedPetDetailComponent } from './components/pet/petDetailForm';
import { WrappedPetEditComponent } from './components/pet/petEditForm';
import { WrappedPetSearchComponent } from './components/pet/petSearchForm';
import { WrappedPipelineCreateComponent } from './components/pipeline/pipelineCreateForm';
import { WrappedPipelineDetailComponent } from './components/pipeline/pipelineDetailForm';
import { WrappedPipelineEditComponent } from './components/pipeline/pipelineEditForm';
import { WrappedPipelineSearchComponent } from './components/pipeline/pipelineSearchForm';
import { WrappedPipelineStatusCreateComponent } from './components/pipelineStatus/pipelineStatusCreateForm';
import { WrappedPipelineStatusDetailComponent } from './components/pipelineStatus/pipelineStatusDetailForm';
import { WrappedPipelineStatusEditComponent } from './components/pipelineStatus/pipelineStatusEditForm';
import { WrappedPipelineStatusSearchComponent } from './components/pipelineStatus/pipelineStatusSearchForm';
import { WrappedPipelineStepCreateComponent } from './components/pipelineStep/pipelineStepCreateForm';
import { WrappedPipelineStepDetailComponent } from './components/pipelineStep/pipelineStepDetailForm';
import { WrappedPipelineStepEditComponent } from './components/pipelineStep/pipelineStepEditForm';
import { WrappedPipelineStepSearchComponent } from './components/pipelineStep/pipelineStepSearchForm';
import { WrappedPipelineStepDestinationCreateComponent } from './components/pipelineStepDestination/pipelineStepDestinationCreateForm';
import { WrappedPipelineStepDestinationDetailComponent } from './components/pipelineStepDestination/pipelineStepDestinationDetailForm';
import { WrappedPipelineStepDestinationEditComponent } from './components/pipelineStepDestination/pipelineStepDestinationEditForm';
import { WrappedPipelineStepDestinationSearchComponent } from './components/pipelineStepDestination/pipelineStepDestinationSearchForm';
import { WrappedPipelineStepNoteCreateComponent } from './components/pipelineStepNote/pipelineStepNoteCreateForm';
import { WrappedPipelineStepNoteDetailComponent } from './components/pipelineStepNote/pipelineStepNoteDetailForm';
import { WrappedPipelineStepNoteEditComponent } from './components/pipelineStepNote/pipelineStepNoteEditForm';
import { WrappedPipelineStepNoteSearchComponent } from './components/pipelineStepNote/pipelineStepNoteSearchForm';
import { WrappedPipelineStepStatusCreateComponent } from './components/pipelineStepStatus/pipelineStepStatusCreateForm';
import { WrappedPipelineStepStatusDetailComponent } from './components/pipelineStepStatus/pipelineStepStatusDetailForm';
import { WrappedPipelineStepStatusEditComponent } from './components/pipelineStepStatus/pipelineStepStatusEditForm';
import { WrappedPipelineStepStatusSearchComponent } from './components/pipelineStepStatus/pipelineStepStatusSearchForm';
import { WrappedPipelineStepStepRequirementCreateComponent } from './components/pipelineStepStepRequirement/pipelineStepStepRequirementCreateForm';
import { WrappedPipelineStepStepRequirementDetailComponent } from './components/pipelineStepStepRequirement/pipelineStepStepRequirementDetailForm';
import { WrappedPipelineStepStepRequirementEditComponent } from './components/pipelineStepStepRequirement/pipelineStepStepRequirementEditForm';
import { WrappedPipelineStepStepRequirementSearchComponent } from './components/pipelineStepStepRequirement/pipelineStepStepRequirementSearchForm';
import { WrappedSaleCreateComponent } from './components/sale/saleCreateForm';
import { WrappedSaleDetailComponent } from './components/sale/saleDetailForm';
import { WrappedSaleEditComponent } from './components/sale/saleEditForm';
import { WrappedSaleSearchComponent } from './components/sale/saleSearchForm';
import { WrappedSpeciesCreateComponent } from './components/species/speciesCreateForm';
import { WrappedSpeciesDetailComponent } from './components/species/speciesDetailForm';
import { WrappedSpeciesEditComponent } from './components/species/speciesEditForm';
import { WrappedSpeciesSearchComponent } from './components/species/speciesSearchForm';

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
          path={ClientRoutes.Airlines + '/create'}
          component={wrapperHeader(
            WrappedAirlineCreateComponent,
            'Airline Create'
          )}
        />
        <Route
          path={ClientRoutes.Airlines + '/edit/:id'}
          component={wrapperHeader(WrappedAirlineEditComponent, 'Airline Edit')}
        />
        <Route
          path={ClientRoutes.Airlines + '/:id'}
          component={wrapperHeader(
            WrappedAirlineDetailComponent,
            'Airline Detail'
          )}
        />
        <Route
          path={ClientRoutes.Airlines}
          component={wrapperHeader(
            WrappedAirlineSearchComponent,
            'Airline Search'
          )}
        />
        <Route
          path={ClientRoutes.AirTransports + '/create'}
          component={wrapperHeader(
            WrappedAirTransportCreateComponent,
            'Air Transport Create'
          )}
        />
        <Route
          path={ClientRoutes.AirTransports + '/edit/:id'}
          component={wrapperHeader(
            WrappedAirTransportEditComponent,
            'Air Transport Edit'
          )}
        />
        <Route
          path={ClientRoutes.AirTransports + '/:id'}
          component={wrapperHeader(
            WrappedAirTransportDetailComponent,
            'Air Transport Detail'
          )}
        />
        <Route
          path={ClientRoutes.AirTransports}
          component={wrapperHeader(
            WrappedAirTransportSearchComponent,
            'Air Transport Search'
          )}
        />
        <Route
          path={ClientRoutes.Breeds + '/create'}
          component={wrapperHeader(WrappedBreedCreateComponent, 'Breed Create')}
        />
        <Route
          path={ClientRoutes.Breeds + '/edit/:id'}
          component={wrapperHeader(WrappedBreedEditComponent, 'Breed Edit')}
        />
        <Route
          path={ClientRoutes.Breeds + '/:id'}
          component={wrapperHeader(WrappedBreedDetailComponent, 'Breed Detail')}
        />
        <Route
          path={ClientRoutes.Breeds}
          component={wrapperHeader(WrappedBreedSearchComponent, 'Breed Search')}
        />
        <Route
          path={ClientRoutes.Countries + '/create'}
          component={wrapperHeader(
            WrappedCountryCreateComponent,
            'Country Create'
          )}
        />
        <Route
          path={ClientRoutes.Countries + '/edit/:id'}
          component={wrapperHeader(WrappedCountryEditComponent, 'Country Edit')}
        />
        <Route
          path={ClientRoutes.Countries + '/:id'}
          component={wrapperHeader(
            WrappedCountryDetailComponent,
            'Country Detail'
          )}
        />
        <Route
          path={ClientRoutes.Countries}
          component={wrapperHeader(
            WrappedCountrySearchComponent,
            'Country Search'
          )}
        />
        <Route
          path={ClientRoutes.CountryRequirements + '/create'}
          component={wrapperHeader(
            WrappedCountryRequirementCreateComponent,
            'Country Requirement Create'
          )}
        />
        <Route
          path={ClientRoutes.CountryRequirements + '/edit/:id'}
          component={wrapperHeader(
            WrappedCountryRequirementEditComponent,
            'Country Requirement Edit'
          )}
        />
        <Route
          path={ClientRoutes.CountryRequirements + '/:id'}
          component={wrapperHeader(
            WrappedCountryRequirementDetailComponent,
            'Country Requirement Detail'
          )}
        />
        <Route
          path={ClientRoutes.CountryRequirements}
          component={wrapperHeader(
            WrappedCountryRequirementSearchComponent,
            'Country Requirement Search'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/create'}
          component={wrapperHeader(
            WrappedCustomerCreateComponent,
            'Customer Create'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/edit/:id'}
          component={wrapperHeader(
            WrappedCustomerEditComponent,
            'Customer Edit'
          )}
        />
        <Route
          path={ClientRoutes.Customers + '/:id'}
          component={wrapperHeader(
            WrappedCustomerDetailComponent,
            'Customer Detail'
          )}
        />
        <Route
          path={ClientRoutes.Customers}
          component={wrapperHeader(
            WrappedCustomerSearchComponent,
            'Customer Search'
          )}
        />
        <Route
          path={ClientRoutes.CustomerCommunications + '/create'}
          component={wrapperHeader(
            WrappedCustomerCommunicationCreateComponent,
            'Customer Communication Create'
          )}
        />
        <Route
          path={ClientRoutes.CustomerCommunications + '/edit/:id'}
          component={wrapperHeader(
            WrappedCustomerCommunicationEditComponent,
            'Customer Communication Edit'
          )}
        />
        <Route
          path={ClientRoutes.CustomerCommunications + '/:id'}
          component={wrapperHeader(
            WrappedCustomerCommunicationDetailComponent,
            'Customer Communication Detail'
          )}
        />
        <Route
          path={ClientRoutes.CustomerCommunications}
          component={wrapperHeader(
            WrappedCustomerCommunicationSearchComponent,
            'Customer Communication Search'
          )}
        />
        <Route
          path={ClientRoutes.Destinations + '/create'}
          component={wrapperHeader(
            WrappedDestinationCreateComponent,
            'Destination Create'
          )}
        />
        <Route
          path={ClientRoutes.Destinations + '/edit/:id'}
          component={wrapperHeader(
            WrappedDestinationEditComponent,
            'Destination Edit'
          )}
        />
        <Route
          path={ClientRoutes.Destinations + '/:id'}
          component={wrapperHeader(
            WrappedDestinationDetailComponent,
            'Destination Detail'
          )}
        />
        <Route
          path={ClientRoutes.Destinations}
          component={wrapperHeader(
            WrappedDestinationSearchComponent,
            'Destination Search'
          )}
        />
        <Route
          path={ClientRoutes.Employees + '/create'}
          component={wrapperHeader(
            WrappedEmployeeCreateComponent,
            'Employee Create'
          )}
        />
        <Route
          path={ClientRoutes.Employees + '/edit/:id'}
          component={wrapperHeader(
            WrappedEmployeeEditComponent,
            'Employee Edit'
          )}
        />
        <Route
          path={ClientRoutes.Employees + '/:id'}
          component={wrapperHeader(
            WrappedEmployeeDetailComponent,
            'Employee Detail'
          )}
        />
        <Route
          path={ClientRoutes.Employees}
          component={wrapperHeader(
            WrappedEmployeeSearchComponent,
            'Employee Search'
          )}
        />
        <Route
          path={ClientRoutes.Handlers + '/create'}
          component={wrapperHeader(
            WrappedHandlerCreateComponent,
            'Handler Create'
          )}
        />
        <Route
          path={ClientRoutes.Handlers + '/edit/:id'}
          component={wrapperHeader(WrappedHandlerEditComponent, 'Handler Edit')}
        />
        <Route
          path={ClientRoutes.Handlers + '/:id'}
          component={wrapperHeader(
            WrappedHandlerDetailComponent,
            'Handler Detail'
          )}
        />
        <Route
          path={ClientRoutes.Handlers}
          component={wrapperHeader(
            WrappedHandlerSearchComponent,
            'Handler Search'
          )}
        />
        <Route
          path={ClientRoutes.HandlerPipelineSteps + '/create'}
          component={wrapperHeader(
            WrappedHandlerPipelineStepCreateComponent,
            'Handler Pipeline Step Create'
          )}
        />
        <Route
          path={ClientRoutes.HandlerPipelineSteps + '/edit/:id'}
          component={wrapperHeader(
            WrappedHandlerPipelineStepEditComponent,
            'Handler Pipeline Step Edit'
          )}
        />
        <Route
          path={ClientRoutes.HandlerPipelineSteps + '/:id'}
          component={wrapperHeader(
            WrappedHandlerPipelineStepDetailComponent,
            'Handler Pipeline Step Detail'
          )}
        />
        <Route
          path={ClientRoutes.HandlerPipelineSteps}
          component={wrapperHeader(
            WrappedHandlerPipelineStepSearchComponent,
            'Handler Pipeline Step Search'
          )}
        />
        <Route
          path={ClientRoutes.OtherTransports + '/create'}
          component={wrapperHeader(
            WrappedOtherTransportCreateComponent,
            'Other Transport Create'
          )}
        />
        <Route
          path={ClientRoutes.OtherTransports + '/edit/:id'}
          component={wrapperHeader(
            WrappedOtherTransportEditComponent,
            'Other Transport Edit'
          )}
        />
        <Route
          path={ClientRoutes.OtherTransports + '/:id'}
          component={wrapperHeader(
            WrappedOtherTransportDetailComponent,
            'Other Transport Detail'
          )}
        />
        <Route
          path={ClientRoutes.OtherTransports}
          component={wrapperHeader(
            WrappedOtherTransportSearchComponent,
            'Other Transport Search'
          )}
        />
        <Route
          path={ClientRoutes.Pets + '/create'}
          component={wrapperHeader(WrappedPetCreateComponent, 'Pet Create')}
        />
        <Route
          path={ClientRoutes.Pets + '/edit/:id'}
          component={wrapperHeader(WrappedPetEditComponent, 'Pet Edit')}
        />
        <Route
          path={ClientRoutes.Pets + '/:id'}
          component={wrapperHeader(WrappedPetDetailComponent, 'Pet Detail')}
        />
        <Route
          path={ClientRoutes.Pets}
          component={wrapperHeader(WrappedPetSearchComponent, 'Pet Search')}
        />
        <Route
          path={ClientRoutes.Pipelines + '/create'}
          component={wrapperHeader(
            WrappedPipelineCreateComponent,
            'Pipeline Create'
          )}
        />
        <Route
          path={ClientRoutes.Pipelines + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineEditComponent,
            'Pipeline Edit'
          )}
        />
        <Route
          path={ClientRoutes.Pipelines + '/:id'}
          component={wrapperHeader(
            WrappedPipelineDetailComponent,
            'Pipeline Detail'
          )}
        />
        <Route
          path={ClientRoutes.Pipelines}
          component={wrapperHeader(
            WrappedPipelineSearchComponent,
            'Pipeline Search'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStatus + '/create'}
          component={wrapperHeader(
            WrappedPipelineStatusCreateComponent,
            'Pipeline Status Create'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineStatusEditComponent,
            'Pipeline Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStatus + '/:id'}
          component={wrapperHeader(
            WrappedPipelineStatusDetailComponent,
            'Pipeline Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStatus}
          component={wrapperHeader(
            WrappedPipelineStatusSearchComponent,
            'Pipeline Status Search'
          )}
        />
        <Route
          path={ClientRoutes.PipelineSteps + '/create'}
          component={wrapperHeader(
            WrappedPipelineStepCreateComponent,
            'Pipeline Step Create'
          )}
        />
        <Route
          path={ClientRoutes.PipelineSteps + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineStepEditComponent,
            'Pipeline Step Edit'
          )}
        />
        <Route
          path={ClientRoutes.PipelineSteps + '/:id'}
          component={wrapperHeader(
            WrappedPipelineStepDetailComponent,
            'Pipeline Step Detail'
          )}
        />
        <Route
          path={ClientRoutes.PipelineSteps}
          component={wrapperHeader(
            WrappedPipelineStepSearchComponent,
            'Pipeline Step Search'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepDestinations + '/create'}
          component={wrapperHeader(
            WrappedPipelineStepDestinationCreateComponent,
            'Pipeline Step Destination Create'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepDestinations + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineStepDestinationEditComponent,
            'Pipeline Step Destination Edit'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepDestinations + '/:id'}
          component={wrapperHeader(
            WrappedPipelineStepDestinationDetailComponent,
            'Pipeline Step Destination Detail'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepDestinations}
          component={wrapperHeader(
            WrappedPipelineStepDestinationSearchComponent,
            'Pipeline Step Destination Search'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepNotes + '/create'}
          component={wrapperHeader(
            WrappedPipelineStepNoteCreateComponent,
            'Pipeline Step Note Create'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepNotes + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineStepNoteEditComponent,
            'Pipeline Step Note Edit'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepNotes + '/:id'}
          component={wrapperHeader(
            WrappedPipelineStepNoteDetailComponent,
            'Pipeline Step Note Detail'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepNotes}
          component={wrapperHeader(
            WrappedPipelineStepNoteSearchComponent,
            'Pipeline Step Note Search'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStatus + '/create'}
          component={wrapperHeader(
            WrappedPipelineStepStatusCreateComponent,
            'Pipeline Step Status Create'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineStepStatusEditComponent,
            'Pipeline Step Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStatus + '/:id'}
          component={wrapperHeader(
            WrappedPipelineStepStatusDetailComponent,
            'Pipeline Step Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStatus}
          component={wrapperHeader(
            WrappedPipelineStepStatusSearchComponent,
            'Pipeline Step Status Search'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStepRequirements + '/create'}
          component={wrapperHeader(
            WrappedPipelineStepStepRequirementCreateComponent,
            'Pipeline Step Step Requirement Create'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStepRequirements + '/edit/:id'}
          component={wrapperHeader(
            WrappedPipelineStepStepRequirementEditComponent,
            'Pipeline Step Step Requirement Edit'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStepRequirements + '/:id'}
          component={wrapperHeader(
            WrappedPipelineStepStepRequirementDetailComponent,
            'Pipeline Step Step Requirement Detail'
          )}
        />
        <Route
          path={ClientRoutes.PipelineStepStepRequirements}
          component={wrapperHeader(
            WrappedPipelineStepStepRequirementSearchComponent,
            'Pipeline Step Step Requirement Search'
          )}
        />
        <Route
          path={ClientRoutes.Sales + '/create'}
          component={wrapperHeader(WrappedSaleCreateComponent, 'Sale Create')}
        />
        <Route
          path={ClientRoutes.Sales + '/edit/:id'}
          component={wrapperHeader(WrappedSaleEditComponent, 'Sale Edit')}
        />
        <Route
          path={ClientRoutes.Sales + '/:id'}
          component={wrapperHeader(WrappedSaleDetailComponent, 'Sale Detail')}
        />
        <Route
          path={ClientRoutes.Sales}
          component={wrapperHeader(WrappedSaleSearchComponent, 'Sale Search')}
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
          component={wrapperHeader(WrappedSpeciesEditComponent, 'Species Edit')}
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
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>944234a3b6e47d726d6fe9e9ef5cc1c5</Hash>
</Codenesium>*/