import moment from 'moment'
import UsersViewModel from '../users/usersViewModel'
	

export default class BadgesViewModel {
    date:any;
id:number;
name:string;
userId:number;
userIdEntity : string;
userIdNavigation? : UsersViewModel;

    constructor() {
		this.date = undefined;
this.id = 0;
this.name = '';
this.userId = 0;
this.userIdEntity = '';
this.userIdNavigation = new UsersViewModel();

    }

	setProperties(date : any,id : number,name : string,userId : number) : void
	{
		this.date = moment(date,'YYYY-MM-DD');
this.id = id;
this.name = name;
this.userId = userId;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>3508e1baf00d23d31d29ca3ecd111e84</Hash>
</Codenesium>*/