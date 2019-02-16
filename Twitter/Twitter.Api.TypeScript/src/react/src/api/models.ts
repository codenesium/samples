export class DirectTweetClientRequestModel {
  content: string;
  date: any;
  taggedUserId: number;
  taggedUserIdEntity: string;
  taggedUserIdNavigation?: UserClientResponseModel;
  time: any;
  tweetId: number;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.taggedUserId = 0;
    this.taggedUserIdEntity = '';
    this.taggedUserIdNavigation = undefined;
    this.time = undefined;
    this.tweetId = 0;
  }

  setProperties(
    content: string,
    date: any,
    taggedUserId: number,
    time: any,
    tweetId: number
  ): void {
    this.content = content;
    this.date = date;
    this.taggedUserId = taggedUserId;
    this.time = time;
    this.tweetId = tweetId;
  }
}

export class DirectTweetClientResponseModel {
  content: string;
  date: any;
  taggedUserId: number;
  taggedUserIdEntity: string;
  taggedUserIdNavigation?: UserClientResponseModel;
  time: any;
  tweetId: number;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.taggedUserId = 0;
    this.taggedUserIdEntity = '';
    this.taggedUserIdNavigation = undefined;
    this.time = undefined;
    this.tweetId = 0;
  }

  setProperties(
    content: string,
    date: any,
    taggedUserId: number,
    time: any,
    tweetId: number
  ): void {
    this.content = content;
    this.date = date;
    this.taggedUserId = taggedUserId;
    this.time = time;
    this.tweetId = tweetId;
  }
}
export class FollowerClientRequestModel {
  blocked: string;
  dateFollowed: any;
  followRequestStatu: string;
  followedUserId: number;
  followedUserIdEntity: string;
  followedUserIdNavigation?: UserClientResponseModel;
  followingUserId: number;
  followingUserIdEntity: string;
  followingUserIdNavigation?: UserClientResponseModel;
  id: number;
  muted: string;

  constructor() {
    this.blocked = '';
    this.dateFollowed = undefined;
    this.followRequestStatu = '';
    this.followedUserId = 0;
    this.followedUserIdEntity = '';
    this.followedUserIdNavigation = undefined;
    this.followingUserId = 0;
    this.followingUserIdEntity = '';
    this.followingUserIdNavigation = undefined;
    this.id = 0;
    this.muted = '';
  }

  setProperties(
    blocked: string,
    dateFollowed: any,
    followRequestStatu: string,
    followedUserId: number,
    followingUserId: number,
    id: number,
    muted: string
  ): void {
    this.blocked = blocked;
    this.dateFollowed = dateFollowed;
    this.followRequestStatu = followRequestStatu;
    this.followedUserId = followedUserId;
    this.followingUserId = followingUserId;
    this.id = id;
    this.muted = muted;
  }
}

export class FollowerClientResponseModel {
  blocked: string;
  dateFollowed: any;
  followRequestStatu: string;
  followedUserId: number;
  followedUserIdEntity: string;
  followedUserIdNavigation?: UserClientResponseModel;
  followingUserId: number;
  followingUserIdEntity: string;
  followingUserIdNavigation?: UserClientResponseModel;
  id: number;
  muted: string;

  constructor() {
    this.blocked = '';
    this.dateFollowed = undefined;
    this.followRequestStatu = '';
    this.followedUserId = 0;
    this.followedUserIdEntity = '';
    this.followedUserIdNavigation = undefined;
    this.followingUserId = 0;
    this.followingUserIdEntity = '';
    this.followingUserIdNavigation = undefined;
    this.id = 0;
    this.muted = '';
  }

  setProperties(
    blocked: string,
    dateFollowed: any,
    followRequestStatu: string,
    followedUserId: number,
    followingUserId: number,
    id: number,
    muted: string
  ): void {
    this.blocked = blocked;
    this.dateFollowed = dateFollowed;
    this.followRequestStatu = followRequestStatu;
    this.followedUserId = followedUserId;
    this.followingUserId = followingUserId;
    this.id = id;
    this.muted = muted;
  }
}
export class FollowingClientRequestModel {
  dateFollowed: any;
  muted: string;
  userId: number;

