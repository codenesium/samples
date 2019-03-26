export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedBaseUrl = location.protocol + '//' + location.host;
  static readonly HostedSubDirectory =
    process.env.REACT_APP_HOST_SUBDIRECTORY == '/'
      ? ''
      : '/' + process.env.REACT_APP_HOST_SUBDIRECTORY;
  static readonly HostedUrl =
    Constants.HostedBaseUrl + Constants.HostedSubDirectory;
}

export class AuthClientRoutes {
  static readonly Login = '/login';
  static readonly Logout = '/logout';
  static readonly Register = '/register';
  static readonly ResetPassword = '/resetpassword';
  static readonly ConfirmRegistration = '/confirmregistration';
  static readonly ConfirmPasswordReset = '/confirmpasswordreset';
  static readonly ChangePassword = '/changepassword';
}

export class AuthApiRoutes {
  static readonly Login = 'auth/login';
  static readonly Register = 'auth/register';
  static readonly ResetPassword = 'auth/resetpassword';
  static readonly ConfirmRegistration = 'auth/confirmregistration';
  static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';
  static readonly ChangePassword = 'auth/changepassword';
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
    <Hash>37ed35123dc78a19ce4c277948cbdc5e</Hash>
</Codenesium>*/