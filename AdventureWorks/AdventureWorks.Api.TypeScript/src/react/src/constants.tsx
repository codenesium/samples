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
  static readonly AWBuildVersions = '/awbuildversions';
  static readonly DatabaseLogs = '/databaselogs';
  static readonly ErrorLogs = '/errorlogs';
  static readonly Departments = '/departments';
  static readonly Employees = '/employees';
  static readonly JobCandidates = '/jobcandidates';
  static readonly Shifts = '/shifts';
  static readonly Addresses = '/addresses';
  static readonly AddressTypes = '/addresstypes';
  static readonly BusinessEntities = '/businessentities';
  static readonly ContactTypes = '/contacttypes';
  static readonly CountryRegions = '/countryregions';
  static readonly Passwords = '/passwords';
  static readonly People = '/people';
  static readonly PhoneNumberTypes = '/phonenumbertypes';
  static readonly StateProvinces = '/stateprovinces';
  static readonly BillOfMaterials = '/billofmaterials';
  static readonly Cultures = '/cultures';
  static readonly Documents = '/documents';
  static readonly Illustrations = '/illustrations';
  static readonly Locations = '/locations';
  static readonly Products = '/products';
  static readonly ProductCategories = '/productcategories';
  static readonly ProductDescriptions = '/productdescriptions';
  static readonly ProductModels = '/productmodels';
  static readonly ProductPhotoes = '/productphotoes';
  static readonly ProductProductPhotoes = '/productproductphotoes';
  static readonly ProductReviews = '/productreviews';
  static readonly ProductSubcategories = '/productsubcategories';
  static readonly ScrapReasons = '/scrapreasons';
  static readonly TransactionHistories = '/transactionhistories';
  static readonly TransactionHistoryArchives = '/transactionhistoryarchives';
  static readonly UnitMeasures = '/unitmeasures';
  static readonly WorkOrders = '/workorders';
  static readonly PurchaseOrderHeaders = '/purchaseorderheaders';
  static readonly ShipMethods = '/shipmethods';
  static readonly Vendors = '/vendors';
  static readonly CreditCards = '/creditcards';
  static readonly Currencies = '/currencies';
  static readonly CurrencyRates = '/currencyrates';
  static readonly Customers = '/customers';
  static readonly SalesOrderHeaders = '/salesorderheaders';
  static readonly SalesPersons = '/salespersons';
  static readonly SalesReasons = '/salesreasons';
  static readonly SalesTaxRates = '/salestaxrates';
  static readonly SalesTerritories = '/salesterritories';
  static readonly ShoppingCartItems = '/shoppingcartitems';
  static readonly SpecialOffers = '/specialoffers';
  static readonly Stores = '/stores';
}

export class ApiRoutes {
  static readonly AWBuildVersions = 'awbuildversions';
  static readonly DatabaseLogs = 'databaselogs';
  static readonly ErrorLogs = 'errorlogs';
  static readonly Departments = 'departments';
  static readonly Employees = 'employees';
  static readonly JobCandidates = 'jobcandidates';
  static readonly Shifts = 'shifts';
  static readonly Addresses = 'addresses';
  static readonly AddressTypes = 'addresstypes';
  static readonly BusinessEntities = 'businessentities';
  static readonly ContactTypes = 'contacttypes';
  static readonly CountryRegions = 'countryregions';
  static readonly Passwords = 'passwords';
  static readonly People = 'people';
  static readonly PhoneNumberTypes = 'phonenumbertypes';
  static readonly StateProvinces = 'stateprovinces';
  static readonly BillOfMaterials = 'billofmaterials';
  static readonly Cultures = 'cultures';
  static readonly Documents = 'documents';
  static readonly Illustrations = 'illustrations';
  static readonly Locations = 'locations';
  static readonly Products = 'products';
  static readonly ProductCategories = 'productcategories';
  static readonly ProductDescriptions = 'productdescriptions';
  static readonly ProductModels = 'productmodels';
  static readonly ProductPhotoes = 'productphotoes';
  static readonly ProductProductPhotoes = 'productproductphotoes';
  static readonly ProductReviews = 'productreviews';
  static readonly ProductSubcategories = 'productsubcategories';
  static readonly ScrapReasons = 'scrapreasons';
  static readonly TransactionHistories = 'transactionhistories';
  static readonly TransactionHistoryArchives = 'transactionhistoryarchives';
  static readonly UnitMeasures = 'unitmeasures';
  static readonly WorkOrders = 'workorders';
  static readonly PurchaseOrderHeaders = 'purchaseorderheaders';
  static readonly ShipMethods = 'shipmethods';
  static readonly Vendors = 'vendors';
  static readonly CreditCards = 'creditcards';
  static readonly Currencies = 'currencies';
  static readonly CurrencyRates = 'currencyrates';
  static readonly Customers = 'customers';
  static readonly SalesOrderHeaders = 'salesorderheaders';
  static readonly SalesPersons = 'salespersons';
  static readonly SalesReasons = 'salesreasons';
  static readonly SalesTaxRates = 'salestaxrates';
  static readonly SalesTerritories = 'salesterritories';
  static readonly ShoppingCartItems = 'shoppingcartitems';
  static readonly SpecialOffers = 'specialoffers';
  static readonly Stores = 'stores';
}


/*<Codenesium>
    <Hash>ca594e636de2a702126784a39959bea0</Hash>
</Codenesium>*/