export class BadgeClientRequestModel {
  date: any;
  id: number;
  name: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.name = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(date: any, id: number, name: string, userId: number): void {
    this.date = date;
    this.id = id;
    this.name = name;
    this.userId = userId;
  }
}

export class BadgeClientResponseModel {
  date: any;
  id: number;
  name: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.name = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(date: any, id: number, name: string, userId: number): void {
    this.date = date;
    this.id = id;
    this.name = name;
    this.userId = userId;
  }
}
export class CommentClientRequestModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  score: number;
  text: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.score = 0;
    this.text = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    postId: number,
    score: number,
    text: string,
    userId: number
  ): void {
    this.creationDate = creationDate;
    this.id = id;
    this.postId = postId;
    this.score = score;
    this.text = text;
    this.userId = userId;
  }
}

export class CommentClientResponseModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  score: number;
  text: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.score = 0;
    this.text = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    postId: number,
    score: number,
    text: string,
    userId: number
  ): void {
    this.creationDate = creationDate;
    this.id = id;
    this.postId = postId;
    this.score = score;
    this.text = text;
    this.userId = userId;
  }
}
export class LinkTypeClientRequestModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }
}

export class LinkTypeClientResponseModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }
}
export class PostHistoryClientRequestModel {
  comment: string;
  creationDate: any;
  id: number;
  postHistoryTypeId: number;
  postHistoryTypeIdEntity: string;
  postHistoryTypeIdNavigation?: PostHistoryTypeClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.comment = '';
    this.creationDate = undefined;
    this.id = 0;
    this.postHistoryTypeId = 0;
    this.postHistoryTypeIdEntity = '';
    this.postHistoryTypeIdNavigation = undefined;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.revisionGUID = '';
    this.text = '';
    this.userDisplayName = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    comment: string,
    creationDate: any,
    id: number,
    postHistoryTypeId: number,
    postId: number,
    revisionGUID: string,
    text: string,
    userDisplayName: string,
    userId: number
  ): void {
    this.comment = comment;
    this.creationDate = creationDate;
    this.id = id;
    this.postHistoryTypeId = postHistoryTypeId;
    this.postId = postId;
    this.revisionGUID = revisionGUID;
    this.text = text;
    this.userDisplayName = userDisplayName;
    this.userId = userId;
  }
}

export class PostHistoryClientResponseModel {
  comment: string;
  creationDate: any;
  id: number;
  postHistoryTypeId: number;
  postHistoryTypeIdEntity: string;
  postHistoryTypeIdNavigation?: PostHistoryTypeClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.comment = '';
    this.creationDate = undefined;
    this.id = 0;
    this.postHistoryTypeId = 0;
    this.postHistoryTypeIdEntity = '';
    this.postHistoryTypeIdNavigation = undefined;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.revisionGUID = '';
    this.text = '';
    this.userDisplayName = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    comment: string,
    creationDate: any,
    id: number,
    postHistoryTypeId: number,
    postId: number,
    revisionGUID: string,
    text: string,
    userDisplayName: string,
    userId: number
  ): void {
    this.comment = comment;
    this.creationDate = creationDate;
    this.id = id;
    this.postHistoryTypeId = postHistoryTypeId;
    this.postId = postId;
    this.revisionGUID = revisionGUID;
    this.text = text;
    this.userDisplayName = userDisplayName;
    this.userId = userId;
  }
}
export class PostHistoryTypeClientRequestModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }
}

export class PostHistoryTypeClientResponseModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }
}
export class PostLinkClientRequestModel {
  creationDate: any;
  id: number;
  linkTypeId: number;
  linkTypeIdEntity: string;
  linkTypeIdNavigation?: LinkTypeClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  relatedPostId: number;
  relatedPostIdEntity: string;
  relatedPostIdNavigation?: PostClientResponseModel;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.linkTypeId = 0;
    this.linkTypeIdEntity = '';
    this.linkTypeIdNavigation = undefined;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.relatedPostId = 0;
    this.relatedPostIdEntity = '';
    this.relatedPostIdNavigation = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    linkTypeId: number,
    postId: number,
    relatedPostId: number
  ): void {
    this.creationDate = creationDate;
    this.id = id;
    this.linkTypeId = linkTypeId;
    this.postId = postId;
    this.relatedPostId = relatedPostId;
  }
}

