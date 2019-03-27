import moment from 'moment';

export default class VideoViewModel {
  description: string;
  id: number;
  title: string;
  url: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.title = '';
    this.url = '';
  }

  setProperties(
    description: string,
    id: number,
    title: string,
    url: string
  ): void {
    this.description = description;
    this.id = id;
    this.title = title;
    this.url = url;
  }

  toDisplay(): string {
    return String(this.title);
  }
}


/*<Codenesium>
    <Hash>878ae2dcea64a553cddff3d92e3b65c9</Hash>
</Codenesium>*/