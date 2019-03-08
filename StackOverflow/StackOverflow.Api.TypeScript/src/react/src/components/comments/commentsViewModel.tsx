import moment from 'moment';
import PostsViewModel from '../posts/postsViewModel';
import UsersViewModel from '../users/usersViewModel';

export default class CommentsViewModel {
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsViewModel;
  score: number;
  text: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersViewModel;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = new PostsViewModel();
    this.score = 0;
    this.text = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = new UsersViewModel();
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
    <Hash>88c937b22ce8d0a5cfaf2afccf2678c5</Hash>
</Codenesium>*/