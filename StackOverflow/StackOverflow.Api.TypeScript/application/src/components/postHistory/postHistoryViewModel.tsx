export default class PostHistoryViewModel {
  comment: string;
  creationDate: any;
  id: number;
  postHistoryTypeId: number;
  postId: number;
  revisionGUID: string;
  text: string;
  userDisplayName: string;
  userId: any;

  constructor() {
    this.comment = '';
    this.creationDate = undefined;
    this.id = 0;
    this.postHistoryTypeId = 0;
    this.postId = 0;
    this.revisionGUID = '';
    this.text = '';
    this.userDisplayName = '';
    this.userId = undefined;
  }

  setProperties(
    comment: string,
    creationDate: any,
    id: number,
    postHistoryTypeId: number,
    postId: number,
    revisionGUID: string,
    text: string,
    userDisplayName: string,
    userId: any
  ): void {
    this.comment = comment;
    this.creationDate = creationDate;
    this.id = id;
    this.postHistoryTypeId = postHistoryTypeId;
    this.postId = postId;
    this.revisionGUID = revisionGUID;
    this.text = text;
    this.userDisplayName = userDisplayName;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>27a4e0f643cb9afed558a0d1a35e1020</Hash>
</Codenesium>*/