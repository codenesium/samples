import moment from 'moment'


export default class CommentViewModel {
    creationDate:any;
id:number;
postId:number;
score:any;
text:string;
userId:any;

    constructor() {
		this.creationDate = undefined;
this.id = 0;
this.postId = 0;
this.score = undefined;
this.text = '';
this.userId = undefined;

    }

	setProperties(creationDate : any,id : number,postId : number,score : any,text : string,userId : any) : void
	{
		this.creationDate = creationDate;
this.id = id;
this.postId = postId;
this.score = score;
this.text = text;
this.userId = userId;

	}

	toDisplay() : string
	{
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>80fcc8d3356aead092ae71ff82e91743</Hash>
</Codenesium>*/