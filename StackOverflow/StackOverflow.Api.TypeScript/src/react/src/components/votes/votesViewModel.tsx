import moment from 'moment'
import PostsViewModel from '../posts/postsViewModel'
	import UsersViewModel from '../users/usersViewModel'
	import VoteTypesViewModel from '../voteTypes/voteTypesViewModel'
	

export default class VotesViewModel {
    bountyAmount:any;
creationDate:any;
id:number;
postId:number;
postIdEntity : string;
postIdNavigation? : PostsViewModel;
userId:any;
userIdEntity : string;
userIdNavigation? : UsersViewModel;
voteTypeId:number;
voteTypeIdEntity : string;
voteTypeIdNavigation? : VoteTypesViewModel;

    constructor() {
		this.bountyAmount = undefined;
this.creationDate = undefined;
this.id = 0;
this.postId = 0;
this.postIdEntity = '';
this.postIdNavigation = new PostsViewModel();
this.userId = undefined;
this.userIdEntity = '';
this.userIdNavigation = new UsersViewModel();
this.voteTypeId = 0;
this.voteTypeIdEntity = '';
this.voteTypeIdNavigation = new VoteTypesViewModel();

    }

	setProperties(bountyAmount : any,creationDate : any,id : number,postId : number,userId : any,voteTypeId : number) : void
	{
		this.bountyAmount = bountyAmount;
this.creationDate = moment(creationDate,'YYYY-MM-DD');
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
    <Hash>7eab435f8c7b24d79c4175c6b6af7158</Hash>
</Codenesium>*/