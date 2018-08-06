export class ApiBadgesRequestModel {
				date:string;
id:number;
name:string;
userId:number;

	
				constructor() {
					this.date = '';
this.id = 0;
this.name = '';
this.userId = 0;

		
				}
			}

			export class ApiBadgesResponseModel {
				date:string;
id:number;
name:string;
userId:number;

	
				constructor() {
					this.date = '';
this.id = 0;
this.name = '';
this.userId = 0;

		
				}
			}
			export class ApiCommentsRequestModel {
				creationDate:string;
id:number;
postId:number;
score:number;
text:string;
userId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.postId = 0;
this.score = 0;
this.text = '';
this.userId = 0;

		
				}
			}

			export class ApiCommentsResponseModel {
				creationDate:string;
id:number;
postId:number;
score:number;
text:string;
userId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.postId = 0;
this.score = 0;
this.text = '';
this.userId = 0;

		
				}
			}
			export class ApiLinkTypesRequestModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}

			export class ApiLinkTypesResponseModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}
			export class ApiPostHistoryRequestModel {
				comment:string;
creationDate:string;
id:number;
postHistoryTypeId:number;
postId:number;
revisionGUID:string;
text:string;
userDisplayName:string;
userId:number;

	
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

			export class ApiPostHistoryResponseModel {
				comment:string;
creationDate:string;
id:number;
postHistoryTypeId:number;
postId:number;
revisionGUID:string;
text:string;
userDisplayName:string;
userId:number;

	
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
			export class ApiPostHistoryTypesRequestModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}

			export class ApiPostHistoryTypesResponseModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}
			export class ApiPostLinksRequestModel {
				creationDate:string;
id:number;
linkTypeId:number;
postId:number;
relatedPostId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.linkTypeId = 0;
this.postId = 0;
this.relatedPostId = 0;

		
				}
			}

			export class ApiPostLinksResponseModel {
				creationDate:string;
id:number;
linkTypeId:number;
postId:number;
relatedPostId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.linkTypeId = 0;
this.postId = 0;
this.relatedPostId = 0;

		
				}
			}
			export class ApiPostsRequestModel {
				acceptedAnswerId:number;
answerCount:number;
body:string;
closedDate:string;
commentCount:number;
communityOwnedDate:string;
creationDate:string;
favoriteCount:number;
id:number;
lastActivityDate:string;
lastEditDate:string;
lastEditorDisplayName:string;
lastEditorUserId:number;
ownerUserId:number;
parentId:number;
postTypeId:number;
score:number;
tags:string;
title:string;
viewCount:number;

	
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
this.tags = '';
this.title = '';
this.viewCount = 0;

		
				}
			}

			export class ApiPostsResponseModel {
				acceptedAnswerId:number;
answerCount:number;
body:string;
closedDate:string;
commentCount:number;
communityOwnedDate:string;
creationDate:string;
favoriteCount:number;
id:number;
lastActivityDate:string;
lastEditDate:string;
lastEditorDisplayName:string;
lastEditorUserId:number;
ownerUserId:number;
parentId:number;
postTypeId:number;
score:number;
tags:string;
title:string;
viewCount:number;

	
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
this.tags = '';
this.title = '';
this.viewCount = 0;

		
				}
			}
			export class ApiPostTypesRequestModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}

			export class ApiPostTypesResponseModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}
			export class ApiTagsRequestModel {
				count:number;
excerptPostId:number;
id:number;
tagName:string;
wikiPostId:number;

	
				constructor() {
					this.count = 0;
this.excerptPostId = 0;
this.id = 0;
this.tagName = '';
this.wikiPostId = 0;

		
				}
			}

			export class ApiTagsResponseModel {
				count:number;
excerptPostId:number;
id:number;
tagName:string;
wikiPostId:number;

	
				constructor() {
					this.count = 0;
this.excerptPostId = 0;
this.id = 0;
this.tagName = '';
this.wikiPostId = 0;

		
				}
			}
			export class ApiUsersRequestModel {
				aboutMe:string;
accountId:number;
age:number;
creationDate:string;
displayName:string;
downVotes:number;
emailHash:string;
id:number;
lastAccessDate:string;
location:string;
reputation:number;
upVotes:number;
views:number;
websiteUrl:string;

	
				constructor() {
					this.aboutMe = '';
this.accountId = 0;
this.age = 0;
this.creationDate = '';
this.displayName = '';
this.downVotes = 0;
this.emailHash = '';
this.id = 0;
this.lastAccessDate = '';
this.location = '';
this.reputation = 0;
this.upVotes = 0;
this.views = 0;
this.websiteUrl = '';

		
				}
			}

			export class ApiUsersResponseModel {
				aboutMe:string;
accountId:number;
age:number;
creationDate:string;
displayName:string;
downVotes:number;
emailHash:string;
id:number;
lastAccessDate:string;
location:string;
reputation:number;
upVotes:number;
views:number;
websiteUrl:string;

	
				constructor() {
					this.aboutMe = '';
this.accountId = 0;
this.age = 0;
this.creationDate = '';
this.displayName = '';
this.downVotes = 0;
this.emailHash = '';
this.id = 0;
this.lastAccessDate = '';
this.location = '';
this.reputation = 0;
this.upVotes = 0;
this.views = 0;
this.websiteUrl = '';

		
				}
			}
			export class ApiVotesRequestModel {
				bountyAmount:number;
creationDate:string;
id:number;
postId:number;
userId:number;
voteTypeId:number;

	
				constructor() {
					this.bountyAmount = 0;
this.creationDate = '';
this.id = 0;
this.postId = 0;
this.userId = 0;
this.voteTypeId = 0;

		
				}
			}

			export class ApiVotesResponseModel {
				bountyAmount:number;
creationDate:string;
id:number;
postId:number;
userId:number;
voteTypeId:number;

	
				constructor() {
					this.bountyAmount = 0;
this.creationDate = '';
this.id = 0;
this.postId = 0;
this.userId = 0;
this.voteTypeId = 0;

		
				}
			}
			export class ApiVoteTypesRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiVoteTypesResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}