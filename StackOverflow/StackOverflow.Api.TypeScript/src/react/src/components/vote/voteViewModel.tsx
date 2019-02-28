import moment from 'moment'


export default class VoteViewModel {
    bountyAmount:any;
creationDate:any;
id:number;
postId:number;
userId:any;
voteTypeId:number;

    constructor() {
		this.bountyAmount = undefined;
this.creationDate = undefined;
this.id = 0;
this.postId = 0;
this.userId = undefined;
this.voteTypeId = 0;

    }

	setProperties(bountyAmount : any,creationDate : any,id : number,postId : number,userId : any,voteTypeId : number) : void
	{
		this.bountyAmount = bountyAmount;
this.creationDate = creationDate;
this.id = id;
this.postId = postId;
this.userId = userId;
this.voteTypeId = voteTypeId;

	}

	toDisplay() : string
	{
		return String(this.bountyAmount);
	}
};

/*<Codenesium>
    <Hash>6d58e286ee0fcea514db349c90bc9420</Hash>
</Codenesium>*/