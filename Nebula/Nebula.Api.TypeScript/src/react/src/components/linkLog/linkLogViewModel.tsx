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
    this.linkIdNavigation = undefined;
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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>fea07ab02d3d4971ab1b03b4fd7c6ee5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/