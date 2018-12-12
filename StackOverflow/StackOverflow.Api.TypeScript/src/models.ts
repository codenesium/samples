export class ApiBadgeClientRequestModel {
	date : any;
	id : number;
	name : string;
	userId : number;

	constructor() {
		this.date = null;
		this.id = 0;
		this.name = '';
		this.userId = 0;
	}
}

export class ApiBadgeClientResponseModel {
	date : any;
	id : number;
	name : string;
	userId : number;

	constructor() {
		this.date = null;
		this.id = 0;
		this.name = '';
		this.userId = 0;
	}
}
export class ApiCommentClientRequestModel {
	creationDate : any;
	id : number;
	postId : number;
	score : any;
	text : string;
	userId : any;

	constructor() {
		this.creationDate = null;
		this.id = 0;
		this.postId = 0;
		this.score = null;
		this.text = '';
		this.userId = null;
	}
}

export class ApiCommentClientResponseModel {
	creationDate : any;
	id : number;
	postId : number;
	score : any;
	text : string;
	userId : any;

	constructor() {
		this.creationDate = null;
		this.id = 0;
		this.postId = 0;
		this.score = null;
		this.text = '';
		this.userId = null;
	}
}
export class ApiLinkTypeClientRequestModel {
	id : number;
	type : string;

	constructor() {
		this.id = 0;
		this.type = '';
	}
}

export class ApiLinkTypeClientResponseModel {
	id : number;
	type : string;

	constructor() {
		this.id = 0;
		this.type = '';
	}
}
export class ApiPostHistoryClientRequestModel {
	comment : string;
	creationDate : any;
	id : number;
	postHistoryTypeId : number;
	postId : number;
	revisionGUID : string;
	text : string;
	userDisplayName : string;
	userId : any;

	constructor() {
		this.comment = '';
		this.creationDate = null;
		this.id = 0;
		this.postHistoryTypeId = 0;
		this.postId = 0;
		this.revisionGUID = '';
		this.text = '';
		this.userDisplayName = '';
		this.userId = null;
	}
}

export class ApiPostHistoryClientResponseModel {
	comment : string;
	creationDate : any;
	id : number;
	postHistoryTypeId : number;
	postId : number;
	revisionGUID : string;
	text : string;
	userDisplayName : string;
	userId : any;

	constructor() {
		this.comment = '';
		this.creationDate = null;
		this.id = 0;
		this.postHistoryTypeId = 0;
		this.postId = 0;
		this.revisionGUID = '';
		this.text = '';
		this.userDisplayName = '';
		this.userId = null;
	}
}
export class ApiPostHistoryTypeClientRequestModel {
	id : number;
	type : string;

	constructor() {
		this.id = 0;
		this.type = '';
	}
}

export class ApiPostHistoryTypeClientResponseModel {
	id : number;
	type : string;

	constructor() {
		this.id = 0;
		this.type = '';
	}
}
export class ApiPostLinkClientRequestModel {
	creationDate : any;
	id : number;
	linkTypeId : number;
	postId : number;
	relatedPostId : number;

	constructor() {
		this.creationDate = null;
		this.id = 0;
		this.linkTypeId = 0;
		this.postId = 0;
		this.relatedPostId = 0;
	}
}

export class ApiPostLinkClientResponseModel {
	creationDate : any;
	id : number;
	linkTypeId : number;
	postId : number;
	relatedPostId : number;

	constructor() {
		this.creationDate = null;
		this.id = 0;
		this.linkTypeId = 0;
		this.postId = 0;
		this.relatedPostId = 0;
	}
}
export class ApiPostClientRequestModel {
	acceptedAnswerId : any;
	answerCount : any;
	body : string;
	closedDate : any;
	commentCount : any;
	communityOwnedDate : any;
	creationDate : any;
	favoriteCount : any;
	id : number;
	lastActivityDate : any;
	lastEditDate : any;
	lastEditorDisplayName : string;
	lastEditorUserId : any;
	ownerUserId : any;
	parentId : any;
	postTypeId : number;
	score : number;
	tag : string;
	title : string;
	viewCount : number;

	constructor() {
		this.acceptedAnswerId = null;
		this.answerCount = null;
		this.body = '';
		this.closedDate = null;
		this.commentCount = null;
		this.communityOwnedDate = null;
		this.creationDate = null;
		this.favoriteCount = null;
		this.id = 0;
		this.lastActivityDate = null;
		this.lastEditDate = null;
		this.lastEditorDisplayName = '';
		this.lastEditorUserId = null;
		this.ownerUserId = null;
		this.parentId = null;
		this.postTypeId = 0;
		this.score = 0;
		this.tag = '';
		this.title = '';
		this.viewCount = 0;
	}
}

