export default class PostViewModel {
    acceptedAnswerId:any;
answerCount:any;
body:string;
closedDate:any;
commentCount:any;
communityOwnedDate:any;
creationDate:any;
favoriteCount:any;
id:number;
lastActivityDate:any;
lastEditDate:any;
lastEditorDisplayName:string;
lastEditorUserId:any;
ownerUserId:any;
parentId:any;
postTypeId:number;
score:number;
tag:string;
title:string;
viewCount:number;

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

	setProperties(acceptedAnswerId : any,answerCount : any,body : string,closedDate : any,commentCount : any,communityOwnedDate : any,creationDate : any,favoriteCount : any,id : number,lastActivityDate : any,lastEditDate : any,lastEditorDisplayName : string,lastEditorUserId : any,ownerUserId : any,parentId : any,postTypeId : number,score : number,tag : string,title : string,viewCount : number) : void
	{
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

	toDisplay() : string
	{
		return String(this.title);
	}
};

/*<Codenesium>
    <Hash>2bc9940246086c3840a3fc6ef03656be</Hash>
</Codenesium>*/