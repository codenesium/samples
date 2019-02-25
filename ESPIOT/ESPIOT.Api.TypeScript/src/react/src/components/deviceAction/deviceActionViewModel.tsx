import moment from 'moment'
import DeviceViewModel from '../device/deviceViewModel'
	

export default class DeviceActionViewModel {
    action:string;
deviceId:number;
deviceIdEntity : string;
deviceIdNavigation? : DeviceViewModel;
id:number;
name:string;

    constructor() {
		this.action = '';
this.deviceId = 0;
this.deviceIdEntity = '';
this.deviceIdNavigation = new DeviceViewModel();
this.id = 0;
this.name = '';

    }

	setProperties(action : string,deviceId : number,id : number,name : string) : void
	{
		this.action = action;
this.deviceId = deviceId;
this.id = id;
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.action);
	}
};

/*<Codenesium>
    <Hash>340d58195c4d8be0f22b7a9049532740</Hash>
</Codenesium>*/