import moment from 'moment';
import PostViewModel from '../post/postViewModel';
import UserViewModel from '../user/userViewModel';
import VoteTypeViewModel from '../voteType/voteTypeViewModel';

export default class VoteViewModel {
  bountyAmount: number;
  creationDate: any;
  id: number;
  postId: number;
  postIdEntity: string;
  postIdNavigation?: PostViewModel;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserViewModel;
  voteTypeId: number;
  voteTypeIdEntity: string;
  voteTypeIdNavigation?: VoteTypeViewModel;

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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>6517e27cb68c2359362f0c14b287d439</Hash>
</Codenesium>*/