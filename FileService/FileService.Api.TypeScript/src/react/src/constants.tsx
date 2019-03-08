export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
   static readonly HostedSubDirectory = process.env.REACT_APP_HOST_SUBDIRECTORY;
}

export class ClientRoutes {
static readonly Buckets = '/buckets';		
static readonly Files = '/files';		
static readonly FileTypes = '/filetypes';		
}

export class ApiRoutes {
static readonly Buckets = 'buckets';		
static readonly Files = 'files';		
static readonly FileTypes = 'filetypes';		
}

/*<Codenesium>
    <Hash>4ec588b4ab498b8e020236659759ed77</Hash>
</Codenesium>*/