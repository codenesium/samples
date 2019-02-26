import moment from 'moment'
import SubscriptionViewModel from '../subscription/subscriptionViewModel'
	

export default class UserViewModel {
    email:string;
id:number;
password:string;
subscriptionId:number;
subscriptionIdEntity : string;
subscriptionIdNavigation? : SubscriptionViewModel;

    constructor() {
		this.email = '';
this.id = 0;
this.password = '';
this.subscriptionId = 0;
this.subscriptionIdEntity = '';
this.subscriptionIdNavigation = new SubscriptionViewModel();

    }

	setProperties(email : string,id : number,password : string,subscriptionId : number) : void
	{
		this.email = email;
this.id = id;
this.password = password;
this.subscriptionId = subscriptionId;

	}

	toDisplay() : string
	{
		return String(this.email);
	}
};

/*<Codenesium>
    <Hash>3b1dd712fcbb68bde10afa8fa4aa6a78</Hash>
</Codenesium>*/