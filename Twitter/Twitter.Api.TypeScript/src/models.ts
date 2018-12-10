export class ApiDirectTweetClientRequestModel {
	content : string;
	date : string;
	taggedUserId : number;
	taggedUserIdEntity : string;
	time : string;
	tweetId : number;

	constructor() {
		this.content = '';
		this.date = '';
		this.taggedUserId = 0;
		this.taggedUserIdEntity = '';
		this.time = '';
		this.tweetId = 0;
	}
}

export class ApiDirectTweetClientResponseModel {
	content : string;
	date : string;
	taggedUserId : number;
	taggedUserIdEntity : string;
	time : string;
	tweetId : number;

	constructor() {
		this.content = '';
		this.date = '';
		this.taggedUserId = 0;
		this.taggedUserIdEntity = '';
		this.time = '';
		this.tweetId = 0;
	}
}
export class ApiFollowerClientRequestModel {
	blocked : string;
	dateFollowed : string;
	followRequestStatu : string;
	followedUserId : number;
	followedUserIdEntity : string;
	followingUserId : number;
	followingUserIdEntity : string;
	id : number;
	muted : string;

	constructor() {
		this.blocked = '';
		this.dateFollowed = '';
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
	dateFollowed : string;
	followRequestStatu : string;
	followedUserId : number;
	followedUserIdEntity : string;
	followingUserId : number;
	followingUserIdEntity : string;
	id : number;
	muted : string;

	constructor() {
		this.blocked = '';
		this.dateFollowed = '';
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
	dateFollowed : string;
	muted : string;
	userId : number;

	constructor() {
		this.dateFollowed = '';
		this.muted = '';
		this.userId = 0;
	}
}

export class ApiFollowingClientResponseModel {
	dateFollowed : string;
	muted : string;
	userId : number;

	constructor() {
		this.dateFollowed = '';
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
	senderUserId : number;
	senderUserIdEntity : string;

	constructor() {
		this.content = '';
		this.messageId = 0;
		this.senderUserId = 0;
		this.senderUserIdEntity = '';
	}
}

export class ApiMessageClientResponseModel {
	content : string;
	messageId : number;
	senderUserId : number;
	senderUserIdEntity : string;

	constructor() {
		this.content = '';
		this.messageId = 0;
		this.senderUserId = 0;
		this.senderUserIdEntity = '';
	}
}
export class ApiMessengerClientRequestModel {
	date : string;
	fromUserId : number;
	id : number;
	messageId : number;
	messageIdEntity : string;
	time : string;
	toUserId : number;
	toUserIdEntity : string;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.date = '';
		this.fromUserId = 0;
		this.id = 0;
		this.messageId = 0;
		this.messageIdEntity = '';
		this.time = '';
		this.toUserId = 0;
		this.toUserIdEntity = '';
		this.userId = 0;
		this.userIdEntity = '';
	}
}

export class ApiMessengerClientResponseModel {
	date : string;
	fromUserId : number;
	id : number;
	messageId : number;
	messageIdEntity : string;
	time : string;
	toUserId : number;
	toUserIdEntity : string;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.date = '';
		this.fromUserId = 0;
		this.id = 0;
		this.messageId = 0;
		this.messageIdEntity = '';
		this.time = '';
		this.toUserId = 0;
		this.toUserIdEntity = '';
		this.userId = 0;
		this.userIdEntity = '';
	}
}
export class ApiQuoteTweetClientRequestModel {
	content : string;
	date : string;
	quoteTweetId : number;
	retweeterUserId : number;
	retweeterUserIdEntity : string;
	sourceTweetId : number;
	sourceTweetIdEntity : string;
	time : string;

	constructor() {
		this.content = '';
		this.date = '';
		this.quoteTweetId = 0;
		this.retweeterUserId = 0;
		this.retweeterUserIdEntity = '';
		this.sourceTweetId = 0;
		this.sourceTweetIdEntity = '';
		this.time = '';
	}
}

export class ApiQuoteTweetClientResponseModel {
	content : string;
	date : string;
	quoteTweetId : number;
	retweeterUserId : number;
	retweeterUserIdEntity : string;
	sourceTweetId : number;
	sourceTweetIdEntity : string;
	time : string;

	constructor() {
		this.content = '';
		this.date = '';
		this.quoteTweetId = 0;
		this.retweeterUserId = 0;
		this.retweeterUserIdEntity = '';
		this.sourceTweetId = 0;
		this.sourceTweetIdEntity = '';
		this.time = '';
	}
}
export class ApiReplyClientRequestModel {
	content : string;
	date : string;
	replierUserId : number;
	replierUserIdEntity : string;
	replyId : number;
	time : string;

	constructor() {
		this.content = '';
		this.date = '';
		this.replierUserId = 0;
		this.replierUserIdEntity = '';
		this.replyId = 0;
		this.time = '';
	}
}

export class ApiReplyClientResponseModel {
	content : string;
	date : string;
	replierUserId : number;
	replierUserIdEntity : string;
	replyId : number;
	time : string;

	constructor() {
		this.content = '';
		this.date = '';
		this.replierUserId = 0;
		this.replierUserIdEntity = '';
		this.replyId = 0;
		this.time = '';
	}
}
export class ApiRetweetClientRequestModel {
	date : string;
	id : number;
	retwitterUserId : number;
	retwitterUserIdEntity : string;
	time : string;
	tweetTweetId : number;
	tweetTweetIdEntity : string;

	constructor() {
		this.date = '';
		this.id = 0;
		this.retwitterUserId = 0;
		this.retwitterUserIdEntity = '';
		this.time = '';
		this.tweetTweetId = 0;
		this.tweetTweetIdEntity = '';
	}
}

export class ApiRetweetClientResponseModel {
	date : string;
	id : number;
	retwitterUserId : number;
	retwitterUserIdEntity : string;
	time : string;
	tweetTweetId : number;
	tweetTweetIdEntity : string;

	constructor() {
		this.date = '';
		this.id = 0;
		this.retwitterUserId = 0;
		this.retwitterUserIdEntity = '';
		this.time = '';
		this.tweetTweetId = 0;
		this.tweetTweetIdEntity = '';
	}
}
export class ApiTweetClientRequestModel {
	content : string;
	date : string;
	locationId : number;
	locationIdEntity : string;
	time : string;
	tweetId : number;
	userUserId : number;
	userUserIdEntity : string;

	constructor() {
		this.content = '';
		this.date = '';
		this.locationId = 0;
		this.locationIdEntity = '';
		this.time = '';
		this.tweetId = 0;
		this.userUserId = 0;
		this.userUserIdEntity = '';
	}
}

export class ApiTweetClientResponseModel {
	content : string;
	date : string;
	locationId : number;
	locationIdEntity : string;
	time : string;
	tweetId : number;
	userUserId : number;
	userUserIdEntity : string;

	constructor() {
		this.content = '';
		this.date = '';
		this.locationId = 0;
		this.locationIdEntity = '';
		this.time = '';
		this.tweetId = 0;
		this.userUserId = 0;
		this.userUserIdEntity = '';
	}
}
export class ApiUserClientRequestModel {
	bioImgUrl : string;
	birthday : string;
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
		this.birthday = '';
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
	birthday : string;
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
		this.birthday = '';
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
    <Hash>141ca409ca7f470bf485e198146d2676</Hash>
</Codenesium>*/