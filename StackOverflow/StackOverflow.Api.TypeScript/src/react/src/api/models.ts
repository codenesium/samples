export class BadgeClientRequestModel {
  date: any;
  id: number;
  name: string;
  userId: number;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.name = '';
    this.userId = 0;
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

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.name = '';
    this.userId = 0;
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
  score: any;
  text: string;
  userId: any;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.score = undefined;
    this.text = '';
    this.userId = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    postId: number,
    score: any,
    text: string,
    userId: any
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
  score: any;
  text: string;
  userId: any;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.score = undefined;
    this.text = '';
    this.userId = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    postId: number,
    score: any,
    text: string,
    userId: any
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
  postId: number;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: any;

  constructor() {
    this.comment = '';
    this.creationDate = undefined;
    this.id = 0;
    this.postHistoryTypeId = 0;
    this.postId = 0;
    this.revisionGUID = '';
    this.text = '';
    this.userDisplayName = '';
    this.userId = undefined;
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
    userId: any
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
  postId: number;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: any;

  constructor() {
    this.comment = '';
    this.creationDate = undefined;
    this.id = 0;
    this.postHistoryTypeId = 0;
    this.postId = 0;
    this.revisionGUID = '';
    this.text = '';
    this.userDisplayName = '';
    this.userId = undefined;
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
    userId: any
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
  postId: number;
  relatedPostId: number;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.linkTypeId = 0;
    this.postId = 0;
    this.relatedPostId = 0;
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
  postId: number;
  relatedPostId: number;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.linkTypeId = 0;
    this.postId = 0;
    this.relatedPostId = 0;
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
  acceptedAnswerId: any;
  answerCount: any;
  body: string;
  closedDate: any;
  commentCount: any;
  communityOwnedDate: any;
  creationDate: any;
  favoriteCount: any;
  id: number;
  lastActivityDate: any;
  lastEditDate: any;
  lastEditorDisplayName: string;
  lastEditorUserId: any;
  ownerUserId: any;
  parentId: any;
  postTypeId: number;
  score: number;
  tag: string;
  title: string;
  viewCount: number;

  constructor() {
    this.acceptedAnswerId = undefined;
    this.answerCount = undefined;
    this.body = '';
    this.closedDate = undefined;
    this.commentCount = undefined;
    this.communityOwnedDate = undefined;
    this.creationDate = undefined;
    this.favoriteCount = undefined;
    this.id = 0;
    this.lastActivityDate = undefined;
    this.lastEditDate = undefined;
    this.lastEditorDisplayName = '';
    this.lastEditorUserId = undefined;
    this.ownerUserId = undefined;
    this.parentId = undefined;
    this.postTypeId = 0;
    this.score = 0;
    this.tag = '';
    this.title = '';
    this.viewCount = 0;
  }

  setProperties(
    acceptedAnswerId: any,
    answerCount: any,
    body: string,
    closedDate: any,
    commentCount: any,
    communityOwnedDate: any,
    creationDate: any,
    favoriteCount: any,
    id: number,
    lastActivityDate: any,
    lastEditDate: any,
    lastEditorDisplayName: string,
    lastEditorUserId: any,
    ownerUserId: any,
    parentId: any,
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
  acceptedAnswerId: any;
  answerCount: any;
  body: string;
  closedDate: any;
  commentCount: any;
  communityOwnedDate: any;
  creationDate: any;
  favoriteCount: any;
  id: number;
  lastActivityDate: any;
  lastEditDate: any;
  lastEditorDisplayName: string;
  lastEditorUserId: any;
  ownerUserId: any;
  parentId: any;
  postTypeId: number;
  score: number;
  tag: string;
  title: string;
  viewCount: number;

  constructor() {
    this.acceptedAnswerId = undefined;
    this.answerCount = undefined;
    this.body = '';
    this.closedDate = undefined;
    this.commentCount = undefined;
    this.communityOwnedDate = undefined;
    this.creationDate = undefined;
    this.favoriteCount = undefined;
    this.id = 0;
    this.lastActivityDate = undefined;
    this.lastEditDate = undefined;
    this.lastEditorDisplayName = '';
    this.lastEditorUserId = undefined;
    this.ownerUserId = undefined;
    this.parentId = undefined;
    this.postTypeId = 0;
    this.score = 0;
    this.tag = '';
    this.title = '';
    this.viewCount = 0;
  }

  setProperties(
    acceptedAnswerId: any,
    answerCount: any,
    body: string,
    closedDate: any,
    commentCount: any,
    communityOwnedDate: any,
    creationDate: any,
    favoriteCount: any,
    id: number,
    lastActivityDate: any,
    lastEditDate: any,
    lastEditorDisplayName: string,
    lastEditorUserId: any,
    ownerUserId: any,
    parentId: any,
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
  id: number;
  tagName: string;
  wikiPostId: number;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
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
  id: number;
  tagName: string;
  wikiPostId: number;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
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
  accountId: any;
  age: any;
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
    this.accountId = undefined;
    this.age = undefined;
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
    accountId: any,
    age: any,
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
  accountId: any;
  age: any;
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
    this.accountId = undefined;
    this.age = undefined;
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
    accountId: any,
    age: any,
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
  bountyAmount: any;
  creationDate: any;
  id: number;
  postId: number;
  userId: any;
  voteTypeId: number;

  constructor() {
    this.bountyAmount = undefined;
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.userId = undefined;
    this.voteTypeId = 0;
  }

  setProperties(
    bountyAmount: any,
    creationDate: any,
    id: number,
    postId: number,
    userId: any,
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
  bountyAmount: any;
  creationDate: any;
  id: number;
  postId: number;
  userId: any;
  voteTypeId: number;

  constructor() {
    this.bountyAmount = undefined;
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.userId = undefined;
    this.voteTypeId = 0;
  }

  setProperties(
    bountyAmount: any,
    creationDate: any,
    id: number,
    postId: number,
    userId: any,
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
    <Hash>4f55976c218ba9d9e50fa4e41a443442</Hash>
</Codenesium>*/