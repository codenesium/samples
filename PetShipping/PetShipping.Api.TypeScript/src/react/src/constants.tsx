export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedBaseUrl =
    window.location.protocol + '//' + window.location.host;
  static readonly HostedSubDirectory =
    process.env.REACT_APP_HOST_SUBDIRECTORY == '/'
      ? ''
      : '/' + process.env.REACT_APP_HOST_SUBDIRECTORY;
  static readonly HostedUrl =
    Constants.HostedBaseUrl + Constants.HostedSubDirectory;
}

export class AuthClientRoutes {
  static readonly Login = '/login';
  static readonly Logout = '/logout';
  static readonly Register = '/register';
  static readonly ResetPassword = '/resetpassword';
  static readonly ConfirmRegistration = '/confirmregistration';
  static readonly ConfirmPasswordReset = '/confirmpasswordreset';
  static readonly ChangePassword = '/changepassword';
}

export class AuthApiRoutes {
  static readonly Login = 'auth/login';
  static readonly Register = 'auth/register';
  static readonly ResetPassword = 'auth/resetpassword';
  static readonly ConfirmRegistration = 'auth/confirmregistration';
  static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';
  static readonly ChangePassword = 'auth/changepassword';
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
    <Hash>b4c2ceade842f899adde1a815e280920</Hash>
</Codenesium>*/