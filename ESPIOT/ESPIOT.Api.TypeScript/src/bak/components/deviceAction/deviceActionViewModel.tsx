import moment from 'moment';
import DeviceViewModel from '../device/deviceViewModel';

export default class DeviceActionViewModel {
  deviceId: number;
  deviceIdEntity: string;
  deviceIdNavigation?: DeviceViewModel;
  id: number;
  name: string;
  rwValue: string;

  constructor() {
    this.deviceId = 0;
    this.deviceIdEntity = '';
    this.deviceIdNavigation = new DeviceViewModel();
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

  toDisplay(): string {
    return String(this.deviceId);
  }
}


/*<Codenesium>
    <Hash>59dcbcad6b8250bd98f01304e501bb7b</Hash>
</Codenesium>*/