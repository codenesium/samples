import moment from 'moment'
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
this.taggedUserIdNavigation = new UserViewModel();
this.time = undefined;
this.tweetId = 0;

    }

	setProperties(content : string,date : any,taggedUserId : number,time : any,tweetId : number) : void
	{
		this.content = content;
this.date = moment(date,'YYYY-MM-DD');
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
    <Hash>d2d0abad72bd844d3623d453dcb424e9</Hash>
</Codenesium>*/