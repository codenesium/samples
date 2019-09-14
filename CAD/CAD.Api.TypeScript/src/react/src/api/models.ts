export class AddressClientRequestModel {
  address1: string;
  address2: string;
  city: string;
  id: number;
  state: string;
  zip: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.city = '';
    this.id = 0;
    this.state = '';
    this.zip = '';
  }

  setProperties(
    address1: string,
    address2: string,
    city: string,
    id: number,
    state: string,
    zip: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.city = city;
    this.id = id;
    this.state = state;
    this.zip = zip;
  }
}

export class AddressClientResponseModel {
  address1: string;
  address2: string;
  city: string;
  id: number;
  state: string;
  zip: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.city = '';
    this.id = 0;
    this.state = '';
    this.zip = '';
  }

  setProperties(
    address1: string,
    address2: string,
    city: string,
    id: number,
    state: string,
    zip: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.city = city;
    this.id = id;
    this.state = state;
    this.zip = zip;
  }
}
export class CallClientRequestModel {
  addressId: number;
  addressIdEntity: string;
  addressIdNavigation?: AddressClientResponseModel;
  callDispositionId: number;
  callDispositionIdEntity: string;
  callDispositionIdNavigation?: CallDispositionClientResponseModel;
  callStatusId: number;
  callStatusIdEntity: string;
  callStatusIdNavigation?: CallStatusClientResponseModel;
  callString: string;
  callTypeId: number;
  callTypeIdEntity: string;
  callTypeIdNavigation?: CallTypeClientResponseModel;
  dateCleared: any;
  dateCreated: any;
  dateDispatched: any;
  id: number;
  quickCallNumber: number;

  constructor() {
    this.addressId = 0;
    this.addressIdEntity = '';
    this.addressIdNavigation = undefined;
    this.callDispositionId = 0;
    this.callDispositionIdEntity = '';
    this.callDispositionIdNavigation = undefined;
    this.callStatusId = 0;
    this.callStatusIdEntity = '';
    this.callStatusIdNavigation = undefined;
    this.callString = '';
    this.callTypeId = 0;
    this.callTypeIdEntity = '';
    this.callTypeIdNavigation = undefined;
    this.dateCleared = undefined;
    this.dateCreated = undefined;
    this.dateDispatched = undefined;
    this.id = 0;
    this.quickCallNumber = 0;
  }

  setProperties(
    addressId: number,
    callDispositionId: number,
    callStatusId: number,
    callString: string,
    callTypeId: number,
    dateCleared: any,
    dateCreated: any,
    dateDispatched: any,
    id: number,
    quickCallNumber: number
  ): void {
    this.addressId = addressId;
    this.callDispositionId = callDispositionId;
    this.callStatusId = callStatusId;
    this.callString = callString;
    this.callTypeId = callTypeId;
    this.dateCleared = dateCleared;
    this.dateCreated = dateCreated;
    this.dateDispatched = dateDispatched;
    this.id = id;
    this.quickCallNumber = quickCallNumber;
  }
}

export class CallClientResponseModel {
  addressId: number;
  addressIdEntity: string;
  addressIdNavigation?: AddressClientResponseModel;
  callDispositionId: number;
  callDispositionIdEntity: string;
  callDispositionIdNavigation?: CallDispositionClientResponseModel;
  callStatusId: number;
  callStatusIdEntity: string;
  callStatusIdNavigation?: CallStatusClientResponseModel;
  callString: string;
  callTypeId: number;
  callTypeIdEntity: string;
  callTypeIdNavigation?: CallTypeClientResponseModel;
  dateCleared: any;
  dateCreated: any;
  dateDispatched: any;
  id: number;
  quickCallNumber: number;

  constructor() {
    this.addressId = 0;
    this.addressIdEntity = '';
    this.addressIdNavigation = undefined;
    this.callDispositionId = 0;
    this.callDispositionIdEntity = '';
    this.callDispositionIdNavigation = undefined;
    this.callStatusId = 0;
    this.callStatusIdEntity = '';
    this.callStatusIdNavigation = undefined;
    this.callString = '';
    this.callTypeId = 0;
    this.callTypeIdEntity = '';
    this.callTypeIdNavigation = undefined;
    this.dateCleared = undefined;
    this.dateCreated = undefined;
    this.dateDispatched = undefined;
    this.id = 0;
    this.quickCallNumber = 0;
  }

