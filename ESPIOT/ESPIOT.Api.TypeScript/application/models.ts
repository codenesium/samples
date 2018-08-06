export class ApiDeviceRequestModel {
				id:number;
name:string;
publicId:string;

	
				constructor() {
					this.id = 0;
this.name = '';
this.publicId = '';

		
				}
			}

			export class ApiDeviceResponseModel {
				id:number;
name:string;
publicId:string;

	
				constructor() {
					this.id = 0;
this.name = '';
this.publicId = '';

		
				}
			}
			export class ApiDeviceActionRequestModel {
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

			export class ApiDeviceActionResponseModel {
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