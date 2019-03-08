export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedSubDirectory = process.env.REACT_APP_HOST_SUBDIRECTORY;
}

export class ClientRoutes {
  static readonly Airlines = '/airlines';
  static readonly AirTransports = '/airtransports';
  static readonly Breeds = '/breeds';
  static readonly Countries = '/countries';
  static readonly CountryRequirements = '/countryrequirements';
  static readonly Customers = '/customers';
  static readonly CustomerCommunications = '/customercommunications';
  static readonly Destinations = '/destinations';
  static readonly Employees = '/employees';
  static readonly Handlers = '/handlers';
  static readonly HandlerPipelineSteps = '/handlerpipelinesteps';
  static readonly OtherTransports = '/othertransports';
  static readonly Pets = '/pets';
  static readonly Pipelines = '/pipelines';
  static readonly PipelineStatus = '/pipelinestatus';
  static readonly PipelineSteps = '/pipelinesteps';
  static readonly PipelineStepDestinations = '/pipelinestepdestinations';
  static readonly PipelineStepNotes = '/pipelinestepnotes';
  static readonly PipelineStepStatus = '/pipelinestepstatus';
  static readonly PipelineStepStepRequirements =
    '/pipelinestepsteprequirements';
  static readonly Sales = '/sales';
  static readonly Species = '/species';
}

export class ApiRoutes {
  static readonly Airlines = 'airlines';
  static readonly AirTransports = 'airtransports';
  static readonly Breeds = 'breeds';
  static readonly Countries = 'countries';
  static readonly CountryRequirements = 'countryrequirements';
  static readonly Customers = 'customers';
  static readonly CustomerCommunications = 'customercommunications';
  static readonly Destinations = 'destinations';
  static readonly Employees = 'employees';
  static readonly Handlers = 'handlers';
  static readonly HandlerPipelineSteps = 'handlerpipelinesteps';
  static readonly OtherTransports = 'othertransports';
  static readonly Pets = 'pets';
  static readonly Pipelines = 'pipelines';
  static readonly PipelineStatus = 'pipelinestatus';
  static readonly PipelineSteps = 'pipelinesteps';
  static readonly PipelineStepDestinations = 'pipelinestepdestinations';
  static readonly PipelineStepNotes = 'pipelinestepnotes';
  static readonly PipelineStepStatus = 'pipelinestepstatus';
  static readonly PipelineStepStepRequirements = 'pipelinestepsteprequirements';
  static readonly Sales = 'sales';
  static readonly Species = 'species';
}


/*<Codenesium>
    <Hash>db3998f9c21e7f9de553ab5ecf10a255</Hash>
</Codenesium>*/