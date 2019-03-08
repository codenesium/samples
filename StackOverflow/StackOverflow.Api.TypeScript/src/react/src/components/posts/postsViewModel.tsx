import moment from 'moment';
import UsersViewModel from '../users/usersViewModel';
import PostTypesViewModel from '../postTypes/postTypesViewModel';

export default class PostsViewModel {
  acceptedAnswerId: any;
  answerCount: any;
  body: string;
  closedDate: any;
  commentCount: any;
  communityOwnedDate: any;
  creationDate: any;
  favoriteCount: any;
  id: number;
  lastActivityDate: any;
  lastEditDate: any;
  lastEditorDisplayName: string;
  lastEditorUserId: any;
  lastEditorUserIdEntity: string;
  lastEditorUserIdNavigation?: UsersViewModel;
  ownerUserId: any;
  ownerUserIdEntity: string;
  ownerUserIdNavigation?: UsersViewModel;
  parentId: any;
  parentIdEntity: string;
  parentIdNavigation?: PostsViewModel;
  postTypeId: number;
  postTypeIdEntity: string;
  postTypeIdNavigation?: PostTypesViewModel;
  score: number;
  tag: string;
  title: string;
  viewCount: number;

  constructor() {
    this.acceptedAnswerId = undefined;
    this.answerCount = undefined;
    this.body = '';
    this.closedDate = undefined;
    this.commentCount = undefined;
    this.communityOwnedDate = undefined;
    this.creationDate = undefined;
    this.favoriteCount = undefined;
    this.id = 0;
    this.lastActivityDate = undefined;
    this.lastEditDate = undefined;
    this.lastEditorDisplayName = '';
    this.lastEditorUserId = undefined;
    this.lastEditorUserIdEntity = '';
    this.lastEditorUserIdNavigation = new UsersViewModel();
    this.ownerUserId = undefined;
    this.ownerUserIdEntity = '';
    this.ownerUserIdNavigation = new UsersViewModel();
    this.parentId = undefined;
    this.parentIdEntity = '';
    this.parentIdNavigation = new PostsViewModel();
    this.postTypeId = 0;
    this.postTypeIdEntity = '';
    this.postTypeIdNavigation = new PostTypesViewModel();
    this.score = 0;
    this.tag = '';
    this.title = '';
    this.viewCount = 0;
  }

  setProperties(
    acceptedAnswerId: any,
    answerCount: any,
    body: string,
    closedDate: any,
    commentCount: any,
    communityOwnedDate: any,
    creationDate: any,
    favoriteCount: any,
    id: number,
    lastActivityDate: any,
    lastEditDate: any,
    lastEditorDisplayName: string,
    lastEditorUserId: any,
    ownerUserId: any,
    parentId: any,
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
    return String(this.title);
  }
}


/*<Codenesium>
    <Hash>c840be75a04b6012db9f1ce4d95a40d4</Hash>
</Codenesium>*/