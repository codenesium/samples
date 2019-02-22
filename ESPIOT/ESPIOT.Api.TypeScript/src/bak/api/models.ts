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
  deviceId: number;
  deviceIdEntity: string;
  deviceIdNavigation?: DeviceClientResponseModel;
  id: number;
  name: string;
  rwValue: string;

  constructor() {
    this.deviceId = 0;
    this.deviceIdEntity = '';
    this.deviceIdNavigation = undefined;
    this.id = 0;
    this.name = '';
    this.rwValue = '';
  }

  setProperties(
    deviceId: number,
    id: number,
    name: string,
    rwValue: string
  ): void {
    this.deviceId = deviceId;
    this.id = id;
    this.name = name;
    this.rwValue = rwValue;
  }
}

export class DeviceActionClientResponseModel {
  deviceId: number;
  deviceIdEntity: string;
  deviceIdNavigation?: DeviceClientResponseModel;
  id: number;
  name: string;
  rwValue: string;

  constructor() {
    this.deviceId = 0;
    this.deviceIdEntity = '';
    this.deviceIdNavigation = undefined;
    this.id = 0;
    this.name = '';
    this.rwValue = '';
  }

  setProperties(
    deviceId: number,
    id: number,
    name: string,
    rwValue: string
  ): void {
    this.deviceId = deviceId;
    this.id = id;
    this.name = name;
    this.rwValue = rwValue;
  }
}


/*<Codenesium>
    <Hash>3ae490bbb07942afad6a6cd13996e783</Hash>
</Codenesium>*/