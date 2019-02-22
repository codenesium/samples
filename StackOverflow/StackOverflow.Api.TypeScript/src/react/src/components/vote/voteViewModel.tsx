import moment from 'moment';

export default class VoteViewModel {
  bountyAmount: any;
  creationDate: any;
  id: number;
  postId: number;
  userId: any;
  voteTypeId: number;

  constructor() {
    this.bountyAmount = undefined;
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.userId = undefined;
    this.voteTypeId = 0;
  }

  setProperties(
    bountyAmount: any,
    creationDate: any,
    id: number,
    postId: number,
    userId: any,
    voteTypeId: number
  ): void {
    this.bountyAmount = bountyAmount;
    this.creationDate = creationDate;
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
    <Hash>e6c248010091c6df3d5f1acefb035dd9</Hash>
</Codenesium>*/