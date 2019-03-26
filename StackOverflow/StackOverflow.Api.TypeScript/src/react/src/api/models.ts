export class BadgesClientRequestModel {
  date: any;
  id: number;
  name: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;

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

export class BadgesClientResponseModel {
  date: any;
  id: number;
  name: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;

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
export class CommentsClientRequestModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  score: number;
  text: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;

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

export class CommentsClientResponseModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  score: number;
  text: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;

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
export class LinkTypesClientRequestModel {
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

export class LinkTypesClientResponseModel {
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
  postHistoryTypeIdNavigation?: PostHistoryTypesClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;

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
  postHistoryTypeIdNavigation?: PostHistoryTypesClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;

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
export class PostHistoryTypesClientRequestModel {
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

export class PostHistoryTypesClientResponseModel {
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
export class PostLinksClientRequestModel {
  creationDate: any;
  id: number;
  linkTypeId: number;
  linkTypeIdEntity: string;
  linkTypeIdNavigation?: LinkTypesClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  relatedPostId: number;
  relatedPostIdEntity: string;
  relatedPostIdNavigation?: PostsClientResponseModel;

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

export class PostLinksClientResponseModel {
  creationDate: any;
  id: number;
  linkTypeId: number;
  linkTypeIdEntity: string;
  linkTypeIdNavigation?: LinkTypesClientResponseModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  relatedPostId: number;
  relatedPostIdEntity: string;
  relatedPostIdNavigation?: PostsClientResponseModel;

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
export class PostsClientRequestModel {
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
  lastEditorUserIdNavigation?: UsersClientResponseModel;
  ownerUserId: number;
  ownerUserIdEntity: string;
  ownerUserIdNavigation?: UsersClientResponseModel;
  parentId: number;
  parentIdEntity: string;
  parentIdNavigation?: PostsClientResponseModel;
  postTypeId: number;
  postTypeIdEntity: string;
  postTypeIdNavigation?: PostTypesClientResponseModel;
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

export class PostsClientResponseModel {
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
  lastEditorUserIdNavigation?: UsersClientResponseModel;
  ownerUserId: number;
  ownerUserIdEntity: string;
  ownerUserIdNavigation?: UsersClientResponseModel;
  parentId: number;
  parentIdEntity: string;
  parentIdNavigation?: PostsClientResponseModel;
  postTypeId: number;
  postTypeIdEntity: string;
  postTypeIdNavigation?: PostTypesClientResponseModel;
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
export class PostTypesClientRequestModel {
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

export class PostTypesClientResponseModel {
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
export class TagsClientRequestModel {
  count: number;
  excerptPostId: number;
  excerptPostIdEntity: string;
  excerptPostIdNavigation?: PostsClientResponseModel;
  id: number;
  tagName: string;
  wikiPostId: number;
  wikiPostIdEntity: string;
  wikiPostIdNavigation?: PostsClientResponseModel;

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

export class TagsClientResponseModel {
  count: number;
  excerptPostId: number;
  excerptPostIdEntity: string;
  excerptPostIdNavigation?: PostsClientResponseModel;
  id: number;
  tagName: string;
  wikiPostId: number;
  wikiPostIdEntity: string;
  wikiPostIdNavigation?: PostsClientResponseModel;

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
export class UsersClientRequestModel {
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

export class UsersClientResponseModel {
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
export class VotesClientRequestModel {
  bountyAmount: number;
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;
  voteTypeId: number;
  voteTypeIdEntity: string;
  voteTypeIdNavigation?: VoteTypesClientResponseModel;

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

export class VotesClientResponseModel {
  bountyAmount: number;
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsClientResponseModel;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersClientResponseModel;
  voteTypeId: number;
  voteTypeIdEntity: string;
  voteTypeIdNavigation?: VoteTypesClientResponseModel;

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
export class VoteTypesClientRequestModel {
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

export class VoteTypesClientResponseModel {
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
    <Hash>3c232a819bfcc61f26243fc3948dfd5c</Hash>
</Codenesium>*/