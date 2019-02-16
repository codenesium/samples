export class Constants {
  static readonly BaseEndpoint = 'http://localhost:8000/';
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
  static readonly ColumnSameAsFKTables = '/columnsameasfktables';
  static readonly IncludedColumnTests = '/includedcolumntests';
  static readonly People = '/people';
  static readonly RowVersionChecks = '/rowversionchecks';
  static readonly SelfReferences = '/selfreferences';
  static readonly Tables = '/tables';
  static readonly TestAllFieldTypes = '/testallfieldtypes';
  static readonly TestAllFieldTypesNullables = '/testallfieldtypesnullables';
  static readonly TimestampChecks = '/timestampchecks';
  static readonly VPersons = '/vpersons';
}

export class ApiRoutes {
  static readonly ColumnSameAsFKTables = 'columnsameasfktables';
  static readonly IncludedColumnTests = 'includedcolumntests';
  static readonly People = 'people';
  static readonly RowVersionChecks = 'rowversionchecks';
  static readonly SelfReferences = 'selfreferences';
  static readonly Tables = 'tables';
  static readonly TestAllFieldTypes = 'testallfieldtypes';
  static readonly TestAllFieldTypesNullables = 'testallfieldtypesnullables';
  static readonly TimestampChecks = 'timestampchecks';
  static readonly VPersons = 'vpersons';
}


/*<Codenesium>
    <Hash>0ab86681ce6d5fcf37c9ab04fde7e76b</Hash>
</Codenesium>*/