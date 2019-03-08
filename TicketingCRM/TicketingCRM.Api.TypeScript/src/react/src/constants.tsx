export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
   static readonly HostedSubDirectory = process.env.REACT_APP_HOST_SUBDIRECTORY;
}

export class ClientRoutes {
static readonly Admins = '/admins';		
static readonly Cities = '/cities';		
static readonly Countries = '/countries';		
static readonly Customers = '/customers';		
static readonly Events = '/events';		
static readonly Provinces = '/provinces';		
static readonly Sales = '/sales';		
static readonly SaleTickets = '/saletickets';		
static readonly Tickets = '/tickets';		
static readonly TicketStatus = '/ticketstatus';		
static readonly Transactions = '/transactions';		
static readonly TransactionStatus = '/transactionstatus';		
static readonly Venues = '/venues';		
}

export class ApiRoutes {
static readonly Admins = 'admins';		
static readonly Cities = 'cities';		
static readonly Countries = 'countries';		
static readonly Customers = 'customers';		
static readonly Events = 'events';		
static readonly Provinces = 'provinces';		
static readonly Sales = 'sales';		
static readonly SaleTickets = 'saletickets';		
static readonly Tickets = 'tickets';		
static readonly TicketStatus = 'ticketstatus';		
static readonly Transactions = 'transactions';		
static readonly TransactionStatus = 'transactionstatus';		
static readonly Venues = 'venues';		
}

/*<Codenesium>
    <Hash>740c48b854faae6821dde8cdb2a77d38</Hash>
</Codenesium>*/