import moment from 'moment'
import UserViewModel from '../user/userViewModel'
	

export default class FollowerViewModel {
    blocked:string;
dateFollowed:any;
followRequestStatu:string;
followedUserId:number;
followedUserIdEntity : string;
followedUserIdNavigation? : UserViewModel;
followingUserId:number;
followingUserIdEntity : string;
followingUserIdNavigation? : UserViewModel;
id:number;
muted:string;

    constructor() {
		this.blocked = '';
this.dateFollowed = undefined;
this.followRequestStatu = '';
this.followedUserId = 0;
this.followedUserIdEntity = '';
this.followedUserIdNavigation = new UserViewModel();
this.followingUserId = 0;
this.followingUserIdEntity = '';
this.followingUserIdNavigation = new UserViewModel();
this.id = 0;
this.muted = '';

    }

	setProperties(blocked : string,dateFollowed : any,followRequestStatu : string,followedUserId : number,followingUserId : number,id : number,muted : string) : void
	{
		this.blocked = blocked;
this.dateFollowed = dateFollowed;
this.followRequestStatu = followRequestStatu;
this.followedUserId = followedUserId;
this.followingUserId = followingUserId;
this.id = id;
this.muted = muted;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>336d586ae051bbe7ff663e5396b2d9ce</Hash>
</Codenesium>*/