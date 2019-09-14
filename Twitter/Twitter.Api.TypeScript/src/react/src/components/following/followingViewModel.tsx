import moment from 'moment';

export default class FollowingViewModel {
  dateFollowed: any;
  muted: string;
  userId: number;

  constructor() {
    this.dateFollowed = undefined;
    this.muted = '';
    this.userId = 0;
  }

  setProperties(dateFollowed: any, muted: string, userId: number): void {
    this.dateFollowed = dateFollowed;
    this.muted = muted;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.userId);
  }
}


/*<Codenesium>
    <Hash>d24b7eb342d3b74fd0fbf6561b8fc250</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/