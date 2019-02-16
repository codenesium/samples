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
    <Hash>f62265379dc8e84cc7c41daddc5f69a4</Hash>
</Codenesium>*/