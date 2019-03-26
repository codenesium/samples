import moment from 'moment';
import PostsViewModel from '../posts/postsViewModel';
import UsersViewModel from '../users/usersViewModel';
import VoteTypesViewModel from '../voteTypes/voteTypesViewModel';

export default class VotesViewModel {
  bountyAmount: number;
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostsViewModel;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UsersViewModel;
  voteTypeId: number;
  voteTypeIdEntity: string;
  voteTypeIdNavigation?: VoteTypesViewModel;

  constructor() {
    this.bountyAmount = 0;
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.postIdEntity = '';
    this.postIdNavigation = undefined;
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
    this.voteTypeId = 0;
    this.voteTypeIdEntity = '';
    this.voteTypeIdNavigation = undefined;
  }

  setProperties(
    bountyAmount: number,
    creationDate: any,
    id: number,
    postId: number,
    userId: number,
    voteTypeId: number
  ): void {
    this.bountyAmount = bountyAmount;
    this.creationDate = moment(creationDate, 'YYYY-MM-DD');
    this.id = id;
    this.postId = postId;
    this.userId = userId;
    this.voteTypeId = voteTypeId;
  }

  toDisplay(): string {
    return String(this.bountyAmount);
  }
}


/*<Codenesium>
    <Hash>3f39a56343d35a2f1037530210e6ec99</Hash>
</Codenesium>*/