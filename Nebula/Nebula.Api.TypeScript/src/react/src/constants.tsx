export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
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
    <Hash>abe5c4b0b3bd68fc701169088db49d06</Hash>
</Codenesium>*/