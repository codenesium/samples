export default class FollowingViewModel {
    dateFollowed:any;
muted:string;
userId:number;

    constructor() {
		this.dateFollowed = undefined;
this.muted = '';
this.userId = 0;

    }

	setProperties(dateFollowed : any,muted : string,userId : number) : void
	{
		this.dateFollowed = dateFollowed;
this.muted = muted;
this.userId = userId;

	}

	toDisplay() : string
	{
		return String(this.user_id);
	}
};

/*<Codenesium>
    <Hash>58c48468b49201df5ac863b43329f6b3</Hash>
</Codenesium>*/