  setProperties(
    addressId: number,
    callDispositionId: number,
    callStatusId: number,
    callString: string,
    callTypeId: number,
    dateCleared: any,
    dateCreated: any,
    dateDispatched: any,
    id: number,
    quickCallNumber: number
  ): void {
    this.addressId = addressId;
    this.callDispositionId = callDispositionId;
    this.callStatusId = callStatusId;
    this.callString = callString;
    this.callTypeId = callTypeId;
    this.dateCleared = dateCleared;
    this.dateCreated = dateCreated;
    this.dateDispatched = dateDispatched;
    this.id = id;
    this.quickCallNumber = quickCallNumber;
  }
}
export class CallAssignmentClientRequestModel {
  callId: number;
  callIdEntity: string;
  callIdNavigation?: CallClientResponseModel;
  id: number;
  unitId: number;
  unitIdEntity: string;
  unitIdNavigation?: UnitClientResponseModel;

  constructor() {
    this.callId = 0;
    this.callIdEntity = '';
    this.callIdNavigation = undefined;
    this.id = 0;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = undefined;
  }

  setProperties(callId: number, id: number, unitId: number): void {
    this.callId = callId;
    this.id = id;
    this.unitId = unitId;
  }
}

export class CallAssignmentClientResponseModel {
  callId: number;
  callIdEntity: string;
  callIdNavigation?: CallClientResponseModel;
  id: number;
  unitId: number;
  unitIdEntity: string;
  unitIdNavigation?: UnitClientResponseModel;

  constructor() {
    this.callId = 0;
    this.callIdEntity = '';
    this.callIdNavigation = undefined;
    this.id = 0;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = undefined;
  }

  setProperties(callId: number, id: number, unitId: number): void {
    this.callId = callId;
    this.id = id;
    this.unitId = unitId;
  }
}
export class CallDispositionClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class CallDispositionClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class CallPersonClientRequestModel {
  id: number;
  note: string;
  personId: number;
  personIdEntity: string;
  personIdNavigation?: PersonClientResponseModel;
  personTypeId: number;
  personTypeIdEntity: string;
  personTypeIdNavigation?: PersonTypeClientResponseModel;

  constructor() {
    this.id = 0;
    this.note = '';
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = undefined;
    this.personTypeId = 0;
    this.personTypeIdEntity = '';
    this.personTypeIdNavigation = undefined;
  }

  setProperties(
    id: number,
    note: string,
    personId: number,
    personTypeId: number
  ): void {
    this.id = id;
    this.note = note;
    this.personId = personId;
    this.personTypeId = personTypeId;
  }
}

export class CallPersonClientResponseModel {
  id: number;
  note: string;
  personId: number;
  personIdEntity: string;
  personIdNavigation?: PersonClientResponseModel;
  personTypeId: number;
  personTypeIdEntity: string;
  personTypeIdNavigation?: PersonTypeClientResponseModel;

  constructor() {
    this.id = 0;
    this.note = '';
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = undefined;
    this.personTypeId = 0;
    this.personTypeIdEntity = '';
    this.personTypeIdNavigation = undefined;
  }

  setProperties(
    id: number,
    note: string,
    personId: number,
    personTypeId: number
  ): void {
    this.id = id;
    this.note = note;
    this.personId = personId;
    this.personTypeId = personTypeId;
  }
}
export class CallStatusClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class CallStatusClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class CallTypeClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class CallTypeClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class NoteClientRequestModel {
  callId: number;
  callIdEntity: string;
  callIdNavigation?: CallClientResponseModel;
  dateCreated: any;
  id: number;
  noteText: string;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;

  constructor() {
    this.callId = 0;
    this.callIdEntity = '';
    this.callIdNavigation = undefined;
    this.dateCreated = undefined;
    this.id = 0;
    this.noteText = '';
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
  }

  setProperties(
    callId: number,
    dateCreated: any,
    id: number,
    noteText: string,
    officerId: number
  ): void {
    this.callId = callId;
    this.dateCreated = dateCreated;
    this.id = id;
    this.noteText = noteText;
    this.officerId = officerId;
  }
}

export class NoteClientResponseModel {
  callId: number;
  callIdEntity: string;
  callIdNavigation?: CallClientResponseModel;
  dateCreated: any;
  id: number;
  noteText: string;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;

  constructor() {
    this.callId = 0;
    this.callIdEntity = '';
    this.callIdNavigation = undefined;
    this.dateCreated = undefined;
    this.id = 0;
    this.noteText = '';
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
  }

  setProperties(
    callId: number,
    dateCreated: any,
    id: number,
    noteText: string,
    officerId: number
  ): void {
    this.callId = callId;
    this.dateCreated = dateCreated;
    this.id = id;
    this.noteText = noteText;
    this.officerId = officerId;
  }
}
export class OffCapabilityClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class OffCapabilityClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class OfficerClientRequestModel {
  badge: string;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  password: string;

  constructor() {
    this.badge = '';
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.password = '';
  }

  setProperties(
    badge: string,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    password: string
  ): void {
    this.badge = badge;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.password = password;
  }
}

export class OfficerClientResponseModel {
  badge: string;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  password: string;

