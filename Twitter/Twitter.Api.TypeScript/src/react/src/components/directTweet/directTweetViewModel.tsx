import UserViewModel from '../user/userViewModel'
	

export default class DirectTweetViewModel {
    content:string;
date:any;
taggedUserId:number;
taggedUserIdEntity : string;
taggedUserIdNavigation? : UserViewModel;
time:any;
tweetId:number;

    constructor() {
		this.content = '';
this.date = undefined;
this.taggedUserId = 0;
this.taggedUserIdEntity = '';
this.taggedUserIdNavigation = undefined;
this.time = undefined;
this.tweetId = 0;

    }

	setProperties(content : string,date : any,taggedUserId : number,time : any,tweetId : number) : void
	{
		this.content = content;
this.date = date;
this.taggedUserId = taggedUserId;
this.time = time;
this.tweetId = tweetId;

	}

	toDisplay() : string
	{
		return String(this.content);
	}
};

/*<Codenesium>
    <Hash>7967d27001f35f9ffe4656ef6867487b</Hash>
</Codenesium>*/