export class ApiDirectTweetClientRequestModel {
	content : string;
	date : any;
	taggedUserId : number;
	taggedUserIdEntity : string;
	time : any;
	tweetId : number;

	constructor() {
		this.content = '';
		this.date = null;
		this.taggedUserId = 0;
		this.taggedUserIdEntity = '';
		this.time = null;
		this.tweetId = 0;
	}
}

export class ApiDirectTweetClientResponseModel {
	content : string;
	date : any;
	taggedUserId : number;
	taggedUserIdEntity : string;
	time : any;
	tweetId : number;

	constructor() {
		this.content = '';
		this.date = null;
		this.taggedUserId = 0;
		this.taggedUserIdEntity = '';
		this.time = null;
		this.tweetId = 0;
	}
}
export class ApiFollowerClientRequestModel {
	blocked : string;
	dateFollowed : any;
	followRequestStatu : string;
	followedUserId : number;
	followedUserIdEntity : string;
	followingUserId : number;
	followingUserIdEntity : string;
	id : number;
	muted : string;

	constructor() {
		this.blocked = '';
		this.dateFollowed = null;
		this.followRequestStatu = '';
		this.followedUserId = 0;
		this.followedUserIdEntity = '';
		this.followingUserId = 0;
		this.followingUserIdEntity = '';
		this.id = 0;
		this.muted = '';
	}
}

export class ApiFollowerClientResponseModel {
	blocked : string;
	dateFollowed : any;
	followRequestStatu : string;
	followedUserId : number;
	followedUserIdEntity : string;
	followingUserId : number;
	followingUserIdEntity : string;
	id : number;
	muted : string;

	constructor() {
		this.blocked = '';
		this.dateFollowed = null;
		this.followRequestStatu = '';
		this.followedUserId = 0;
		this.followedUserIdEntity = '';
		this.followingUserId = 0;
		this.followingUserIdEntity = '';
		this.id = 0;
		this.muted = '';
	}
}
export class ApiFollowingClientRequestModel {
	dateFollowed : any;
	muted : string;
	userId : number;

	constructor() {
		this.dateFollowed = null;
		this.muted = '';
		this.userId = 0;
	}
}

export class ApiFollowingClientResponseModel {
	dateFollowed : any;
	muted : string;
	userId : number;

	constructor() {
		this.dateFollowed = null;
		this.muted = '';
		this.userId = 0;
	}
}
export class ApiLocationClientRequestModel {
	gpsLat : number;
	gpsLong : number;
	locationId : number;
	locationName : string;

	constructor() {
		this.gpsLat = 0;
		this.gpsLong = 0;
		this.locationId = 0;
		this.locationName = '';
	}
}

export class ApiLocationClientResponseModel {
	gpsLat : number;
	gpsLong : number;
	locationId : number;
	locationName : string;

	constructor() {
		this.gpsLat = 0;
		this.gpsLong = 0;
		this.locationId = 0;
		this.locationName = '';
	}
}
export class ApiMessageClientRequestModel {
	content : string;
	messageId : number;
	senderUserId : any;
	senderUserIdEntity : string;

	constructor() {
		this.content = '';
		this.messageId = 0;
		this.senderUserId = null;
		this.senderUserIdEntity = '';
	}
}

export class ApiMessageClientResponseModel {
	content : string;
	messageId : number;
	senderUserId : any;
	senderUserIdEntity : string;

	constructor() {
		this.content = '';
		this.messageId = 0;
		this.senderUserId = null;
		this.senderUserIdEntity = '';
	}
}
export class ApiMessengerClientRequestModel {
	date : any;
	fromUserId : any;
	id : number;
	messageId : any;
	messageIdEntity : string;
	time : any;
	toUserId : number;
	toUserIdEntity : string;
	userId : any;
	userIdEntity : string;

	constructor() {
		this.date = null;
		this.fromUserId = null;
		this.id = 0;
		this.messageId = null;
		this.messageIdEntity = '';
		this.time = null;
		this.toUserId = 0;
		this.toUserIdEntity = '';
		this.userId = null;
		this.userIdEntity = '';
	}
}

export class ApiMessengerClientResponseModel {
	date : any;
	fromUserId : any;
	id : number;
	messageId : any;
	messageIdEntity : string;
	time : any;
	toUserId : number;
	toUserIdEntity : string;
	userId : any;
	userIdEntity : string;

	constructor() {
		this.date = null;
		this.fromUserId = null;
		this.id = 0;
		this.messageId = null;
		this.messageIdEntity = '';
		this.time = null;
		this.toUserId = 0;
		this.toUserIdEntity = '';
		this.userId = null;
		this.userIdEntity = '';
	}
}
export class ApiQuoteTweetClientRequestModel {
	content : string;
	date : any;
	quoteTweetId : number;
	retweeterUserId : number;
	retweeterUserIdEntity : string;
	sourceTweetId : number;
	sourceTweetIdEntity : string;
	time : any;

	constructor() {
		this.content = '';
		this.date = null;
		this.quoteTweetId = 0;
		this.retweeterUserId = 0;
		this.retweeterUserIdEntity = '';
		this.sourceTweetId = 0;
		this.sourceTweetIdEntity = '';
		this.time = null;
	}
}

