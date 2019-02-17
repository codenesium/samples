export class Constants {
  static readonly BaseEndpoint = 'https://codenesium.ngrok.io/user7303b0f5161f4149bf2959a488d359feTests/';
  // static readonly BaseEndpoint = 'https://codenesium.ngrok.io/user7303b0f5161f4149bf2959a488d359feTests/';
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
    <Hash>36c94ec4e602a081aa43c71496c087e3</Hash>
</Codenesium>*/