  constructor() {
    this.badge = '';
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.password = '';
  }

  setProperties(
    badge: string,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    password: string
  ): void {
    this.badge = badge;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.password = password;
  }
}
export class OfficerCapabilitiesClientRequestModel {
  capabilityId: number;
  capabilityIdEntity: string;
  capabilityIdNavigation?: OffCapabilityClientResponseModel;
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;

  constructor() {
    this.capabilityId = 0;
    this.capabilityIdEntity = '';
    this.capabilityIdNavigation = undefined;
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
  }

  setProperties(capabilityId: number, id: number, officerId: number): void {
    this.capabilityId = capabilityId;
    this.id = id;
    this.officerId = officerId;
  }
}

export class OfficerCapabilitiesClientResponseModel {
  capabilityId: number;
  capabilityIdEntity: string;
  capabilityIdNavigation?: OffCapabilityClientResponseModel;
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;

  constructor() {
    this.capabilityId = 0;
    this.capabilityIdEntity = '';
    this.capabilityIdNavigation = undefined;
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
  }

  setProperties(capabilityId: number, id: number, officerId: number): void {
    this.capabilityId = capabilityId;
    this.id = id;
    this.officerId = officerId;
  }
}
export class PersonClientRequestModel {
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  ssn: string;

  constructor() {
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.ssn = '';
  }

  setProperties(
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    ssn: string
  ): void {
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.ssn = ssn;
  }
}

export class PersonClientResponseModel {
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  ssn: string;

  constructor() {
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.ssn = '';
  }

  setProperties(
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    ssn: string
  ): void {
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.ssn = ssn;
  }
}
export class PersonTypeClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class PersonTypeClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class UnitClientRequestModel {
  callSign: string;
  id: number;

  constructor() {
    this.callSign = '';
    this.id = 0;
  }

  setProperties(callSign: string, id: number): void {
    this.callSign = callSign;
    this.id = id;
  }
}

export class UnitClientResponseModel {
  callSign: string;
  id: number;

  constructor() {
    this.callSign = '';
    this.id = 0;
  }

  setProperties(callSign: string, id: number): void {
    this.callSign = callSign;
    this.id = id;
  }
}
export class UnitDispositionClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class UnitDispositionClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class UnitOfficerClientRequestModel {
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;
  unitId: number;
  unitIdEntity: string;
  unitIdNavigation?: UnitClientResponseModel;

  constructor() {
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = undefined;
  }

  setProperties(id: number, officerId: number, unitId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.unitId = unitId;
  }
}

export class UnitOfficerClientResponseModel {
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;
  unitId: number;
  unitIdEntity: string;
  unitIdNavigation?: UnitClientResponseModel;

  constructor() {
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = undefined;
  }

  setProperties(id: number, officerId: number, unitId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.unitId = unitId;
  }
}
export class VehCapabilityClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class VehCapabilityClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class VehicleClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class VehicleClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class VehicleCapabilitiesClientRequestModel {
  id: number;
  vehicleCapabilityId: number;
  vehicleCapabilityIdEntity: string;
  vehicleCapabilityIdNavigation?: VehCapabilityClientResponseModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleClientResponseModel;

  constructor() {
    this.id = 0;
    this.vehicleCapabilityId = 0;
    this.vehicleCapabilityIdEntity = '';
    this.vehicleCapabilityIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(
    id: number,
    vehicleCapabilityId: number,
    vehicleId: number
  ): void {
    this.id = id;
    this.vehicleCapabilityId = vehicleCapabilityId;
    this.vehicleId = vehicleId;
  }
}

export class VehicleCapabilitiesClientResponseModel {
  id: number;
  vehicleCapabilityId: number;
  vehicleCapabilityIdEntity: string;
  vehicleCapabilityIdNavigation?: VehCapabilityClientResponseModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleClientResponseModel;

  constructor() {
    this.id = 0;
    this.vehicleCapabilityId = 0;
    this.vehicleCapabilityIdEntity = '';
    this.vehicleCapabilityIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(
    id: number,
    vehicleCapabilityId: number,
    vehicleId: number
  ): void {
    this.id = id;
    this.vehicleCapabilityId = vehicleCapabilityId;
    this.vehicleId = vehicleId;
  }
}
export class VehicleOfficerClientRequestModel {
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleClientResponseModel;

  constructor() {
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(id: number, officerId: number, vehicleId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.vehicleId = vehicleId;
  }
}

export class VehicleOfficerClientResponseModel {
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerClientResponseModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleClientResponseModel;

  constructor() {
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(id: number, officerId: number, vehicleId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.vehicleId = vehicleId;
  }
}


/*<Codenesium>
    <Hash>ce384a1b0f5665a84042c2ecb76020cb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/