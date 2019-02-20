export class Constants {
  static readonly BaseEndpoint = 'https://codenesium.ngrok.io/user7303b0f5161f4149bf2959a488d359feFileService/';
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
    <Hash>edeb867c8a408af6cdc6445d0d503d9a</Hash>
</Codenesium>*/