export class ApiPostClientResponseModel {
	acceptedAnswerId : any;
	answerCount : any;
	body : string;
	closedDate : any;
	commentCount : any;
	communityOwnedDate : any;
	creationDate : any;
	favoriteCount : any;
	id : number;
	lastActivityDate : any;
	lastEditDate : any;
	lastEditorDisplayName : string;
	lastEditorUserId : any;
	ownerUserId : any;
	parentId : any;
	postTypeId : number;
	score : number;
	tag : string;
	title : string;
	viewCount : number;

	constructor() {
		this.acceptedAnswerId = null;
		this.answerCount = null;
		this.body = '';
		this.closedDate = null;
		this.commentCount = null;
		this.communityOwnedDate = null;
		this.creationDate = null;
		this.favoriteCount = null;
		this.id = 0;
		this.lastActivityDate = null;
		this.lastEditDate = null;
		this.lastEditorDisplayName = '';
		this.lastEditorUserId = null;
		this.ownerUserId = null;
		this.parentId = null;
		this.postTypeId = 0;
		this.score = 0;
		this.tag = '';
		this.title = '';
		this.viewCount = 0;
	}
}
export class ApiPostTypeClientRequestModel {
	id : number;
	type : string;

	constructor() {
		this.id = 0;
		this.type = '';
	}
}

export class ApiPostTypeClientResponseModel {
	id : number;
	type : string;

	constructor() {
		this.id = 0;
		this.type = '';
	}
}
export class ApiTagClientRequestModel {
	count : number;
	excerptPostId : number;
	id : number;
	tagName : string;
	wikiPostId : number;

	constructor() {
		this.count = 0;
		this.excerptPostId = 0;
		this.id = 0;
		this.tagName = '';
		this.wikiPostId = 0;
	}
}

export class ApiTagClientResponseModel {
	count : number;
	excerptPostId : number;
	id : number;
	tagName : string;
	wikiPostId : number;

	constructor() {
		this.count = 0;
		this.excerptPostId = 0;
		this.id = 0;
		this.tagName = '';
		this.wikiPostId = 0;
	}
}
export class ApiUserClientRequestModel {
	aboutMe : string;
	accountId : any;
	age : any;
	creationDate : any;
	displayName : string;
	downVote : number;
	emailHash : string;
	id : number;
	lastAccessDate : any;
	location : string;
	reputation : number;
	upVote : number;
	view : number;
	websiteUrl : string;

	constructor() {
		this.aboutMe = '';
		this.accountId = null;
		this.age = null;
		this.creationDate = null;
		this.displayName = '';
		this.downVote = 0;
		this.emailHash = '';
		this.id = 0;
		this.lastAccessDate = null;
		this.location = '';
		this.reputation = 0;
		this.upVote = 0;
		this.view = 0;
		this.websiteUrl = '';
	}
}

export class ApiUserClientResponseModel {
	aboutMe : string;
	accountId : any;
	age : any;
	creationDate : any;
	displayName : string;
	downVote : number;
	emailHash : string;
	id : number;
	lastAccessDate : any;
	location : string;
	reputation : number;
	upVote : number;
	view : number;
	websiteUrl : string;

	constructor() {
		this.aboutMe = '';
		this.accountId = null;
		this.age = null;
		this.creationDate = null;
		this.displayName = '';
		this.downVote = 0;
		this.emailHash = '';
		this.id = 0;
		this.lastAccessDate = null;
		this.location = '';
		this.reputation = 0;
		this.upVote = 0;
		this.view = 0;
		this.websiteUrl = '';
	}
}
export class ApiVoteClientRequestModel {
	bountyAmount : any;
	creationDate : any;
	id : number;
	postId : number;
	userId : any;
	voteTypeId : number;

	constructor() {
		this.bountyAmount = null;
		this.creationDate = null;
		this.id = 0;
		this.postId = 0;
		this.userId = null;
		this.voteTypeId = 0;
	}
}

export class ApiVoteClientResponseModel {
	bountyAmount : any;
	creationDate : any;
	id : number;
	postId : number;
	userId : any;
	voteTypeId : number;

	constructor() {
		this.bountyAmount = null;
		this.creationDate = null;
		this.id = 0;
		this.postId = 0;
		this.userId = null;
		this.voteTypeId = 0;
	}
}
export class ApiVoteTypeClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiVoteTypeClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

/*<Codenesium>
    <Hash>53d7efc970453b487926dd822000f702</Hash>
</Codenesium>*/