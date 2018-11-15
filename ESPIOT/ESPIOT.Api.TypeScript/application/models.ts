export class ApiDeviceServerRequestModel {
				id:number;
name:string;
publicId:string;

	
				constructor() {
					this.id = 0;
this.name = '';
this.publicId = '';

		
				}
			}

			export class ApiDeviceServerResponseModel {
				id:number;
name:string;
publicId:string;

	
				constructor() {
					this.id = 0;
this.name = '';
this.publicId = '';

		
				}
			}
			export class ApiDeviceActionServerRequestModel {
				deviceId:number;
deviceIdEntity:number;
id:number;
name:string;
value:string;

	
				constructor() {
					this.deviceId = 0;
this.id = 0;
this.name = '';
this.value = '';

		
				}
			}

			export class ApiDeviceActionServerResponseModel {
				deviceId:number;
deviceIdEntity:number;
id:number;
name:string;
value:string;

	
				constructor() {
					this.deviceId = 0;
this.id = 0;
this.name = '';
this.value = '';

		
				}
			}