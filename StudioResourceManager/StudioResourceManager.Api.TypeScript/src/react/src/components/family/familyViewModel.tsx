import moment from 'moment'


export default class FamilyViewModel {
    id:number;
note:string;
primaryContactEmail:string;
primaryContactFirstName:string;
primaryContactLastName:string;
primaryContactPhone:string;

    constructor() {
		this.id = 0;
this.note = '';
this.primaryContactEmail = '';
this.primaryContactFirstName = '';
this.primaryContactLastName = '';
this.primaryContactPhone = '';

    }

	setProperties(id : number,note : string,primaryContactEmail : string,primaryContactFirstName : string,primaryContactLastName : string,primaryContactPhone : string) : void
	{
		this.id = id;
this.note = note;
this.primaryContactEmail = primaryContactEmail;
this.primaryContactFirstName = primaryContactFirstName;
this.primaryContactLastName = primaryContactLastName;
this.primaryContactPhone = primaryContactPhone;

	}

	toDisplay() : string
	{
		return String(this.primaryContactLastName);
	}
};

/*<Codenesium>
    <Hash>67c0a7685f6f6e6a51c232d7a74a0749</Hash>
</Codenesium>*/