export class PostLinkClientResponseModel {
  creationDate: any;
  id: number;
  linkTypeId: number;
  linkTypeIdEntity: string;
  linkTypeIdNavigation?: LinkTypeClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  relatedPostId: number;
  relatedPostIdEntity: string;
  relatedPostIdNavigation?: PostClientResponseModel;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.linkTypeId = 0;
    this.linkTypeIdEntity = '';
    this.linkTypeIdNavigation = undefined;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.relatedPostId = 0;
    this.relatedPostIdEntity = '';
    this.relatedPostIdNavigation = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    linkTypeId: number,
    postId: number,
    relatedPostId: number
  ): void {
    this.creationDate = creationDate;
    this.id = id;
    this.linkTypeId = linkTypeId;
    this.postId = postId;
    this.relatedPostId = relatedPostId;
  }
}
export class PostClientRequestModel {
  acceptedAnswerId: number;
  answerCount: number;
  body: string;
  closedDate: any;
  commentCount: number;
  communityOwnedDate: any;
  creationDate: any;
  favoriteCount: number;
  id: number;
  lastActivityDate: any;
  lastEditDate: any;
  lastEditorDisplayName: string;
  lastEditorUserId: number;
  lastEditorUserIdEntity: string;
  lastEditorUserIdNavigation?: UserClientResponseModel;
  ownerUserId: number;
  ownerUserIdEntity: string;
  ownerUserIdNavigation?: UserClientResponseModel;
  parentId: number;
  parentIdEntity: string;
  parentIdNavigation?: PostClientResponseModel;
  postTypeId: number;
  postTypeIdEntity: string;
  postTypeIdNavigation?: PostTypeClientResponseModel;
  score: number;
  tag: string;
  title: string;
  viewCount: number;

  constructor() {
    this.acceptedAnswerId = 0;
    this.answerCount = 0;
    this.body = '';
    this.closedDate = undefined;
    this.commentCount = 0;
    this.communityOwnedDate = undefined;
    this.creationDate = undefined;
    this.favoriteCount = 0;
    this.id = 0;
    this.lastActivityDate = undefined;
    this.lastEditDate = undefined;
    this.lastEditorDisplayName = '';
    this.lastEditorUserId = 0;
    this.lastEditorUserIdEntity = '';
    this.lastEditorUserIdNavigation = undefined;
    this.ownerUserId = 0;
    this.ownerUserIdEntity = '';
    this.ownerUserIdNavigation = undefined;
    this.parentId = 0;
    this.parentIdEntity = '';
    this.parentIdNavigation = undefined;
    this.postTypeId = 0;
    this.postTypeIdEntity = '';
    this.postTypeIdNavigation = undefined;
    this.score = 0;
    this.tag = '';
    this.title = '';
    this.viewCount = 0;
  }

  setProperties(
    acceptedAnswerId: number,
    answerCount: number,
    body: string,
    closedDate: any,
    commentCount: number,
    communityOwnedDate: any,
    creationDate: any,
    favoriteCount: number,
    id: number,
    lastActivityDate: any,
    lastEditDate: any,
    lastEditorDisplayName: string,
    lastEditorUserId: number,
    ownerUserId: number,
    parentId: number,
    postTypeId: number,
    score: number,
    tag: string,
    title: string,
    viewCount: number
  ): void {
    this.acceptedAnswerId = acceptedAnswerId;
    this.answerCount = answerCount;
    this.body = body;
    this.closedDate = closedDate;
    this.commentCount = commentCount;
    this.communityOwnedDate = communityOwnedDate;
    this.creationDate = creationDate;
    this.favoriteCount = favoriteCount;
    this.id = id;
    this.lastActivityDate = lastActivityDate;
    this.lastEditDate = lastEditDate;
    this.lastEditorDisplayName = lastEditorDisplayName;
    this.lastEditorUserId = lastEditorUserId;
    this.ownerUserId = ownerUserId;
    this.parentId = parentId;
    this.postTypeId = postTypeId;
    this.score = score;
    this.tag = tag;
    this.title = title;
    this.viewCount = viewCount;
  }
}

export class PostClientResponseModel {
  acceptedAnswerId: number;
  answerCount: number;
  body: string;
  closedDate: any;
  commentCount: number;
  communityOwnedDate: any;
  creationDate: any;
  favoriteCount: number;
  id: number;
  lastActivityDate: any;
  lastEditDate: any;
  lastEditorDisplayName: string;
  lastEditorUserId: number;
  lastEditorUserIdEntity: string;
  lastEditorUserIdNavigation?: UserClientResponseModel;
  ownerUserId: number;
  ownerUserIdEntity: string;
  ownerUserIdNavigation?: UserClientResponseModel;
  parentId: number;
  parentIdEntity: string;
  parentIdNavigation?: PostClientResponseModel;
  postTypeId: number;
  postTypeIdEntity: string;
  postTypeIdNavigation?: PostTypeClientResponseModel;
  score: number;
  tag: string;
  title: string;
  viewCount: number;

