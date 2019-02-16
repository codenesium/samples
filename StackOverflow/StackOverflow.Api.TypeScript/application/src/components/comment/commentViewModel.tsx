export default class CommentViewModel {
  creationDate: any;
  id: number;
  postId: number;
  score: any;
  text: string;
  userId: any;

  constructor() {
    this.creationDate = undefined;
    this.id = 0;
    this.postId = 0;
    this.score = undefined;
    this.text = '';
    this.userId = undefined;
  }

  setProperties(
    creationDate: any,
    id: number,
    postId: number,
    score: any,
    text: string,
    userId: any
  ): void {
    this.creationDate = creationDate;
    this.id = id;
    this.postId = postId;
    this.score = score;
    this.text = text;
    this.userId = userId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>c28886187988cf2f3c3af7ab55845276</Hash>
</Codenesium>*/