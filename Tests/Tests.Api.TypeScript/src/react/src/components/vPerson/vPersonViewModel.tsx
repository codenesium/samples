export default class VPersonViewModel {
    personId:number;
personName:string;

    constructor() {
		this.personId = 0;
this.personName = '';

    }

	setProperties(personId : number,personName : string) : void
	{
		this.personId = personId;
this.personName = personName;

	}

	toDisplay() : string
	{
		return String(NULL_STRING_PASSED_ToLowerCaseFirstLetter);
	}
};

/*<Codenesium>
    <Hash>6ecfe9e0a5b98bb62b271af0d9b14925</Hash>
</Codenesium>*/