import moment from 'moment';
import PostViewModel from '../post/postViewModel';
import UserViewModel from '../user/userViewModel';

export default class CommentViewModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostViewModel;
  score: number;
  text: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserViewModel;

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
    this.creationDate = moment(creationDate, 'YYYY-MM-DD');
    this.id = id;
    this.postId = postId;
    this.score = score;
    this.text = text;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>ae7fc856ec08c799e3c16f1ecdaafc82</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/