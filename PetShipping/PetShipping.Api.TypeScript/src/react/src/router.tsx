import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import AirlineCreateComponent from './components/airline/airlineCreateForm';
import AirlineDetailComponent from './components/airline/airlineDetailForm';
import AirlineEditComponent from './components/airline/airlineEditForm';
import AirlineSearchComponent from './components/airline/airlineSearchForm';
import AirTransportCreateComponent from './components/airTransport/airTransportCreateForm';
import AirTransportDetailComponent from './components/airTransport/airTransportDetailForm';
import AirTransportEditComponent from './components/airTransport/airTransportEditForm';
import AirTransportSearchComponent from './components/airTransport/airTransportSearchForm';
import BreedCreateComponent from './components/breed/breedCreateForm';
import BreedDetailComponent from './components/breed/breedDetailForm';
import BreedEditComponent from './components/breed/breedEditForm';
import BreedSearchComponent from './components/breed/breedSearchForm';
import CountryCreateComponent from './components/country/countryCreateForm';
import CountryDetailComponent from './components/country/countryDetailForm';
import CountryEditComponent from './components/country/countryEditForm';
import CountrySearchComponent from './components/country/countrySearchForm';
import CountryRequirementCreateComponent from './components/countryRequirement/countryRequirementCreateForm';
import CountryRequirementDetailComponent from './components/countryRequirement/countryRequirementDetailForm';
import CountryRequirementEditComponent from './components/countryRequirement/countryRequirementEditForm';
import CountryRequirementSearchComponent from './components/countryRequirement/countryRequirementSearchForm';
import CustomerCreateComponent from './components/customer/customerCreateForm';
import CustomerDetailComponent from './components/customer/customerDetailForm';
import CustomerEditComponent from './components/customer/customerEditForm';
import CustomerSearchComponent from './components/customer/customerSearchForm';
import CustomerCommunicationCreateComponent from './components/customerCommunication/customerCommunicationCreateForm';
import CustomerCommunicationDetailComponent from './components/customerCommunication/customerCommunicationDetailForm';
import CustomerCommunicationEditComponent from './components/customerCommunication/customerCommunicationEditForm';
import CustomerCommunicationSearchComponent from './components/customerCommunication/customerCommunicationSearchForm';
import DestinationCreateComponent from './components/destination/destinationCreateForm';
import DestinationDetailComponent from './components/destination/destinationDetailForm';
import DestinationEditComponent from './components/destination/destinationEditForm';
import DestinationSearchComponent from './components/destination/destinationSearchForm';
import EmployeeCreateComponent from './components/employee/employeeCreateForm';
import EmployeeDetailComponent from './components/employee/employeeDetailForm';
import EmployeeEditComponent from './components/employee/employeeEditForm';
import EmployeeSearchComponent from './components/employee/employeeSearchForm';
import HandlerCreateComponent from './components/handler/handlerCreateForm';
import HandlerDetailComponent from './components/handler/handlerDetailForm';
import HandlerEditComponent from './components/handler/handlerEditForm';
import HandlerSearchComponent from './components/handler/handlerSearchForm';
import HandlerPipelineStepCreateComponent from './components/handlerPipelineStep/handlerPipelineStepCreateForm';
import HandlerPipelineStepDetailComponent from './components/handlerPipelineStep/handlerPipelineStepDetailForm';
import HandlerPipelineStepEditComponent from './components/handlerPipelineStep/handlerPipelineStepEditForm';
import HandlerPipelineStepSearchComponent from './components/handlerPipelineStep/handlerPipelineStepSearchForm';
import OtherTransportCreateComponent from './components/otherTransport/otherTransportCreateForm';
import OtherTransportDetailComponent from './components/otherTransport/otherTransportDetailForm';
import OtherTransportEditComponent from './components/otherTransport/otherTransportEditForm';
import OtherTransportSearchComponent from './components/otherTransport/otherTransportSearchForm';
import PetCreateComponent from './components/pet/petCreateForm';
import PetDetailComponent from './components/pet/petDetailForm';
import PetEditComponent from './components/pet/petEditForm';
import PetSearchComponent from './components/pet/petSearchForm';
import PipelineCreateComponent from './components/pipeline/pipelineCreateForm';
import PipelineDetailComponent from './components/pipeline/pipelineDetailForm';
import PipelineEditComponent from './components/pipeline/pipelineEditForm';
import PipelineSearchComponent from './components/pipeline/pipelineSearchForm';
import PipelineStatuCreateComponent from './components/pipelineStatu/pipelineStatuCreateForm';
import PipelineStatuDetailComponent from './components/pipelineStatu/pipelineStatuDetailForm';
import PipelineStatuEditComponent from './components/pipelineStatu/pipelineStatuEditForm';
import PipelineStatuSearchComponent from './components/pipelineStatu/pipelineStatuSearchForm';
import PipelineStepCreateComponent from './components/pipelineStep/pipelineStepCreateForm';
import PipelineStepDetailComponent from './components/pipelineStep/pipelineStepDetailForm';
import PipelineStepEditComponent from './components/pipelineStep/pipelineStepEditForm';
import PipelineStepSearchComponent from './components/pipelineStep/pipelineStepSearchForm';
import PipelineStepDestinationCreateComponent from './components/pipelineStepDestination/pipelineStepDestinationCreateForm';
import PipelineStepDestinationDetailComponent from './components/pipelineStepDestination/pipelineStepDestinationDetailForm';
import PipelineStepDestinationEditComponent from './components/pipelineStepDestination/pipelineStepDestinationEditForm';
import PipelineStepDestinationSearchComponent from './components/pipelineStepDestination/pipelineStepDestinationSearchForm';
import PipelineStepNoteCreateComponent from './components/pipelineStepNote/pipelineStepNoteCreateForm';
import PipelineStepNoteDetailComponent from './components/pipelineStepNote/pipelineStepNoteDetailForm';
import PipelineStepNoteEditComponent from './components/pipelineStepNote/pipelineStepNoteEditForm';
import PipelineStepNoteSearchComponent from './components/pipelineStepNote/pipelineStepNoteSearchForm';
import PipelineStepStatuCreateComponent from './components/pipelineStepStatu/pipelineStepStatuCreateForm';
import PipelineStepStatuDetailComponent from './components/pipelineStepStatu/pipelineStepStatuDetailForm';
import PipelineStepStatuEditComponent from './components/pipelineStepStatu/pipelineStepStatuEditForm';
import PipelineStepStatuSearchComponent from './components/pipelineStepStatu/pipelineStepStatuSearchForm';
import PipelineStepStepRequirementCreateComponent from './components/pipelineStepStepRequirement/pipelineStepStepRequirementCreateForm';
import PipelineStepStepRequirementDetailComponent from './components/pipelineStepStepRequirement/pipelineStepStepRequirementDetailForm';
import PipelineStepStepRequirementEditComponent from './components/pipelineStepStepRequirement/pipelineStepStepRequirementEditForm';
import PipelineStepStepRequirementSearchComponent from './components/pipelineStepStepRequirement/pipelineStepStepRequirementSearchForm';
import SaleCreateComponent from './components/sale/saleCreateForm';
import SaleDetailComponent from './components/sale/saleDetailForm';
import SaleEditComponent from './components/sale/saleEditForm';
import SaleSearchComponent from './components/sale/saleSearchForm';
import SpeciesCreateComponent from './components/species/speciesCreateForm';
import SpeciesDetailComponent from './components/species/speciesDetailForm';
import SpeciesEditComponent from './components/species/speciesEditForm';
import SpeciesSearchComponent from './components/species/speciesSearchForm';

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
            <Route path="/airlines/create" component={AirlineCreateComponent} />
            <Route path="/airlines/edit/:id" component={AirlineEditComponent} />
            <Route path="/airlines/:id" component={AirlineDetailComponent} />
            <Route path="/airlines" component={AirlineSearchComponent} />
            <Route
              path="/airtransports/create"
              component={AirTransportCreateComponent}
            />
            <Route
              path="/airtransports/edit/:id"
              component={AirTransportEditComponent}
            />
            <Route
              path="/airtransports/:id"
              component={AirTransportDetailComponent}
            />
            <Route
              path="/airtransports"
              component={AirTransportSearchComponent}
            />
            <Route path="/breeds/create" component={BreedCreateComponent} />
            <Route path="/breeds/edit/:id" component={BreedEditComponent} />
            <Route path="/breeds/:id" component={BreedDetailComponent} />
            <Route path="/breeds" component={BreedSearchComponent} />
            <Route
              path="/countries/create"
              component={CountryCreateComponent}
            />
            <Route
              path="/countries/edit/:id"
              component={CountryEditComponent}
            />
            <Route path="/countries/:id" component={CountryDetailComponent} />
            <Route path="/countries" component={CountrySearchComponent} />
            <Route
              path="/countryrequirements/create"
              component={CountryRequirementCreateComponent}
            />
            <Route
              path="/countryrequirements/edit/:id"
              component={CountryRequirementEditComponent}
            />
            <Route
              path="/countryrequirements/:id"
              component={CountryRequirementDetailComponent}
            />
            <Route
              path="/countryrequirements"
              component={CountryRequirementSearchComponent}
            />
            <Route
              path="/customers/create"
              component={CustomerCreateComponent}
            />
            <Route
              path="/customers/edit/:id"
              component={CustomerEditComponent}
            />
            <Route path="/customers/:id" component={CustomerDetailComponent} />
            <Route path="/customers" component={CustomerSearchComponent} />
            <Route
              path="/customercommunications/create"
              component={CustomerCommunicationCreateComponent}
            />
            <Route
              path="/customercommunications/edit/:id"
              component={CustomerCommunicationEditComponent}
            />
            <Route
              path="/customercommunications/:id"
              component={CustomerCommunicationDetailComponent}
            />
            <Route
              path="/customercommunications"
              component={CustomerCommunicationSearchComponent}
            />
            <Route
              path="/destinations/create"
              component={DestinationCreateComponent}
            />
            <Route
              path="/destinations/edit/:id"
              component={DestinationEditComponent}
            />
            <Route
              path="/destinations/:id"
              component={DestinationDetailComponent}
            />
            <Route
              path="/destinations"
              component={DestinationSearchComponent}
            />
            <Route
              path="/employees/create"
              component={EmployeeCreateComponent}
            />
            <Route
              path="/employees/edit/:id"
              component={EmployeeEditComponent}
            />
            <Route path="/employees/:id" component={EmployeeDetailComponent} />
            <Route path="/employees" component={EmployeeSearchComponent} />
            <Route path="/handlers/create" component={HandlerCreateComponent} />
            <Route path="/handlers/edit/:id" component={HandlerEditComponent} />
            <Route path="/handlers/:id" component={HandlerDetailComponent} />
            <Route path="/handlers" component={HandlerSearchComponent} />
            <Route
              path="/handlerpipelinesteps/create"
              component={HandlerPipelineStepCreateComponent}
            />
            <Route
              path="/handlerpipelinesteps/edit/:id"
              component={HandlerPipelineStepEditComponent}
            />
            <Route
              path="/handlerpipelinesteps/:id"
              component={HandlerPipelineStepDetailComponent}
            />
            <Route
              path="/handlerpipelinesteps"
              component={HandlerPipelineStepSearchComponent}
            />
            <Route
              path="/othertransports/create"
              component={OtherTransportCreateComponent}
            />
            <Route
              path="/othertransports/edit/:id"
              component={OtherTransportEditComponent}
            />
            <Route
              path="/othertransports/:id"
              component={OtherTransportDetailComponent}
            />
            <Route
              path="/othertransports"
              component={OtherTransportSearchComponent}
            />
            <Route path="/pets/create" component={PetCreateComponent} />
            <Route path="/pets/edit/:id" component={PetEditComponent} />
            <Route path="/pets/:id" component={PetDetailComponent} />
            <Route path="/pets" component={PetSearchComponent} />
            <Route
              path="/pipelines/create"
              component={PipelineCreateComponent}
            />
            <Route
              path="/pipelines/edit/:id"
              component={PipelineEditComponent}
            />
            <Route path="/pipelines/:id" component={PipelineDetailComponent} />
            <Route path="/pipelines" component={PipelineSearchComponent} />
            <Route
              path="/pipelinestatus/create"
              component={PipelineStatuCreateComponent}
            />
            <Route
              path="/pipelinestatus/edit/:id"
              component={PipelineStatuEditComponent}
            />
            <Route
              path="/pipelinestatus/:id"
              component={PipelineStatuDetailComponent}
            />
            <Route
              path="/pipelinestatus"
              component={PipelineStatuSearchComponent}
            />
            <Route
              path="/pipelinesteps/create"
              component={PipelineStepCreateComponent}
            />
            <Route
              path="/pipelinesteps/edit/:id"
              component={PipelineStepEditComponent}
            />
            <Route
              path="/pipelinesteps/:id"
              component={PipelineStepDetailComponent}
            />
            <Route
              path="/pipelinesteps"
              component={PipelineStepSearchComponent}
            />
            <Route
              path="/pipelinestepdestinations/create"
              component={PipelineStepDestinationCreateComponent}
            />
            <Route
              path="/pipelinestepdestinations/edit/:id"
              component={PipelineStepDestinationEditComponent}
            />
            <Route
              path="/pipelinestepdestinations/:id"
              component={PipelineStepDestinationDetailComponent}
            />
            <Route
              path="/pipelinestepdestinations"
              component={PipelineStepDestinationSearchComponent}
            />
            <Route
              path="/pipelinestepnotes/create"
              component={PipelineStepNoteCreateComponent}
            />
            <Route
              path="/pipelinestepnotes/edit/:id"
              component={PipelineStepNoteEditComponent}
            />
            <Route
              path="/pipelinestepnotes/:id"
              component={PipelineStepNoteDetailComponent}
            />
            <Route
              path="/pipelinestepnotes"
              component={PipelineStepNoteSearchComponent}
            />
            <Route
              path="/pipelinestepstatus/create"
              component={PipelineStepStatuCreateComponent}
            />
            <Route
              path="/pipelinestepstatus/edit/:id"
              component={PipelineStepStatuEditComponent}
            />
            <Route
              path="/pipelinestepstatus/:id"
              component={PipelineStepStatuDetailComponent}
            />
            <Route
              path="/pipelinestepstatus"
              component={PipelineStepStatuSearchComponent}
            />
            <Route
              path="/pipelinestepsteprequirements/create"
              component={PipelineStepStepRequirementCreateComponent}
            />
            <Route
              path="/pipelinestepsteprequirements/edit/:id"
              component={PipelineStepStepRequirementEditComponent}
            />
            <Route
              path="/pipelinestepsteprequirements/:id"
              component={PipelineStepStepRequirementDetailComponent}
            />
            <Route
              path="/pipelinestepsteprequirements"
              component={PipelineStepStepRequirementSearchComponent}
            />
            <Route path="/sales/create" component={SaleCreateComponent} />
            <Route path="/sales/edit/:id" component={SaleEditComponent} />
            <Route path="/sales/:id" component={SaleDetailComponent} />
            <Route path="/sales" component={SaleSearchComponent} />
            <Route path="/species/create" component={SpeciesCreateComponent} />
            <Route path="/species/edit/:id" component={SpeciesEditComponent} />
            <Route path="/species/:id" component={SpeciesDetailComponent} />
            <Route path="/species" component={SpeciesSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>476e468eee1280017646d4a9c1df3f3d</Hash>
</Codenesium>*/