import moment from 'moment'


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
    <Hash>95fbb965ef0facb908ce4440d43c1596</Hash>
</Codenesium>*/