  constructor() {
    this.dateFollowed = undefined;
    this.muted = '';
    this.userId = 0;
  }

  setProperties(dateFollowed: any, muted: string, userId: number): void {
    this.dateFollowed = dateFollowed;
    this.muted = muted;
    this.userId = userId;
  }
}

export class FollowingClientResponseModel {
  dateFollowed: any;
  muted: string;
  userId: number;

  constructor() {
    this.dateFollowed = undefined;
    this.muted = '';
    this.userId = 0;
  }

  setProperties(dateFollowed: any, muted: string, userId: number): void {
    this.dateFollowed = dateFollowed;
    this.muted = muted;
    this.userId = userId;
  }
}
export class LocationClientRequestModel {
  gpsLat: number;
  gpsLong: number;
  locationId: number;
  locationName: string;

  constructor() {
    this.gpsLat = 0;
    this.gpsLong = 0;
    this.locationId = 0;
    this.locationName = '';
  }

  setProperties(
    gpsLat: number,
    gpsLong: number,
    locationId: number,
    locationName: string
  ): void {
    this.gpsLat = gpsLat;
    this.gpsLong = gpsLong;
    this.locationId = locationId;
    this.locationName = locationName;
  }
}

export class LocationClientResponseModel {
  gpsLat: number;
  gpsLong: number;
  locationId: number;
  locationName: string;

  constructor() {
    this.gpsLat = 0;
    this.gpsLong = 0;
    this.locationId = 0;
    this.locationName = '';
  }

  setProperties(
    gpsLat: number,
    gpsLong: number,
    locationId: number,
    locationName: string
  ): void {
    this.gpsLat = gpsLat;
    this.gpsLong = gpsLong;
    this.locationId = locationId;
    this.locationName = locationName;
  }
}
export class MessageClientRequestModel {
  content: string;
  messageId: number;
  senderUserId: any;
  senderUserIdEntity: string;
  senderUserIdNavigation?: UserClientResponseModel;

  constructor() {
    this.content = '';
    this.messageId = 0;
    this.senderUserId = undefined;
    this.senderUserIdEntity = '';
    this.senderUserIdNavigation = undefined;
  }

  setProperties(content: string, messageId: number, senderUserId: any): void {
    this.content = content;
    this.messageId = messageId;
    this.senderUserId = senderUserId;
  }
}

export class MessageClientResponseModel {
  content: string;
  messageId: number;
  senderUserId: any;
  senderUserIdEntity: string;
  senderUserIdNavigation?: UserClientResponseModel;

  constructor() {
    this.content = '';
    this.messageId = 0;
    this.senderUserId = undefined;
    this.senderUserIdEntity = '';
    this.senderUserIdNavigation = undefined;
  }

  setProperties(content: string, messageId: number, senderUserId: any): void {
    this.content = content;
    this.messageId = messageId;
    this.senderUserId = senderUserId;
  }
}
export class MessengerClientRequestModel {
  date: any;
  fromUserId: any;
  id: number;
  messageId: any;
  messageIdEntity: string;
  messageIdNavigation?: MessageClientResponseModel;
  time: any;
  toUserId: number;
  toUserIdEntity: string;
  toUserIdNavigation?: UserClientResponseModel;
  userId: any;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.date = undefined;
    this.fromUserId = undefined;
    this.id = 0;
    this.messageId = undefined;
    this.messageIdEntity = '';
    this.messageIdNavigation = undefined;
    this.time = undefined;
    this.toUserId = 0;
    this.toUserIdEntity = '';
    this.toUserIdNavigation = undefined;
    this.userId = undefined;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    date: any,
    fromUserId: any,
    id: number,
    messageId: any,
    time: any,
    toUserId: number,
    userId: any
  ): void {
    this.date = date;
    this.fromUserId = fromUserId;
    this.id = id;
    this.messageId = messageId;
    this.time = time;
    this.toUserId = toUserId;
    this.userId = userId;
  }
}

