import moment from 'moment'
import LinkTypesViewModel from '../linkTypes/linkTypesViewModel'
	import PostsViewModel from '../posts/postsViewModel'
	

export default class PostLinksViewModel {
    creationDate:any;
id:number;
linkTypeId:number;
linkTypeIdEntity : string;
linkTypeIdNavigation? : LinkTypesViewModel;
postId:number;
postIdEntity : string;
postIdNavigation? : PostsViewModel;
relatedPostId:number;
relatedPostIdEntity : string;
relatedPostIdNavigation? : PostsViewModel;

    constructor() {
		this.creationDate = undefined;
this.id = 0;
this.linkTypeId = 0;
this.linkTypeIdEntity = '';
this.linkTypeIdNavigation = new LinkTypesViewModel();
this.postId = 0;
this.postIdEntity = '';
this.postIdNavigation = new PostsViewModel();
this.relatedPostId = 0;
this.relatedPostIdEntity = '';
this.relatedPostIdNavigation = new PostsViewModel();

    }

	setProperties(creationDate : any,id : number,linkTypeId : number,postId : number,relatedPostId : number) : void
	{
		this.creationDate = moment(creationDate,'YYYY-MM-DD');
this.id = id;
this.linkTypeId = linkTypeId;
this.postId = postId;
this.relatedPostId = relatedPostId;

	}

	toDisplay() : string
	{
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>73729a1a4313c9d62da13e16f81a0dc5</Hash>
</Codenesium>*/