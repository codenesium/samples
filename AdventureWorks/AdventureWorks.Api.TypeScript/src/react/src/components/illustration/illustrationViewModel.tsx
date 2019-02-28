import moment from 'moment'


export default class IllustrationViewModel {
    diagram:string;
illustrationID:number;
modifiedDate:any;

    constructor() {
		this.diagram = '';
this.illustrationID = 0;
this.modifiedDate = undefined;

    }

	setProperties(diagram : string,illustrationID : number,modifiedDate : any) : void
	{
		this.diagram = moment(diagram,'YYYY-MM-DD');
this.illustrationID = moment(illustrationID,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>8b6155ce2da155fd825a7c035397ff7a</Hash>
</Codenesium>*/