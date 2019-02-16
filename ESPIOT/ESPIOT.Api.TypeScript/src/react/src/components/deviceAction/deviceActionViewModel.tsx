import DeviceViewModel from '../device/deviceViewModel';

export default class DeviceActionViewModel {
  action: string;
  deviceId: number;
  deviceIdEntity: string;
  deviceIdNavigation?: DeviceViewModel;
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

  toDisplay(): string {
    return String(this.action);
  }
}


/*<Codenesium>
    <Hash>387cbc15aeb36fb07a3ca66d85d8f11b</Hash>
</Codenesium>*/