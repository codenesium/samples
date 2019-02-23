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
    <Hash>be09408eb109eb10be944556ab8035c5</Hash>
</Codenesium>*/