export class Constants {
  static readonly BaseEndpoint = 'http://localhost:8000/';
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
  static readonly Badges = '/badges';
  static readonly Comments = '/comments';
  static readonly LinkTypes = '/linktypes';
  static readonly PostHistories = '/posthistories';
  static readonly PostHistoryTypes = '/posthistorytypes';
  static readonly PostLinks = '/postlinks';
  static readonly Posts = '/posts';
  static readonly PostTypes = '/posttypes';
  static readonly Tags = '/tags';
  static readonly Users = '/users';
  static readonly Votes = '/votes';
  static readonly VoteTypes = '/votetypes';
}

export class ApiRoutes {
  static readonly Badges = 'badges';
  static readonly Comments = 'comments';
  static readonly LinkTypes = 'linktypes';
  static readonly PostHistories = 'posthistories';
  static readonly PostHistoryTypes = 'posthistorytypes';
  static readonly PostLinks = 'postlinks';
  static readonly Posts = 'posts';
  static readonly PostTypes = 'posttypes';
  static readonly Tags = 'tags';
  static readonly Users = 'users';
  static readonly Votes = 'votes';
  static readonly VoteTypes = 'votetypes';
}


/*<Codenesium>
    <Hash>a9b2e91665d893dbd4fefe45d9d34c1e</Hash>
</Codenesium>*/