export class MessengerClientResponseModel {
  date: any;
  fromUserId: any;
  id: number;
  messageId: any;
  messageIdEntity: string;
  messageIdNavigation?: MessageClientResponseModel;
  time: any;
  toUserId: number;
  toUserIdEntity: string;
  toUserIdNavigation?: UserClientResponseModel;
  userId: any;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.date = undefined;
    this.fromUserId = undefined;
    this.id = 0;
    this.messageId = undefined;
    this.messageIdEntity = '';
    this.messageIdNavigation = undefined;
    this.time = undefined;
    this.toUserId = 0;
    this.toUserIdEntity = '';
    this.toUserIdNavigation = undefined;
    this.userId = undefined;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    date: any,
    fromUserId: any,
    id: number,
    messageId: any,
    time: any,
    toUserId: number,
    userId: any
  ): void {
    this.date = date;
    this.fromUserId = fromUserId;
    this.id = id;
    this.messageId = messageId;
    this.time = time;
    this.toUserId = toUserId;
    this.userId = userId;
  }
}
export class QuoteTweetClientRequestModel {
  content: string;
  date: any;
  quoteTweetId: number;
  retweeterUserId: number;
  retweeterUserIdEntity: string;
  retweeterUserIdNavigation?: UserClientResponseModel;
  sourceTweetId: number;
  sourceTweetIdEntity: string;
  sourceTweetIdNavigation?: TweetClientResponseModel;
  time: any;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.quoteTweetId = 0;
    this.retweeterUserId = 0;
    this.retweeterUserIdEntity = '';
    this.retweeterUserIdNavigation = undefined;
    this.sourceTweetId = 0;
    this.sourceTweetIdEntity = '';
    this.sourceTweetIdNavigation = undefined;
    this.time = undefined;
  }

  setProperties(
    content: string,
    date: any,
    quoteTweetId: number,
    retweeterUserId: number,
    sourceTweetId: number,
    time: any
  ): void {
    this.content = content;
    this.date = date;
    this.quoteTweetId = quoteTweetId;
    this.retweeterUserId = retweeterUserId;
    this.sourceTweetId = sourceTweetId;
    this.time = time;
  }
}

export class QuoteTweetClientResponseModel {
  content: string;
  date: any;
  quoteTweetId: number;
  retweeterUserId: number;
  retweeterUserIdEntity: string;
  retweeterUserIdNavigation?: UserClientResponseModel;
  sourceTweetId: number;
  sourceTweetIdEntity: string;
  sourceTweetIdNavigation?: TweetClientResponseModel;
  time: any;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.quoteTweetId = 0;
    this.retweeterUserId = 0;
    this.retweeterUserIdEntity = '';
    this.retweeterUserIdNavigation = undefined;
    this.sourceTweetId = 0;
    this.sourceTweetIdEntity = '';
    this.sourceTweetIdNavigation = undefined;
    this.time = undefined;
  }

  setProperties(
    content: string,
    date: any,
    quoteTweetId: number,
    retweeterUserId: number,
    sourceTweetId: number,
    time: any
  ): void {
    this.content = content;
    this.date = date;
    this.quoteTweetId = quoteTweetId;
    this.retweeterUserId = retweeterUserId;
    this.sourceTweetId = sourceTweetId;
    this.time = time;
  }
}
export class ReplyClientRequestModel {
  content: string;
  date: any;
  replierUserId: number;
  replierUserIdEntity: string;
  replierUserIdNavigation?: UserClientResponseModel;
  replyId: number;
  time: any;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.replierUserId = 0;
    this.replierUserIdEntity = '';
    this.replierUserIdNavigation = undefined;
    this.replyId = 0;
    this.time = undefined;
  }

  setProperties(
    content: string,
    date: any,
    replierUserId: number,
    replyId: number,
    time: any
  ): void {
    this.content = content;
    this.date = date;
    this.replierUserId = replierUserId;
    this.replyId = replyId;
    this.time = time;
  }
}

