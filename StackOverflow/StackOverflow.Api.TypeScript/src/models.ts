export class ApiBadgeClientRequestModel {
	date : string;
	id : number;
	name : string;
	userId : number;

	constructor() {
		this.date = '';
		this.id = 0;
		this.name = '';
		this.userId = 0;
	}
}

export class ApiBadgeClientResponseModel {
	date : string;
	id : number;
	name : string;
	userId : number;

	constructor() {
		this.date = '';
		this.id = 0;
		this.name = '';
		this.userId = 0;
	}
}
export class ApiCommentClientRequestModel {
	creationDate : string;
	id : number;
	postId : number;
	score : number;
	text : string;
	userId : number;

	constructor() {
		this.creationDate = '';
		this.id = 0;
		this.postId = 0;
		this.score = 0;
		this.text = '';
		this.userId = 0;
	}
}

export class ApiCommentClientResponseModel {
	creationDate : string;
	id : number;
	postId : number;
	score : number;
	text : string;
	userId : number;

	constructor() {
		this.creationDate = '';
		this.id = 0;
		this.postId = 0;
		this.score = 0;
		this.text = '';
		this.userId = 0;
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
	creationDate : string;
	id : number;
	postHistoryTypeId : number;
	postId : number;
	revisionGUID : string;
	text : string;
	userDisplayName : string;
	userId : number;

	constructor() {
		this.comment = '';
		this.creationDate = '';
		this.id = 0;
		this.postHistoryTypeId = 0;
		this.postId = 0;
		this.revisionGUID = '';
		this.text = '';
		this.userDisplayName = '';
		this.userId = 0;
	}
}

export class ApiPostHistoryClientResponseModel {
	comment : string;
	creationDate : string;
	id : number;
	postHistoryTypeId : number;
	postId : number;
	revisionGUID : string;
	text : string;
	userDisplayName : string;
	userId : number;

	constructor() {
		this.comment = '';
		this.creationDate = '';
		this.id = 0;
		this.postHistoryTypeId = 0;
		this.postId = 0;
		this.revisionGUID = '';
		this.text = '';
		this.userDisplayName = '';
		this.userId = 0;
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
	creationDate : string;
	id : number;
	linkTypeId : number;
	postId : number;
	relatedPostId : number;

	constructor() {
		this.creationDate = '';
		this.id = 0;
		this.linkTypeId = 0;
		this.postId = 0;
		this.relatedPostId = 0;
	}
}

export class ApiPostLinkClientResponseModel {
	creationDate : string;
	id : number;
	linkTypeId : number;
	postId : number;
	relatedPostId : number;

	constructor() {
		this.creationDate = '';
		this.id = 0;
		this.linkTypeId = 0;
		this.postId = 0;
		this.relatedPostId = 0;
	}
}
export class ApiPostClientRequestModel {
	acceptedAnswerId : number;
	answerCount : number;
	body : string;
	closedDate : string;
	commentCount : number;
	communityOwnedDate : string;
	creationDate : string;
	favoriteCount : number;
	id : number;
	lastActivityDate : string;
	lastEditDate : string;
	lastEditorDisplayName : string;
	lastEditorUserId : number;
	ownerUserId : number;
	parentId : number;
	postTypeId : number;
	score : number;
	tag : string;
	title : string;
	viewCount : number;

	constructor() {
		this.acceptedAnswerId = 0;
		this.answerCount = 0;
		this.body = '';
		this.closedDate = '';
		this.commentCount = 0;
		this.communityOwnedDate = '';
		this.creationDate = '';
		this.favoriteCount = 0;
		this.id = 0;
		this.lastActivityDate = '';
		this.lastEditDate = '';
		this.lastEditorDisplayName = '';
		this.lastEditorUserId = 0;
		this.ownerUserId = 0;
		this.parentId = 0;
		this.postTypeId = 0;
		this.score = 0;
		this.tag = '';
		this.title = '';
		this.viewCount = 0;
	}
}

export class ApiPostClientResponseModel {
	acceptedAnswerId : number;
	answerCount : number;
	body : string;
	closedDate : string;
	commentCount : number;
	communityOwnedDate : string;
	creationDate : string;
	favoriteCount : number;
	id : number;
	lastActivityDate : string;
	lastEditDate : string;
	lastEditorDisplayName : string;
	lastEditorUserId : number;
	ownerUserId : number;
	parentId : number;
	postTypeId : number;
	score : number;
	tag : string;
	title : string;
	viewCount : number;

	constructor() {
		this.acceptedAnswerId = 0;
		this.answerCount = 0;
		this.body = '';
		this.closedDate = '';
		this.commentCount = 0;
		this.communityOwnedDate = '';
		this.creationDate = '';
		this.favoriteCount = 0;
		this.id = 0;
		this.lastActivityDate = '';
		this.lastEditDate = '';
		this.lastEditorDisplayName = '';
		this.lastEditorUserId = 0;
		this.ownerUserId = 0;
		this.parentId = 0;
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
	accountId : number;
	age : number;
	creationDate : string;
	displayName : string;
	downVote : number;
	emailHash : string;
	id : number;
	lastAccessDate : string;
	location : string;
	reputation : number;
	upVote : number;
	view : number;
	websiteUrl : string;

	constructor() {
		this.aboutMe = '';
		this.accountId = 0;
		this.age = 0;
		this.creationDate = '';
		this.displayName = '';
		this.downVote = 0;
		this.emailHash = '';
		this.id = 0;
		this.lastAccessDate = '';
		this.location = '';
		this.reputation = 0;
		this.upVote = 0;
		this.view = 0;
		this.websiteUrl = '';
	}
}

export class ApiUserClientResponseModel {
	aboutMe : string;
	accountId : number;
	age : number;
	creationDate : string;
	displayName : string;
	downVote : number;
	emailHash : string;
	id : number;
	lastAccessDate : string;
	location : string;
	reputation : number;
	upVote : number;
	view : number;
	websiteUrl : string;

	constructor() {
		this.aboutMe = '';
		this.accountId = 0;
		this.age = 0;
		this.creationDate = '';
		this.displayName = '';
		this.downVote = 0;
		this.emailHash = '';
		this.id = 0;
		this.lastAccessDate = '';
		this.location = '';
		this.reputation = 0;
		this.upVote = 0;
		this.view = 0;
		this.websiteUrl = '';
	}
}
export class ApiVoteClientRequestModel {
	bountyAmount : number;
	creationDate : string;
	id : number;
	postId : number;
	userId : number;
	voteTypeId : number;

	constructor() {
		this.bountyAmount = 0;
		this.creationDate = '';
		this.id = 0;
		this.postId = 0;
		this.userId = 0;
		this.voteTypeId = 0;
	}
}

export class ApiVoteClientResponseModel {
	bountyAmount : number;
	creationDate : string;
	id : number;
	postId : number;
	userId : number;
	voteTypeId : number;

	constructor() {
		this.bountyAmount = 0;
		this.creationDate = '';
		this.id = 0;
		this.postId = 0;
		this.userId = 0;
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
    <Hash>9cd466894201e5a18eee043f08b521f4</Hash>
</Codenesium>*/