  constructor() {
    this.acceptedAnswerId = 0;
    this.answerCount = 0;
    this.body = '';
    this.closedDate = undefined;
    this.commentCount = 0;
    this.communityOwnedDate = undefined;
    this.creationDate = undefined;
    this.favoriteCount = 0;
    this.id = 0;
    this.lastActivityDate = undefined;
    this.lastEditDate = undefined;
    this.lastEditorDisplayName = '';
    this.lastEditorUserId = 0;
    this.lastEditorUserIdEntity = '';
    this.lastEditorUserIdNavigation = undefined;
    this.ownerUserId = 0;
    this.ownerUserIdEntity = '';
    this.ownerUserIdNavigation = undefined;
    this.parentId = 0;
    this.parentIdEntity = '';
    this.parentIdNavigation = undefined;
    this.postTypeId = 0;
    this.postTypeIdEntity = '';
    this.postTypeIdNavigation = undefined;
    this.score = 0;
    this.tag = '';
    this.title = '';
    this.viewCount = 0;
  }

  setProperties(
    acceptedAnswerId: number,
    answerCount: number,
    body: string,
    closedDate: any,
    commentCount: number,
    communityOwnedDate: any,
    creationDate: any,
    favoriteCount: number,
    id: number,
    lastActivityDate: any,
    lastEditDate: any,
    lastEditorDisplayName: string,
    lastEditorUserId: number,
    ownerUserId: number,
    parentId: number,
    postTypeId: number,
    score: number,
    tag: string,
    title: string,
    viewCount: number
  ): void {
    this.acceptedAnswerId = acceptedAnswerId;
    this.answerCount = answerCount;
    this.body = body;
    this.closedDate = closedDate;
    this.commentCount = commentCount;
    this.communityOwnedDate = communityOwnedDate;
    this.creationDate = creationDate;
    this.favoriteCount = favoriteCount;
    this.id = id;
    this.lastActivityDate = lastActivityDate;
    this.lastEditDate = lastEditDate;
    this.lastEditorDisplayName = lastEditorDisplayName;
    this.lastEditorUserId = lastEditorUserId;
    this.ownerUserId = ownerUserId;
    this.parentId = parentId;
    this.postTypeId = postTypeId;
    this.score = score;
    this.tag = tag;
    this.title = title;
    this.viewCount = viewCount;
  }
}
export class PostTypeClientRequestModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }
}

export class PostTypeClientResponseModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }
}
export class TagClientRequestModel {
  count: number;
  excerptPostId: number;
  excerptPostIdEntity: string;
  excerptPostIdNavigation?: PostClientResponseModel;
  id: number;
  tagName: string;
  wikiPostId: number;
  wikiPostIdEntity: string;
  wikiPostIdNavigation?: PostClientResponseModel;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.excerptPostIdEntity = '';
    this.excerptPostIdNavigation = undefined;
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
    this.wikiPostIdEntity = '';
    this.wikiPostIdNavigation = undefined;
  }

  setProperties(
    count: number,
    excerptPostId: number,
    id: number,
    tagName: string,
    wikiPostId: number
  ): void {
    this.count = count;
    this.excerptPostId = excerptPostId;
    this.id = id;
    this.tagName = tagName;
    this.wikiPostId = wikiPostId;
  }
}

export class TagClientResponseModel {
  count: number;
  excerptPostId: number;
  excerptPostIdEntity: string;
  excerptPostIdNavigation?: PostClientResponseModel;
  id: number;
  tagName: string;
  wikiPostId: number;
  wikiPostIdEntity: string;
  wikiPostIdNavigation?: PostClientResponseModel;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.excerptPostIdEntity = '';
    this.excerptPostIdNavigation = undefined;
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
    this.wikiPostIdEntity = '';
    this.wikiPostIdNavigation = undefined;
  }

  setProperties(
    count: number,
    excerptPostId: number,
    id: number,
    tagName: string,
    wikiPostId: number
  ): void {
    this.count = count;
    this.excerptPostId = excerptPostId;
    this.id = id;
    this.tagName = tagName;
    this.wikiPostId = wikiPostId;
  }
}
export class UserClientRequestModel {
  aboutMe: string;
  accountId: number;
  age: number;
  creationDate: any;
  displayName: string;
  downVote: number;
  emailHash: string;
  id: number;
  lastAccessDate: any;
  location: string;
  reputation: number;
  upVote: number;
  view: number;
  websiteUrl: string;