export class ReplyClientResponseModel {
  content: string;
  date: any;
  replierUserId: number;
  replierUserIdEntity: string;
  replierUserIdNavigation?: UserClientResponseModel;
  replyId: number;
  time: any;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.replierUserId = 0;
    this.replierUserIdEntity = '';
    this.replierUserIdNavigation = undefined;
    this.replyId = 0;
    this.time = undefined;
  }

  setProperties(
    content: string,
    date: any,
    replierUserId: number,
    replyId: number,
    time: any
  ): void {
    this.content = content;
    this.date = date;
    this.replierUserId = replierUserId;
    this.replyId = replyId;
    this.time = time;
  }
}
export class RetweetClientRequestModel {
  date: any;
  id: number;
  retwitterUserId: any;
  retwitterUserIdEntity: string;
  retwitterUserIdNavigation?: UserClientResponseModel;
  time: any;
  tweetTweetId: number;
  tweetTweetIdEntity: string;
  tweetTweetIdNavigation?: TweetClientResponseModel;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.retwitterUserId = undefined;
    this.retwitterUserIdEntity = '';
    this.retwitterUserIdNavigation = undefined;
    this.time = undefined;
    this.tweetTweetId = 0;
    this.tweetTweetIdEntity = '';
    this.tweetTweetIdNavigation = undefined;
  }

  setProperties(
    date: any,
    id: number,
    retwitterUserId: any,
    time: any,
    tweetTweetId: number
  ): void {
    this.date = date;
    this.id = id;
    this.retwitterUserId = retwitterUserId;
    this.time = time;
    this.tweetTweetId = tweetTweetId;
  }
}

export class RetweetClientResponseModel {
  date: any;
  id: number;
  retwitterUserId: any;
  retwitterUserIdEntity: string;
  retwitterUserIdNavigation?: UserClientResponseModel;
  time: any;
  tweetTweetId: number;
  tweetTweetIdEntity: string;
  tweetTweetIdNavigation?: TweetClientResponseModel;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.retwitterUserId = undefined;
    this.retwitterUserIdEntity = '';
    this.retwitterUserIdNavigation = undefined;
    this.time = undefined;
    this.tweetTweetId = 0;
    this.tweetTweetIdEntity = '';
    this.tweetTweetIdNavigation = undefined;
  }

  setProperties(
    date: any,
    id: number,
    retwitterUserId: any,
    time: any,
    tweetTweetId: number
  ): void {
    this.date = date;
    this.id = id;
    this.retwitterUserId = retwitterUserId;
    this.time = time;
    this.tweetTweetId = tweetTweetId;
  }
}
export class TweetClientRequestModel {
  content: string;
  date: any;
  locationId: number;
  locationIdEntity: string;
  locationIdNavigation?: LocationClientResponseModel;
  time: any;
  tweetId: number;
  userUserId: number;
  userUserIdEntity: string;
  userUserIdNavigation?: UserClientResponseModel;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.locationId = 0;
    this.locationIdEntity = '';
    this.locationIdNavigation = undefined;
    this.time = undefined;
    this.tweetId = 0;
    this.userUserId = 0;
    this.userUserIdEntity = '';
    this.userUserIdNavigation = undefined;
  }

  setProperties(
    content: string,
    date: any,
    locationId: number,
    time: any,
    tweetId: number,
    userUserId: number
  ): void {
    this.content = content;
    this.date = date;
    this.locationId = locationId;
    this.time = time;
    this.tweetId = tweetId;
    this.userUserId = userUserId;
  }
}

