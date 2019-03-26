import moment from 'moment';
import LinkTypeViewModel from '../linkType/linkTypeViewModel';
import PostViewModel from '../post/postViewModel';

export default class PostLinkViewModel {
  creationDate: any;
  id: number;
  linkTypeId: number;
  linkTypeIdEntity: string;
  linkTypeIdNavigation?: LinkTypeViewModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostViewModel;
  relatedPostId: number;
  relatedPostIdEntity: string;
  relatedPostIdNavigation?: PostViewModel;

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
    this.creationDate = moment(creationDate, 'YYYY-MM-DD');
    this.id = id;
    this.linkTypeId = linkTypeId;
    this.postId = postId;
    this.relatedPostId = relatedPostId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>918670877e7dfffe06d884e02b5f876b</Hash>
</Codenesium>*/