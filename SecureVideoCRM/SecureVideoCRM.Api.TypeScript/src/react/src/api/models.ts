export class VideoClientRequestModel {
				description:string;
id:number;
title:string;
url:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.title = '';
this.url = '';

				}

				setProperties(description : string,id : number,title : string,url : string) : void
				{
					this.description = description;
this.id = id;
this.title = title;
this.url = url;

				}
			}

			export class VideoClientResponseModel {
				description:string;
id:number;
title:string;
url:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.title = '';
this.url = '';

				}

				setProperties(description : string,id : number,title : string,url : string) : void
				{
					this.description = description;
this.id = id;
this.title = title;
this.url = url;

				}
			}
			export class UserClientRequestModel {
				email:string;
id:number;
password:string;
subscriptionId:number;
subscriptionIdEntity : string;
subscriptionIdNavigation? : SubscriptionClientResponseModel;

	
				constructor() {
					this.email = '';
this.id = 0;
this.password = '';
this.subscriptionId = 0;
this.subscriptionIdEntity = '';
this.subscriptionIdNavigation = undefined;

				}

				setProperties(email : string,id : number,password : string,subscriptionId : number) : void
				{
					this.email = email;
this.id = id;
this.password = password;
this.subscriptionId = subscriptionId;

				}
			}

			export class UserClientResponseModel {
				email:string;
id:number;
password:string;
subscriptionId:number;
subscriptionIdEntity : string;
subscriptionIdNavigation? : SubscriptionClientResponseModel;

	
				constructor() {
					this.email = '';
this.id = 0;
this.password = '';
this.subscriptionId = 0;
this.subscriptionIdEntity = '';
this.subscriptionIdNavigation = undefined;

				}

				setProperties(email : string,id : number,password : string,subscriptionId : number) : void
				{
					this.email = email;
this.id = id;
this.password = password;
this.subscriptionId = subscriptionId;

				}
			}
			export class SubscriptionClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

			export class SubscriptionClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

/*<Codenesium>
    <Hash>d794812cd345341f2a9f1cafd4bb32f7</Hash>
</Codenesium>*/