export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
static readonly Breeds = '/breeds';		
static readonly PaymentTypes = '/paymenttypes';		
static readonly Pens = '/pens';		
static readonly Pets = '/pets';		
static readonly Sales = '/sales';		
static readonly Species = '/species';		
}

export class ApiRoutes {
static readonly Breeds = 'breeds';		
static readonly PaymentTypes = 'paymenttypes';		
static readonly Pens = 'pens';		
static readonly Pets = 'pets';		
static readonly Sales = 'sales';		
static readonly Species = 'species';		
}

/*<Codenesium>
    <Hash>72f9a288b648acea6131d8852c599594</Hash>
</Codenesium>*/