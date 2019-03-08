import moment from 'moment';
import PostsViewModel from '../posts/postsViewModel';

export default class TagsViewModel {
  count: number;
  excerptPostId: number;
  excerptPostIdEntity: string;
  excerptPostIdNavigation?: PostsViewModel;
  id: number;
  tagName: string;
  wikiPostId: number;
  wikiPostIdEntity: string;
  wikiPostIdNavigation?: PostsViewModel;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.excerptPostIdEntity = '';
    this.excerptPostIdNavigation = new PostsViewModel();
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
    this.wikiPostIdEntity = '';
    this.wikiPostIdNavigation = new PostsViewModel();
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
    return String(this.tagName);
  }
}


/*<Codenesium>
    <Hash>92fad15c6b32624c047282d56327f201</Hash>
</Codenesium>*/