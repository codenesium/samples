export class Constants {
   static readonly BaseEndpoint = "http://localhost:8000/";
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
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
    <Hash>e6d9d324f18e780971ceb50b2a9c9045</Hash>
</Codenesium>*/