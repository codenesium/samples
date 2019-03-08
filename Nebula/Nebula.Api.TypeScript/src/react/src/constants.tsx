export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedSubDirectory = process.env.REACT_APP_HOST_SUBDIRECTORY;
}

export class ClientRoutes {
  static readonly Chains = '/chains';
  static readonly ChainStatuses = '/chainstatuses';
  static readonly Clasps = '/clasps';
  static readonly Links = '/links';
  static readonly LinkLogs = '/linklogs';
  static readonly LinkStatuses = '/linkstatuses';
  static readonly Machines = '/machines';
  static readonly Organizations = '/organizations';
  static readonly Teams = '/teams';
}

export class ApiRoutes {
  static readonly Chains = 'chains';
  static readonly ChainStatuses = 'chainstatuses';
  static readonly Clasps = 'clasps';
  static readonly Links = 'links';
  static readonly LinkLogs = 'linklogs';
  static readonly LinkStatuses = 'linkstatuses';
  static readonly Machines = 'machines';
  static readonly Organizations = 'organizations';
  static readonly Teams = 'teams';
}


/*<Codenesium>
    <Hash>6bfecc9a2defac8c81dd3e488c219bda</Hash>
</Codenesium>*/