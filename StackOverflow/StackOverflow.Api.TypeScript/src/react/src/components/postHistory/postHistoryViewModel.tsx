import moment from 'moment';
import PostHistoryTypesViewModel from '../postHistoryTypes/postHistoryTypesViewModel';
import PostsViewModel from '../posts/postsViewModel';
import UsersViewModel from '../users/usersViewModel';

export default class PostHistoryViewModel {
  comment: string;
  creationDate: any;
  id: number;
  postHistoryTypeId: number;
  postHistoryTypeIdEntity: string;
  postHistoryTypeIdNavigation?: PostHistoryTypesViewModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsViewModel;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersViewModel;

  constructor() {
    this.comment = '';
    this.creationDate = undefined;
    this.id = 0;
    this.postHistoryTypeId = 0;
    this.postHistoryTypeIdEntity = '';
    this.postHistoryTypeIdNavigation = new PostHistoryTypesViewModel();
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = new PostsViewModel();
    this.revisionGUID = '';
    this.text = '';
    this.userDisplayName = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = new UsersViewModel();
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
    this.creationDate = moment(creationDate, 'YYYY-MM-DD');
    this.id = id;
    this.postHistoryTypeId = postHistoryTypeId;
    this.postId = postId;
    this.revisionGUID = revisionGUID;
    this.text = text;
    this.userDisplayName = userDisplayName;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>2ccc0608fbe3a777b80d89a1b045d658</Hash>
</Codenesium>*/