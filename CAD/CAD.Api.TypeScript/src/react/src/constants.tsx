export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
  static readonly Addresses = '/addresses';
  static readonly Calls = '/calls';
  static readonly CallAssignments = '/callassignments';
  static readonly CallDispositions = '/calldispositions';
  static readonly CallPersons = '/callpersons';
  static readonly CallStatus = '/callstatus';
  static readonly CallTypes = '/calltypes';
  static readonly Notes = '/notes';
  static readonly Officers = '/officers';
  static readonly OfficerCapabilities = '/officercapabilities';
  static readonly OfficerRefCapabilities = '/officerrefcapabilities';
  static readonly People = '/people';
  static readonly PersonTypes = '/persontypes';
  static readonly Units = '/units';
  static readonly UnitDispositions = '/unitdispositions';
  static readonly UnitOfficers = '/unitofficers';
  static readonly Vehicles = '/vehicles';
  static readonly VehicleCapabilities = '/vehiclecapabilities';
  static readonly VehicleOfficers = '/vehicleofficers';
  static readonly VehicleRefCapabilities = '/vehiclerefcapabilities';
}

export class ApiRoutes {
  static readonly Addresses = 'addresses';
  static readonly Calls = 'calls';
  static readonly CallAssignments = 'callassignments';
  static readonly CallDispositions = 'calldispositions';
  static readonly CallPersons = 'callpersons';
  static readonly CallStatus = 'callstatus';
  static readonly CallTypes = 'calltypes';
  static readonly Notes = 'notes';
  static readonly Officers = 'officers';
  static readonly OfficerCapabilities = 'officercapabilities';
  static readonly OfficerRefCapabilities = 'officerrefcapabilities';
  static readonly People = 'people';
  static readonly PersonTypes = 'persontypes';
  static readonly Units = 'units';
  static readonly UnitDispositions = 'unitdispositions';
  static readonly UnitOfficers = 'unitofficers';
  static readonly Vehicles = 'vehicles';
  static readonly VehicleCapabilities = 'vehiclecapabilities';
  static readonly VehicleOfficers = 'vehicleofficers';
  static readonly VehicleRefCapabilities = 'vehiclerefcapabilities';
}


/*<Codenesium>
    <Hash>e1f8dae977242a30f2d22106ab0e2244</Hash>
</Codenesium>*/