export class ApiQuoteTweetClientResponseModel {
	content : string;
	date : any;
	quoteTweetId : number;
	retweeterUserId : number;
	retweeterUserIdEntity : string;
	sourceTweetId : number;
	sourceTweetIdEntity : string;
	time : any;

	constructor() {
		this.content = '';
		this.date = null;
		this.quoteTweetId = 0;
		this.retweeterUserId = 0;
		this.retweeterUserIdEntity = '';
		this.sourceTweetId = 0;
		this.sourceTweetIdEntity = '';
		this.time = null;
	}
}
export class ApiReplyClientRequestModel {
	content : string;
	date : any;
	replierUserId : number;
	replierUserIdEntity : string;
	replyId : number;
	time : any;

	constructor() {
		this.content = '';
		this.date = null;
		this.replierUserId = 0;
		this.replierUserIdEntity = '';
		this.replyId = 0;
		this.time = null;
	}
}

export class ApiReplyClientResponseModel {
	content : string;
	date : any;
	replierUserId : number;
	replierUserIdEntity : string;
	replyId : number;
	time : any;

	constructor() {
		this.content = '';
		this.date = null;
		this.replierUserId = 0;
		this.replierUserIdEntity = '';
		this.replyId = 0;
		this.time = null;
	}
}
export class ApiRetweetClientRequestModel {
	date : any;
	id : number;
	retwitterUserId : any;
	retwitterUserIdEntity : string;
	time : any;
	tweetTweetId : number;
	tweetTweetIdEntity : string;

	constructor() {
		this.date = null;
		this.id = 0;
		this.retwitterUserId = null;
		this.retwitterUserIdEntity = '';
		this.time = null;
		this.tweetTweetId = 0;
		this.tweetTweetIdEntity = '';
	}
}

export class ApiRetweetClientResponseModel {
	date : any;
	id : number;
	retwitterUserId : any;
	retwitterUserIdEntity : string;
	time : any;
	tweetTweetId : number;
	tweetTweetIdEntity : string;

	constructor() {
		this.date = null;
		this.id = 0;
		this.retwitterUserId = null;
		this.retwitterUserIdEntity = '';
		this.time = null;
		this.tweetTweetId = 0;
		this.tweetTweetIdEntity = '';
	}
}
export class ApiTweetClientRequestModel {
	content : string;
	date : any;
	locationId : number;
	locationIdEntity : string;
	time : any;
	tweetId : number;
	userUserId : number;
	userUserIdEntity : string;

	constructor() {
		this.content = '';
		this.date = null;
		this.locationId = 0;
		this.locationIdEntity = '';
		this.time = null;
		this.tweetId = 0;
		this.userUserId = 0;
		this.userUserIdEntity = '';
	}
}

export class ApiTweetClientResponseModel {
	content : string;
	date : any;
	locationId : number;
	locationIdEntity : string;
	time : any;
	tweetId : number;
	userUserId : number;
	userUserIdEntity : string;

	constructor() {
		this.content = '';
		this.date = null;
		this.locationId = 0;
		this.locationIdEntity = '';
		this.time = null;
		this.tweetId = 0;
		this.userUserId = 0;
		this.userUserIdEntity = '';
	}
}
export class ApiUserClientRequestModel {
	bioImgUrl : string;
	birthday : any;
	contentDescription : string;
	email : string;
	fullName : string;
	headerImgUrl : string;
	interest : string;
	locationLocationId : number;
	locationLocationIdEntity : string;
	password : string;
	phoneNumber : string;
	privacy : string;
	userId : number;
	username : string;
	website : string;

	constructor() {
		this.bioImgUrl = '';
		this.birthday = null;
		this.contentDescription = '';
		this.email = '';
		this.fullName = '';
		this.headerImgUrl = '';
		this.interest = '';
		this.locationLocationId = 0;
		this.locationLocationIdEntity = '';
		this.password = '';
		this.phoneNumber = '';
		this.privacy = '';
		this.userId = 0;
		this.username = '';
		this.website = '';
	}
}

export class ApiUserClientResponseModel {
	bioImgUrl : string;
	birthday : any;
	contentDescription : string;
	email : string;
	fullName : string;
	headerImgUrl : string;
	interest : string;
	locationLocationId : number;
	locationLocationIdEntity : string;
	password : string;
	phoneNumber : string;
	privacy : string;
	userId : number;
	username : string;
	website : string;

	constructor() {
		this.bioImgUrl = '';
		this.birthday = null;
		this.contentDescription = '';
		this.email = '';
		this.fullName = '';
		this.headerImgUrl = '';
		this.interest = '';
		this.locationLocationId = 0;
		this.locationLocationIdEntity = '';
		this.password = '';
		this.phoneNumber = '';
		this.privacy = '';
		this.userId = 0;
		this.username = '';
		this.website = '';
	}
}

/*<Codenesium>
    <Hash>780c7c6ed7bd130c80fd3010fc97ac47</Hash>
</Codenesium>*/