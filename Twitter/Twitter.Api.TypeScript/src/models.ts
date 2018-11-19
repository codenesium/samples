export class ApiDirectTweetServerRequestModel {
				content:string;
date:string;
taggedUserId:number;
taggedUserIdEntity:number;
time:string;
tweetId:number;

	
				constructor() {
					this.content = '';
this.date = '';
this.taggedUserId = 0;
this.time = '';
this.tweetId = 0;

		
				}
			}

			export class ApiDirectTweetServerResponseModel {
				content:string;
date:string;
taggedUserId:number;
taggedUserIdEntity:number;
time:string;
tweetId:number;

	
				constructor() {
					this.content = '';
this.date = '';
this.taggedUserId = 0;
this.time = '';
this.tweetId = 0;

		
				}
			}
			export class ApiFollowerServerRequestModel {
				blocked:string;
dateFollowed:string;
followRequestStatu:string;
followedUserId:number;
followedUserIdEntity:number;
followingUserId:number;
followingUserIdEntity:number;
id:number;
muted:string;

	
				constructor() {
					this.blocked = '';
this.dateFollowed = '';
this.followRequestStatu = '';
this.followedUserId = 0;
this.followingUserId = 0;
this.id = 0;
this.muted = '';

		
				}
			}

			export class ApiFollowerServerResponseModel {
				blocked:string;
dateFollowed:string;
followRequestStatu:string;
followedUserId:number;
followedUserIdEntity:number;
followingUserId:number;
followingUserIdEntity:number;
id:number;
muted:string;

	
				constructor() {
					this.blocked = '';
this.dateFollowed = '';
this.followRequestStatu = '';
this.followedUserId = 0;
this.followingUserId = 0;
this.id = 0;
this.muted = '';

		
				}
			}
			export class ApiFollowingServerRequestModel {
				dateFollowed:string;
muted:string;
userId:number;

	
				constructor() {
					this.dateFollowed = '';
this.muted = '';
this.userId = 0;

		
				}
			}

			export class ApiFollowingServerResponseModel {
				dateFollowed:string;
muted:string;
userId:number;

	
				constructor() {
					this.dateFollowed = '';
this.muted = '';
this.userId = 0;

		
				}
			}
			export class ApiLocationServerRequestModel {
				gpsLat:number;
gpsLong:number;
locationId:number;
locationName:string;

	
				constructor() {
					this.gpsLat = 0;
this.gpsLong = 0;
this.locationId = 0;
this.locationName = '';

		
				}
			}

			export class ApiLocationServerResponseModel {
				gpsLat:number;
gpsLong:number;
locationId:number;
locationName:string;

	
				constructor() {
					this.gpsLat = 0;
this.gpsLong = 0;
this.locationId = 0;
this.locationName = '';

		
				}
			}
			export class ApiMessageServerRequestModel {
				content:string;
messageId:number;
senderUserId:number;
senderUserIdEntity:number;

	
				constructor() {
					this.content = '';
this.messageId = 0;
this.senderUserId = 0;

		
				}
			}

			export class ApiMessageServerResponseModel {
				content:string;
messageId:number;
senderUserId:number;
senderUserIdEntity:number;

	
				constructor() {
					this.content = '';
this.messageId = 0;
this.senderUserId = 0;

		
				}
			}
			export class ApiMessengerServerRequestModel {
				date:string;
fromUserId:number;
id:number;
messageId:number;
messageIdEntity:number;
time:string;
toUserId:number;
toUserIdEntity:number;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.date = '';
this.fromUserId = 0;
this.id = 0;
this.messageId = 0;
this.time = '';
this.toUserId = 0;
this.userId = 0;

		
				}
			}

			export class ApiMessengerServerResponseModel {
				date:string;
fromUserId:number;
id:number;
messageId:number;
messageIdEntity:number;
time:string;
toUserId:number;
toUserIdEntity:number;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.date = '';
this.fromUserId = 0;
this.id = 0;
this.messageId = 0;
this.time = '';
this.toUserId = 0;
this.userId = 0;

		
				}
			}
			export class ApiQuoteTweetServerRequestModel {
				content:string;
date:string;
quoteTweetId:number;
retweeterUserId:number;
retweeterUserIdEntity:number;
sourceTweetId:number;
sourceTweetIdEntity:number;
time:string;

	
				constructor() {
					this.content = '';
this.date = '';
this.quoteTweetId = 0;
this.retweeterUserId = 0;
this.sourceTweetId = 0;
this.time = '';

		
				}
			}

			export class ApiQuoteTweetServerResponseModel {
				content:string;
date:string;
quoteTweetId:number;
retweeterUserId:number;
retweeterUserIdEntity:number;
sourceTweetId:number;
sourceTweetIdEntity:number;
time:string;

	
				constructor() {
					this.content = '';
this.date = '';
this.quoteTweetId = 0;
this.retweeterUserId = 0;
this.sourceTweetId = 0;
this.time = '';

		
				}
			}
			export class ApiReplyServerRequestModel {
				content:string;
date:string;
replierUserId:number;
replierUserIdEntity:number;
replyId:number;
time:string;

	
				constructor() {
					this.content = '';
this.date = '';
this.replierUserId = 0;
this.replyId = 0;
this.time = '';

		
				}
			}

			export class ApiReplyServerResponseModel {
				content:string;
date:string;
replierUserId:number;
replierUserIdEntity:number;
replyId:number;
time:string;

	
				constructor() {
					this.content = '';
this.date = '';
this.replierUserId = 0;
this.replyId = 0;
this.time = '';

		
				}
			}
			export class ApiRetweetServerRequestModel {
				date:string;
id:number;
retwitterUserId:number;
retwitterUserIdEntity:number;
time:string;
tweetTweetId:number;
tweetTweetIdEntity:number;

	
				constructor() {
					this.date = '';
this.id = 0;
this.retwitterUserId = 0;
this.time = '';
this.tweetTweetId = 0;

		
				}
			}

			export class ApiRetweetServerResponseModel {
				date:string;
id:number;
retwitterUserId:number;
retwitterUserIdEntity:number;
time:string;
tweetTweetId:number;
tweetTweetIdEntity:number;

	
				constructor() {
					this.date = '';
this.id = 0;
this.retwitterUserId = 0;
this.time = '';
this.tweetTweetId = 0;

		
				}
			}
			export class ApiTweetServerRequestModel {
				content:string;
date:string;
locationId:number;
locationIdEntity:number;
time:string;
tweetId:number;
userUserId:number;
userUserIdEntity:number;

	
				constructor() {
					this.content = '';
this.date = '';
this.locationId = 0;
this.time = '';
this.tweetId = 0;
this.userUserId = 0;

		
				}
			}

			export class ApiTweetServerResponseModel {
				content:string;
date:string;
locationId:number;
locationIdEntity:number;
time:string;
tweetId:number;
userUserId:number;
userUserIdEntity:number;

	
				constructor() {
					this.content = '';
this.date = '';
this.locationId = 0;
this.time = '';
this.tweetId = 0;
this.userUserId = 0;

		
				}
			}
			export class ApiUserServerRequestModel {
				bioImgUrl:string;
birthday:string;
contentDescription:string;
email:string;
fullName:string;
headerImgUrl:string;
interest:string;
locationLocationId:number;
locationLocationIdEntity:number;
password:string;
phoneNumber:string;
privacy:string;
userId:number;
username:string;
website:string;

	
				constructor() {
					this.bioImgUrl = '';
this.birthday = '';
this.contentDescription = '';
this.email = '';
this.fullName = '';
this.headerImgUrl = '';
this.interest = '';
this.locationLocationId = 0;
this.password = '';
this.phoneNumber = '';
this.privacy = '';
this.userId = 0;
this.username = '';
this.website = '';

		
				}
			}

			export class ApiUserServerResponseModel {
				bioImgUrl:string;
birthday:string;
contentDescription:string;
email:string;
fullName:string;
headerImgUrl:string;
interest:string;
locationLocationId:number;
locationLocationIdEntity:number;
password:string;
phoneNumber:string;
privacy:string;
userId:number;
username:string;
website:string;

	
				constructor() {
					this.bioImgUrl = '';
this.birthday = '';
this.contentDescription = '';
this.email = '';
this.fullName = '';
this.headerImgUrl = '';
this.interest = '';
this.locationLocationId = 0;
this.password = '';
this.phoneNumber = '';
this.privacy = '';
this.userId = 0;
this.username = '';
this.website = '';

		
				}
			}