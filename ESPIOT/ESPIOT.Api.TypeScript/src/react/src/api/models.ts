export class DeviceClientRequestModel {
				dateOfLastPing:any;
id:number;
isActive:boolean;
name:string;
publicId:any;

	
				constructor() {
					this.dateOfLastPing = undefined;
this.id = 0;
this.isActive = false;
this.name = '';
this.publicId = undefined;

				}

				setProperties(dateOfLastPing : any,id : number,isActive : boolean,name : string,publicId : any) : void
				{
					this.dateOfLastPing = dateOfLastPing;
this.id = id;
this.isActive = isActive;
this.name = name;
this.publicId = publicId;

				}
			}

			export class DeviceClientResponseModel {
				dateOfLastPing:any;
id:number;
isActive:boolean;
name:string;
publicId:any;

	
				constructor() {
					this.dateOfLastPing = undefined;
this.id = 0;
this.isActive = false;
this.name = '';
this.publicId = undefined;

				}

				setProperties(dateOfLastPing : any,id : number,isActive : boolean,name : string,publicId : any) : void
				{
					this.dateOfLastPing = dateOfLastPing;
this.id = id;
this.isActive = isActive;
this.name = name;
this.publicId = publicId;

				}
			}
			export class DeviceActionClientRequestModel {
				action:string;
deviceId:number;
deviceIdEntity : string;
deviceIdNavigation? : DeviceClientResponseModel;
id:number;
name:string;

	
				constructor() {
					this.action = '';
this.deviceId = 0;
this.deviceIdEntity = '';
this.deviceIdNavigation = undefined;
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
			}

			export class DeviceActionClientResponseModel {
				action:string;
deviceId:number;
deviceIdEntity : string;
deviceIdNavigation? : DeviceClientResponseModel;
id:number;
name:string;

	
				constructor() {
					this.action = '';
this.deviceId = 0;
this.deviceIdEntity = '';
this.deviceIdNavigation = undefined;
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
			}

/*<Codenesium>
    <Hash>995a2278fe95dc34a923f29779b6404d</Hash>
</Codenesium>*/