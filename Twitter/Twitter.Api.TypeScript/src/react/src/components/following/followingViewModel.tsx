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
    return String(this.user_id);
  }
}


/*<Codenesium>
    <Hash>177d292df5aec36b756b44efd705d951</Hash>
</Codenesium>*/