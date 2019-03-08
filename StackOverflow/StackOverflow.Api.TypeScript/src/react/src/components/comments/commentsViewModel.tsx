import moment from 'moment';
import PostsViewModel from '../posts/postsViewModel';
import UsersViewModel from '../users/usersViewModel';

export default class CommentsViewModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsViewModel;
  score: any;
  text: string;
  userId: any;
  userIdEntity: string;
  userIdNavigation?: UsersViewModel;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = new PostsViewModel();
    this.score = undefined;
    this.text = '';
    this.userId = undefined;
    this.userIdEntity = '';
    this.userIdNavigation = new UsersViewModel();
  }

  setProperties(
    creationDate: any,
    id: number,
    postId: number,
    score: any,
    text: string,
    userId: any
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
    <Hash>1904f38674beb0f8bb2d60d0cca2e4d9</Hash>
</Codenesium>*/