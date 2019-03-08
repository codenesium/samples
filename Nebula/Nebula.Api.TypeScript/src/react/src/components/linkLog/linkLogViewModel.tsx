import moment from 'moment';
import LinkViewModel from '../link/linkViewModel';

export default class LinkLogViewModel {
  dateEntered: any;
  id: number;
  linkId: number;
  linkIdEntity: string;
  linkIdNavigation?: LinkViewModel;
  log: string;

  constructor() {
    this.dateEntered = undefined;
    this.id = 0;
    this.linkId = 0;
    this.linkIdEntity = '';
    this.linkIdNavigation = new LinkViewModel();
    this.log = '';
  }

  setProperties(
    dateEntered: any,
    id: number,
    linkId: number,
    log: string
  ): void {
    this.dateEntered = moment(dateEntered, 'YYYY-MM-DD');
    this.id = id;
    this.linkId = linkId;
    this.log = log;
  }

  toDisplay(): string {
    return String(this.linkId);
  }
}


/*<Codenesium>
    <Hash>0fc9ffd7d6961bbf2b88614c642ebad1</Hash>
</Codenesium>*/