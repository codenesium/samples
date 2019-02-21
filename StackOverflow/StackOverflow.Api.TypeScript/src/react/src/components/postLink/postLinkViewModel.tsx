import moment from 'moment';

export default class PostLinkViewModel {
  creationDate: any;
  id: number;
  linkTypeId: number;
  postId: number;
  relatedPostId: number;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.linkTypeId = 0;
    this.postId = 0;
    this.relatedPostId = 0;
  }

  setProperties(
    creationDate: any,
    id: number,
    linkTypeId: number,
    postId: number,
    relatedPostId: number
  ): void {
    this.creationDate = creationDate;
    this.id = id;
    this.linkTypeId = linkTypeId;
    this.postId = postId;
    this.relatedPostId = relatedPostId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>2022a30040f0b49c38ba005b6508545f</Hash>
</Codenesium>*/