export class Constants {
  static readonly HostedBaseUrl =
    window.location.protocol + '//' + window.location.host;
  static readonly HostedSubDirectory =
    process.env.REACT_APP_HOST_SUBDIRECTORY === '/'
      ? ''
      : '/' + process.env.REACT_APP_HOST_SUBDIRECTORY;
  static readonly HostedUrl =
    Constants.HostedBaseUrl + Constants.HostedSubDirectory;
  static readonly BaseEndpoint =
    process.env.REACT_APP_API_URL == ''
      ? Constants.HostedUrl
      : process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'health';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class AuthClientRoutes {
  static readonly Login = '/login';
  static readonly Logout = '/logout';
  static readonly Register = '/register';
  static readonly ConfirmRegistration = '/confirmregistration';
  static readonly ResetPassword = '/resetpassword';
  static readonly ConfirmPasswordReset = '/confirmpasswordreset';
  static readonly ChangePassword = '/changepassword';
  static readonly ChangeEmail = '/changeemail';
  static readonly ConfirmChangeEmail = '/confirmchangeemail';
}

export class AuthApiRoutes {
  static readonly Login = 'auth/login';
  static readonly Register = 'auth/register';
  static readonly ConfirmRegistration = 'auth/confirmregistration';
  static readonly ResetPassword = 'auth/resetpassword';
  static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';
  static readonly ChangePassword = 'auth/changepassword';
  static readonly ChangeEmail = 'auth/changeemail';
  static readonly ConfirmChangeEmail = 'auth/confirmchangeemail';
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
    <Hash>aaaf59ebf243fea356876c6f4c9a12ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/