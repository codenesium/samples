import UserViewModel from '../user/userViewModel'
	

export default class TeacherViewModel {
    birthday:any;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity : string;
userIdNavigation? : UserViewModel;

    constructor() {
		this.birthday = undefined;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.userIdEntity = '';
this.userIdNavigation = undefined;

    }

	setProperties(birthday : any,email : string,firstName : string,id : number,lastName : string,phone : string,userId : number) : void
	{
		this.birthday = birthday;
this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.phone = phone;
this.userId = userId;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>a7238865c24c91ad87a44968414fdcf0</Hash>
</Codenesium>*/