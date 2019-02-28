import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
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
		  <Route path={ClientRoutes.Airlines + "/create"} component={wrapperHeader(WrappedAirlineCreateComponent, "Airlines Create")} />
                      <Route path={ClientRoutes.Airlines + "/edit/:id"} component={wrapperHeader(WrappedAirlineEditComponent, "Airlines Edit")} />
                      <Route path={ClientRoutes.Airlines + "/:id"} component={wrapperHeader(WrappedAirlineDetailComponent , "Airlines Detail")} />
                      <Route path={ClientRoutes.Airlines} component={wrapperHeader(WrappedAirlineSearchComponent, "Airlines Search")} />
					<Route path={ClientRoutes.AirTransports + "/create"} component={wrapperHeader(WrappedAirTransportCreateComponent, "AirTransports Create")} />
                      <Route path={ClientRoutes.AirTransports + "/edit/:id"} component={wrapperHeader(WrappedAirTransportEditComponent, "AirTransports Edit")} />
                      <Route path={ClientRoutes.AirTransports + "/:id"} component={wrapperHeader(WrappedAirTransportDetailComponent , "AirTransports Detail")} />
                      <Route path={ClientRoutes.AirTransports} component={wrapperHeader(WrappedAirTransportSearchComponent, "AirTransports Search")} />
					<Route path={ClientRoutes.Breeds + "/create"} component={wrapperHeader(WrappedBreedCreateComponent, "Breeds Create")} />
                      <Route path={ClientRoutes.Breeds + "/edit/:id"} component={wrapperHeader(WrappedBreedEditComponent, "Breeds Edit")} />
                      <Route path={ClientRoutes.Breeds + "/:id"} component={wrapperHeader(WrappedBreedDetailComponent , "Breeds Detail")} />
                      <Route path={ClientRoutes.Breeds} component={wrapperHeader(WrappedBreedSearchComponent, "Breeds Search")} />
					<Route path={ClientRoutes.Countries + "/create"} component={wrapperHeader(WrappedCountryCreateComponent, "Countries Create")} />
                      <Route path={ClientRoutes.Countries + "/edit/:id"} component={wrapperHeader(WrappedCountryEditComponent, "Countries Edit")} />
                      <Route path={ClientRoutes.Countries + "/:id"} component={wrapperHeader(WrappedCountryDetailComponent , "Countries Detail")} />
                      <Route path={ClientRoutes.Countries} component={wrapperHeader(WrappedCountrySearchComponent, "Countries Search")} />
					<Route path={ClientRoutes.CountryRequirements + "/create"} component={wrapperHeader(WrappedCountryRequirementCreateComponent, "CountryRequirements Create")} />
                      <Route path={ClientRoutes.CountryRequirements + "/edit/:id"} component={wrapperHeader(WrappedCountryRequirementEditComponent, "CountryRequirements Edit")} />
                      <Route path={ClientRoutes.CountryRequirements + "/:id"} component={wrapperHeader(WrappedCountryRequirementDetailComponent , "CountryRequirements Detail")} />
                      <Route path={ClientRoutes.CountryRequirements} component={wrapperHeader(WrappedCountryRequirementSearchComponent, "CountryRequirements Search")} />
					<Route path={ClientRoutes.Customers + "/create"} component={wrapperHeader(WrappedCustomerCreateComponent, "Customers Create")} />
                      <Route path={ClientRoutes.Customers + "/edit/:id"} component={wrapperHeader(WrappedCustomerEditComponent, "Customers Edit")} />
                      <Route path={ClientRoutes.Customers + "/:id"} component={wrapperHeader(WrappedCustomerDetailComponent , "Customers Detail")} />
                      <Route path={ClientRoutes.Customers} component={wrapperHeader(WrappedCustomerSearchComponent, "Customers Search")} />
					<Route path={ClientRoutes.CustomerCommunications + "/create"} component={wrapperHeader(WrappedCustomerCommunicationCreateComponent, "CustomerCommunications Create")} />
                      <Route path={ClientRoutes.CustomerCommunications + "/edit/:id"} component={wrapperHeader(WrappedCustomerCommunicationEditComponent, "CustomerCommunications Edit")} />
                      <Route path={ClientRoutes.CustomerCommunications + "/:id"} component={wrapperHeader(WrappedCustomerCommunicationDetailComponent , "CustomerCommunications Detail")} />
                      <Route path={ClientRoutes.CustomerCommunications} component={wrapperHeader(WrappedCustomerCommunicationSearchComponent, "CustomerCommunications Search")} />
					<Route path={ClientRoutes.Destinations + "/create"} component={wrapperHeader(WrappedDestinationCreateComponent, "Destinations Create")} />
                      <Route path={ClientRoutes.Destinations + "/edit/:id"} component={wrapperHeader(WrappedDestinationEditComponent, "Destinations Edit")} />
                      <Route path={ClientRoutes.Destinations + "/:id"} component={wrapperHeader(WrappedDestinationDetailComponent , "Destinations Detail")} />
                      <Route path={ClientRoutes.Destinations} component={wrapperHeader(WrappedDestinationSearchComponent, "Destinations Search")} />
					<Route path={ClientRoutes.Employees + "/create"} component={wrapperHeader(WrappedEmployeeCreateComponent, "Employees Create")} />
                      <Route path={ClientRoutes.Employees + "/edit/:id"} component={wrapperHeader(WrappedEmployeeEditComponent, "Employees Edit")} />
                      <Route path={ClientRoutes.Employees + "/:id"} component={wrapperHeader(WrappedEmployeeDetailComponent , "Employees Detail")} />
                      <Route path={ClientRoutes.Employees} component={wrapperHeader(WrappedEmployeeSearchComponent, "Employees Search")} />
					<Route path={ClientRoutes.Handlers + "/create"} component={wrapperHeader(WrappedHandlerCreateComponent, "Handlers Create")} />
                      <Route path={ClientRoutes.Handlers + "/edit/:id"} component={wrapperHeader(WrappedHandlerEditComponent, "Handlers Edit")} />
                      <Route path={ClientRoutes.Handlers + "/:id"} component={wrapperHeader(WrappedHandlerDetailComponent , "Handlers Detail")} />
                      <Route path={ClientRoutes.Handlers} component={wrapperHeader(WrappedHandlerSearchComponent, "Handlers Search")} />
					<Route path={ClientRoutes.HandlerPipelineSteps + "/create"} component={wrapperHeader(WrappedHandlerPipelineStepCreateComponent, "HandlerPipelineSteps Create")} />
                      <Route path={ClientRoutes.HandlerPipelineSteps + "/edit/:id"} component={wrapperHeader(WrappedHandlerPipelineStepEditComponent, "HandlerPipelineSteps Edit")} />
                      <Route path={ClientRoutes.HandlerPipelineSteps + "/:id"} component={wrapperHeader(WrappedHandlerPipelineStepDetailComponent , "HandlerPipelineSteps Detail")} />
                      <Route path={ClientRoutes.HandlerPipelineSteps} component={wrapperHeader(WrappedHandlerPipelineStepSearchComponent, "HandlerPipelineSteps Search")} />
					<Route path={ClientRoutes.OtherTransports + "/create"} component={wrapperHeader(WrappedOtherTransportCreateComponent, "OtherTransports Create")} />
                      <Route path={ClientRoutes.OtherTransports + "/edit/:id"} component={wrapperHeader(WrappedOtherTransportEditComponent, "OtherTransports Edit")} />
                      <Route path={ClientRoutes.OtherTransports + "/:id"} component={wrapperHeader(WrappedOtherTransportDetailComponent , "OtherTransports Detail")} />
                      <Route path={ClientRoutes.OtherTransports} component={wrapperHeader(WrappedOtherTransportSearchComponent, "OtherTransports Search")} />
					<Route path={ClientRoutes.Pets + "/create"} component={wrapperHeader(WrappedPetCreateComponent, "Pets Create")} />
                      <Route path={ClientRoutes.Pets + "/edit/:id"} component={wrapperHeader(WrappedPetEditComponent, "Pets Edit")} />
                      <Route path={ClientRoutes.Pets + "/:id"} component={wrapperHeader(WrappedPetDetailComponent , "Pets Detail")} />
                      <Route path={ClientRoutes.Pets} component={wrapperHeader(WrappedPetSearchComponent, "Pets Search")} />
					<Route path={ClientRoutes.Pipelines + "/create"} component={wrapperHeader(WrappedPipelineCreateComponent, "Pipelines Create")} />
                      <Route path={ClientRoutes.Pipelines + "/edit/:id"} component={wrapperHeader(WrappedPipelineEditComponent, "Pipelines Edit")} />
                      <Route path={ClientRoutes.Pipelines + "/:id"} component={wrapperHeader(WrappedPipelineDetailComponent , "Pipelines Detail")} />
                      <Route path={ClientRoutes.Pipelines} component={wrapperHeader(WrappedPipelineSearchComponent, "Pipelines Search")} />
					<Route path={ClientRoutes.PipelineStatus + "/create"} component={wrapperHeader(WrappedPipelineStatusCreateComponent, "PipelineStatus Create")} />
                      <Route path={ClientRoutes.PipelineStatus + "/edit/:id"} component={wrapperHeader(WrappedPipelineStatusEditComponent, "PipelineStatus Edit")} />
                      <Route path={ClientRoutes.PipelineStatus + "/:id"} component={wrapperHeader(WrappedPipelineStatusDetailComponent , "PipelineStatus Detail")} />
                      <Route path={ClientRoutes.PipelineStatus} component={wrapperHeader(WrappedPipelineStatusSearchComponent, "PipelineStatus Search")} />
					<Route path={ClientRoutes.PipelineSteps + "/create"} component={wrapperHeader(WrappedPipelineStepCreateComponent, "PipelineSteps Create")} />
                      <Route path={ClientRoutes.PipelineSteps + "/edit/:id"} component={wrapperHeader(WrappedPipelineStepEditComponent, "PipelineSteps Edit")} />
                      <Route path={ClientRoutes.PipelineSteps + "/:id"} component={wrapperHeader(WrappedPipelineStepDetailComponent , "PipelineSteps Detail")} />
                      <Route path={ClientRoutes.PipelineSteps} component={wrapperHeader(WrappedPipelineStepSearchComponent, "PipelineSteps Search")} />
					<Route path={ClientRoutes.PipelineStepDestinations + "/create"} component={wrapperHeader(WrappedPipelineStepDestinationCreateComponent, "PipelineStepDestinations Create")} />
                      <Route path={ClientRoutes.PipelineStepDestinations + "/edit/:id"} component={wrapperHeader(WrappedPipelineStepDestinationEditComponent, "PipelineStepDestinations Edit")} />
                      <Route path={ClientRoutes.PipelineStepDestinations + "/:id"} component={wrapperHeader(WrappedPipelineStepDestinationDetailComponent , "PipelineStepDestinations Detail")} />
                      <Route path={ClientRoutes.PipelineStepDestinations} component={wrapperHeader(WrappedPipelineStepDestinationSearchComponent, "PipelineStepDestinations Search")} />
					<Route path={ClientRoutes.PipelineStepNotes + "/create"} component={wrapperHeader(WrappedPipelineStepNoteCreateComponent, "PipelineStepNotes Create")} />
                      <Route path={ClientRoutes.PipelineStepNotes + "/edit/:id"} component={wrapperHeader(WrappedPipelineStepNoteEditComponent, "PipelineStepNotes Edit")} />
                      <Route path={ClientRoutes.PipelineStepNotes + "/:id"} component={wrapperHeader(WrappedPipelineStepNoteDetailComponent , "PipelineStepNotes Detail")} />
                      <Route path={ClientRoutes.PipelineStepNotes} component={wrapperHeader(WrappedPipelineStepNoteSearchComponent, "PipelineStepNotes Search")} />
					<Route path={ClientRoutes.PipelineStepStatus + "/create"} component={wrapperHeader(WrappedPipelineStepStatusCreateComponent, "PipelineStepStatus Create")} />
                      <Route path={ClientRoutes.PipelineStepStatus + "/edit/:id"} component={wrapperHeader(WrappedPipelineStepStatusEditComponent, "PipelineStepStatus Edit")} />
                      <Route path={ClientRoutes.PipelineStepStatus + "/:id"} component={wrapperHeader(WrappedPipelineStepStatusDetailComponent , "PipelineStepStatus Detail")} />
                      <Route path={ClientRoutes.PipelineStepStatus} component={wrapperHeader(WrappedPipelineStepStatusSearchComponent, "PipelineStepStatus Search")} />
					<Route path={ClientRoutes.PipelineStepStepRequirements + "/create"} component={wrapperHeader(WrappedPipelineStepStepRequirementCreateComponent, "PipelineStepStepRequirements Create")} />
                      <Route path={ClientRoutes.PipelineStepStepRequirements + "/edit/:id"} component={wrapperHeader(WrappedPipelineStepStepRequirementEditComponent, "PipelineStepStepRequirements Edit")} />
                      <Route path={ClientRoutes.PipelineStepStepRequirements + "/:id"} component={wrapperHeader(WrappedPipelineStepStepRequirementDetailComponent , "PipelineStepStepRequirements Detail")} />
                      <Route path={ClientRoutes.PipelineStepStepRequirements} component={wrapperHeader(WrappedPipelineStepStepRequirementSearchComponent, "PipelineStepStepRequirements Search")} />
					<Route path={ClientRoutes.Sales + "/create"} component={wrapperHeader(WrappedSaleCreateComponent, "Sales Create")} />
                      <Route path={ClientRoutes.Sales + "/edit/:id"} component={wrapperHeader(WrappedSaleEditComponent, "Sales Edit")} />
                      <Route path={ClientRoutes.Sales + "/:id"} component={wrapperHeader(WrappedSaleDetailComponent , "Sales Detail")} />
                      <Route path={ClientRoutes.Sales} component={wrapperHeader(WrappedSaleSearchComponent, "Sales Search")} />
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
    <Hash>2be330fb2a9c93a9470e07b40a552883</Hash>
</Codenesium>*/