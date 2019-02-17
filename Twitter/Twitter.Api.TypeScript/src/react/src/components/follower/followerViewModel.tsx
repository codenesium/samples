import UserViewModel from '../user/userViewModel';
import UserViewModel from '../user/userViewModel';

export default class FollowerViewModel {
  blocked: string;
  dateFollowed: any;
  followRequestStatu: string;
  followedUserId: number;
  followedUserIdEntity: string;
  followedUserIdNavigation?: UserViewModel;
  followingUserId: number;
  followingUserIdEntity: string;
  followingUserIdNavigation?: UserViewModel;
  id: number;
  muted: string;

  constructor() {
    this.blocked = '';
    this.dateFollowed = undefined;
    this.followRequestStatu = '';
    this.followedUserId = 0;
    this.followedUserIdEntity = '';
    this.followedUserIdNavigation = undefined;
    this.followingUserId = 0;
    this.followingUserIdEntity = '';
    this.followingUserIdNavigation = undefined;
    this.id = 0;
    this.muted = '';
  }

  setProperties(
    blocked: string,
    dateFollowed: any,
    followRequestStatu: string,
    followedUserId: number,
    followingUserId: number,
    id: number,
    muted: string
  ): void {
    this.blocked = blocked;
    this.dateFollowed = dateFollowed;
    this.followRequestStatu = followRequestStatu;
    this.followedUserId = followedUserId;
    this.followingUserId = followingUserId;
    this.id = id;
    this.muted = muted;
  }

  toDisplay(): string {
    return String(NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>a6b8591d32bee080fab43bdc8f3b3dcd</Hash>
</Codenesium>*/