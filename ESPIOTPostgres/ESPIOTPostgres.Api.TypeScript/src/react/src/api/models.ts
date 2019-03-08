export class DeviceClientRequestModel {
  id: number;
  name: string;
  publicId: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.publicId = undefined;
  }

  setProperties(id: number, name: string, publicId: any): void {
    this.id = id;
    this.name = name;
    this.publicId = publicId;
  }
}

export class DeviceClientResponseModel {
  id: number;
  name: string;
  publicId: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.publicId = undefined;
  }

  setProperties(id: number, name: string, publicId: any): void {
    this.id = id;
    this.name = name;
    this.publicId = publicId;
  }
}
export class DeviceActionClientRequestModel {
  action: string;
  deviceId: number;
  deviceIdEntity: string;
  deviceIdNavigation?: DeviceClientResponseModel;
  id: number;
  name: string;

  constructor() {
    this.action = '';
    this.deviceId = 0;
    this.deviceIdEntity = '';
    this.deviceIdNavigation = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(
    action: string,
    deviceId: number,
    id: number,
    name: string
  ): void {
    this.action = action;
    this.deviceId = deviceId;
    this.id = id;
    this.name = name;
  }
}

export class DeviceActionClientResponseModel {
  action: string;
  deviceId: number;
  deviceIdEntity: string;
  deviceIdNavigation?: DeviceClientResponseModel;
  id: number;
  name: string;

  constructor() {
    this.action = '';
    this.deviceId = 0;
    this.deviceIdEntity = '';
    this.deviceIdNavigation = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(
    action: string,
    deviceId: number,
    id: number,
    name: string
  ): void {
    this.action = action;
    this.deviceId = deviceId;
    this.id = id;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>2db20401766158d36802842acd9da262</Hash>
</Codenesium>*/