import moment from 'moment';
import PostHistoryTypeViewModel from '../postHistoryType/postHistoryTypeViewModel';
import PostViewModel from '../post/postViewModel';
import UserViewModel from '../user/userViewModel';

export default class PostHistoryViewModel {
  comment: string;
  creationDate: any;
  id: number;
  postHistoryTypeId: number;
  postHistoryTypeIdEntity: string;
  postHistoryTypeIdNavigation?: PostHistoryTypeViewModel;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostViewModel;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserViewModel;

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
    <Hash>527a84b586e0c8f057bf082b4ec36cd2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/