  constructor() {
    this.aboutMe = '';
    this.accountId = 0;
    this.age = 0;
    this.creationDate = undefined;
    this.displayName = '';
    this.downVote = 0;
    this.emailHash = '';
    this.id = 0;
    this.lastAccessDate = undefined;
    this.location = '';
    this.reputation = 0;
    this.upVote = 0;
    this.view = 0;
    this.websiteUrl = '';
  }

  setProperties(
    aboutMe: string,
    accountId: number,
    age: number,
    creationDate: any,
    displayName: string,
    downVote: number,
    emailHash: string,
    id: number,
    lastAccessDate: any,
    location: string,
    reputation: number,
    upVote: number,
    view: number,
    websiteUrl: string
  ): void {
    this.aboutMe = aboutMe;
    this.accountId = accountId;
    this.age = age;
    this.creationDate = creationDate;
    this.displayName = displayName;
    this.downVote = downVote;
    this.emailHash = emailHash;
    this.id = id;
    this.lastAccessDate = lastAccessDate;
    this.location = location;
    this.reputation = reputation;
    this.upVote = upVote;
    this.view = view;
    this.websiteUrl = websiteUrl;
  }
}

export class UserClientResponseModel {
  aboutMe: string;
  accountId: number;
  age: number;
  creationDate: any;
  displayName: string;
  downVote: number;
  emailHash: string;
  id: number;
  lastAccessDate: any;
  location: string;
  reputation: number;
  upVote: number;
  view: number;
  websiteUrl: string;

  constructor() {
    this.aboutMe = '';
    this.accountId = 0;
    this.age = 0;
    this.creationDate = undefined;
    this.displayName = '';
    this.downVote = 0;
    this.emailHash = '';
    this.id = 0;
    this.lastAccessDate = undefined;
    this.location = '';
    this.reputation = 0;
    this.upVote = 0;
    this.view = 0;
    this.websiteUrl = '';
  }

  setProperties(
    aboutMe: string,
    accountId: number,
    age: number,
    creationDate: any,
    displayName: string,
    downVote: number,
    emailHash: string,
    id: number,
    lastAccessDate: any,
    location: string,
    reputation: number,
    upVote: number,
    view: number,
    websiteUrl: string
  ): void {
    this.aboutMe = aboutMe;
    this.accountId = accountId;
    this.age = age;
    this.creationDate = creationDate;
    this.displayName = displayName;
    this.downVote = downVote;
    this.emailHash = emailHash;
    this.id = id;
    this.lastAccessDate = lastAccessDate;
    this.location = location;
    this.reputation = reputation;
    this.upVote = upVote;
    this.view = view;
    this.websiteUrl = websiteUrl;
  }
}
export class VoteClientRequestModel {
  bountyAmount: number;
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;
  voteTypeId: number;
  voteTypeIdEntity: string;
  voteTypeIdNavigation?: VoteTypeClientResponseModel;

  constructor() {
    this.bountyAmount = 0;
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
    this.voteTypeId = 0;
    this.voteTypeIdEntity = '';
    this.voteTypeIdNavigation = undefined;
  }

  setProperties(
    bountyAmount: number,
    creationDate: any,
    id: number,
    postId: number,
    userId: number,
    voteTypeId: number
  ): void {
    this.bountyAmount = bountyAmount;
    this.creationDate = creationDate;
    this.id = id;
    this.postId = postId;
    this.userId = userId;
    this.voteTypeId = voteTypeId;
  }
}

export class VoteClientResponseModel {
  bountyAmount: number;
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostClientResponseModel;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;
  voteTypeId: number;
  voteTypeIdEntity: string;
  voteTypeIdNavigation?: VoteTypeClientResponseModel;

  constructor() {
    this.bountyAmount = 0;
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
    this.voteTypeId = 0;
    this.voteTypeIdEntity = '';
    this.voteTypeIdNavigation = undefined;
  }

  setProperties(
    bountyAmount: number,
    creationDate: any,
    id: number,
    postId: number,
    userId: number,
    voteTypeId: number
  ): void {
    this.bountyAmount = bountyAmount;
    this.creationDate = creationDate;
    this.id = id;
    this.postId = postId;
    this.userId = userId;
    this.voteTypeId = voteTypeId;
  }
}
export class VoteTypeClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class VoteTypeClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>e1db345907c96b0e0367b866245b01f4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/