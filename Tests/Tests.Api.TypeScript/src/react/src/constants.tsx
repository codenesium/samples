export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
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
    <Hash>2f83c6636b8d688af2438b0e8195ec80</Hash>
</Codenesium>*/