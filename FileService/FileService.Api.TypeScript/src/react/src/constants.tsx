export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
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
    <Hash>d8288a1afe50715b0f92e2189f9afd7b</Hash>
</Codenesium>*/