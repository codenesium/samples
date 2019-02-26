export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
  static readonly Videos = '/videos';
  static readonly Users = '/users';
  static readonly Subscriptions = '/subscriptions';
}

export class ApiRoutes {
  static readonly Videos = 'videos';
  static readonly Users = 'users';
  static readonly Subscriptions = 'subscriptions';
}


/*<Codenesium>
    <Hash>2352066ed287250da11dcba20daaf348</Hash>
</Codenesium>*/