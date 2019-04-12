import moment from 'moment';
import PostViewModel from '../post/postViewModel';

export default class TagViewModel {
  count: number;
  excerptPostId: number;
  excerptPostIdEntity: string;
  excerptPostIdNavigation?: PostViewModel;
  id: number;
  tagName: string;
  wikiPostId: number;
  wikiPostIdEntity: string;
  wikiPostIdNavigation?: PostViewModel;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.excerptPostIdEntity = '';
    this.excerptPostIdNavigation = undefined;
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
    this.wikiPostIdEntity = '';
    this.wikiPostIdNavigation = undefined;
  }

  setProperties(
    count: number,
    excerptPostId: number,
    id: number,
    tagName: string,
    wikiPostId: number
  ): void {
    this.count = count;
    this.excerptPostId = excerptPostId;
    this.id = id;
    this.tagName = tagName;
    this.wikiPostId = wikiPostId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>069d6b327e54158f93f78d7e1cc24178</Hash>
</Codenesium>*/