export class TweetClientResponseModel {
  content: string;
  date: any;
  locationId: number;
  locationIdEntity: string;
  locationIdNavigation?: LocationClientResponseModel;
  time: any;
  tweetId: number;
  userUserId: number;
  userUserIdEntity: string;
  userUserIdNavigation?: UserClientResponseModel;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.locationId = 0;
    this.locationIdEntity = '';
    this.locationIdNavigation = undefined;
    this.time = undefined;
    this.tweetId = 0;
    this.userUserId = 0;
    this.userUserIdEntity = '';
    this.userUserIdNavigation = undefined;
  }

  setProperties(
    content: string,
    date: any,
    locationId: number,
    time: any,
    tweetId: number,
    userUserId: number
  ): void {
    this.content = content;
    this.date = date;
    this.locationId = locationId;
    this.time = time;
    this.tweetId = tweetId;
    this.userUserId = userUserId;
  }
}
export class UserClientRequestModel {
  bioImgUrl: string;
  birthday: any;
  contentDescription: string;
  email: string;
  fullName: string;
  headerImgUrl: string;
  interest: string;
  locationLocationId: number;
  locationLocationIdEntity: string;
  locationLocationIdNavigation?: LocationClientResponseModel;
  password: string;
  phoneNumber: string;
  privacy: string;
  userId: number;
  username: string;
  website: string;

  constructor() {
    this.bioImgUrl = '';
    this.birthday = undefined;
    this.contentDescription = '';
    this.email = '';
    this.fullName = '';
    this.headerImgUrl = '';
    this.interest = '';
    this.locationLocationId = 0;
    this.locationLocationIdEntity = '';
    this.locationLocationIdNavigation = undefined;
    this.password = '';
    this.phoneNumber = '';
    this.privacy = '';
    this.userId = 0;
    this.username = '';
    this.website = '';
  }

  setProperties(
    bioImgUrl: string,
    birthday: any,
    contentDescription: string,
    email: string,
    fullName: string,
    headerImgUrl: string,
    interest: string,
    locationLocationId: number,
    password: string,
    phoneNumber: string,
    privacy: string,
    userId: number,
    username: string,
    website: string
  ): void {
    this.bioImgUrl = bioImgUrl;
    this.birthday = birthday;
    this.contentDescription = contentDescription;
    this.email = email;
    this.fullName = fullName;
    this.headerImgUrl = headerImgUrl;
    this.interest = interest;
    this.locationLocationId = locationLocationId;
    this.password = password;
    this.phoneNumber = phoneNumber;
    this.privacy = privacy;
    this.userId = userId;
    this.username = username;
    this.website = website;
  }
}

export class UserClientResponseModel {
  bioImgUrl: string;
  birthday: any;
  contentDescription: string;
  email: string;
  fullName: string;
  headerImgUrl: string;
  interest: string;
  locationLocationId: number;
  locationLocationIdEntity: string;
  locationLocationIdNavigation?: LocationClientResponseModel;
  password: string;
  phoneNumber: string;
  privacy: string;
  userId: number;
  username: string;
  website: string;

  constructor() {
    this.bioImgUrl = '';
    this.birthday = undefined;
    this.contentDescription = '';
    this.email = '';
    this.fullName = '';
    this.headerImgUrl = '';
    this.interest = '';
    this.locationLocationId = 0;
    this.locationLocationIdEntity = '';
    this.locationLocationIdNavigation = undefined;
    this.password = '';
    this.phoneNumber = '';
    this.privacy = '';
    this.userId = 0;
    this.username = '';
    this.website = '';
  }

  setProperties(
    bioImgUrl: string,
    birthday: any,
    contentDescription: string,
    email: string,
    fullName: string,
    headerImgUrl: string,
    interest: string,
    locationLocationId: number,
    password: string,
    phoneNumber: string,
    privacy: string,
    userId: number,
    username: string,
    website: string
  ): void {
    this.bioImgUrl = bioImgUrl;
    this.birthday = birthday;
    this.contentDescription = contentDescription;
    this.email = email;
    this.fullName = fullName;
    this.headerImgUrl = headerImgUrl;
    this.interest = interest;
    this.locationLocationId = locationLocationId;
    this.password = password;
    this.phoneNumber = phoneNumber;
    this.privacy = privacy;
    this.userId = userId;
    this.username = username;
    this.website = website;
  }
}


/*<Codenesium>
    <Hash>7ebea128e72dbb8bcb334b61f49c1aee</Hash>
</Codenesium>*/