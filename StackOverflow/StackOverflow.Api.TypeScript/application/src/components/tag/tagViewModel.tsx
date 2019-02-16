export default class TagViewModel {
  count: number;
  excerptPostId: number;
  id: number;
  tagName: string;
  wikiPostId: number;

  constructor() {
    this.count = 0;
    this.excerptPostId = 0;
    this.id = 0;
    this.tagName = '';
    this.wikiPostId = 0;
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
    <Hash>96fab4bcd18d3fbe87ea62ebe25dad3b</Hash>
</Codenesium>*/