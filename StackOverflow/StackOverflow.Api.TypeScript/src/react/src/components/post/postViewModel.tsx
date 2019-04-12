import moment from 'moment';
import UserViewModel from '../user/userViewModel';
import PostTypeViewModel from '../postType/postTypeViewModel';

export default class PostViewModel {
  acceptedAnswerId: number;
  answerCount: number;
  body: string;
  closedDate: any;
  commentCount: number;
  communityOwnedDate: any;
  creationDate: any;
  favoriteCount: number;
  id: number;
  lastActivityDate: any;
  lastEditDate: any;
  lastEditorDisplayName: string;
  lastEditorUserId: number;
  lastEditorUserIdEntity: string;
  lastEditorUserIdNavigation?: UserViewModel;
  ownerUserId: number;
  ownerUserIdEntity: string;
  ownerUserIdNavigation?: UserViewModel;
  parentId: number;
  parentIdEntity: string;
  parentIdNavigation?: PostViewModel;
  postTypeId: number;
  postTypeIdEntity: string;
  postTypeIdNavigation?: PostTypeViewModel;
  score: number;
  tag: string;
  title: string;
  viewCount: number;

  constructor() {
    this.acceptedAnswerId = 0;
    this.answerCount = 0;
    this.body = '';
    this.closedDate = undefined;
    this.commentCount = 0;
    this.communityOwnedDate = undefined;
    this.creationDate = undefined;
    this.favoriteCount = 0;
    this.id = 0;
    this.lastActivityDate = undefined;
    this.lastEditDate = undefined;
    this.lastEditorDisplayName = '';
    this.lastEditorUserId = 0;
    this.lastEditorUserIdEntity = '';
    this.lastEditorUserIdNavigation = undefined;
    this.ownerUserId = 0;
    this.ownerUserIdEntity = '';
    this.ownerUserIdNavigation = undefined;
    this.parentId = 0;
    this.parentIdEntity = '';
    this.parentIdNavigation = undefined;
    this.postTypeId = 0;
    this.postTypeIdEntity = '';
    this.postTypeIdNavigation = undefined;
    this.score = 0;
    this.tag = '';
    this.title = '';
    this.viewCount = 0;
  }

  setProperties(
    acceptedAnswerId: number,
    answerCount: number,
    body: string,
    closedDate: any,
    commentCount: number,
    communityOwnedDate: any,
    creationDate: any,
    favoriteCount: number,
    id: number,
    lastActivityDate: any,
    lastEditDate: any,
    lastEditorDisplayName: string,
    lastEditorUserId: number,
    ownerUserId: number,
    parentId: number,
    postTypeId: number,
    score: number,
    tag: string,
    title: string,
    viewCount: number
  ): void {
    this.acceptedAnswerId = acceptedAnswerId;
    this.answerCount = answerCount;
    this.body = body;
    this.closedDate = moment(closedDate, 'YYYY-MM-DD');
    this.commentCount = commentCount;
    this.communityOwnedDate = moment(communityOwnedDate, 'YYYY-MM-DD');
    this.creationDate = moment(creationDate, 'YYYY-MM-DD');
    this.favoriteCount = favoriteCount;
    this.id = id;
    this.lastActivityDate = moment(lastActivityDate, 'YYYY-MM-DD');
    this.lastEditDate = moment(lastEditDate, 'YYYY-MM-DD');
    this.lastEditorDisplayName = lastEditorDisplayName;
    this.lastEditorUserId = lastEditorUserId;
    this.ownerUserId = ownerUserId;
    this.parentId = parentId;
    this.postTypeId = postTypeId;
    this.score = score;
    this.tag = tag;
    this.title = title;
    this.viewCount = viewCount;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>7ef35eb45077a7d2fdeba5b2197de635</Hash>
</Codenesium>*/