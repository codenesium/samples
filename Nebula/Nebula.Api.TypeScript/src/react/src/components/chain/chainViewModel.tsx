import moment from 'moment';
import ChainStatusViewModel from '../chainStatus/chainStatusViewModel';
import TeamViewModel from '../team/teamViewModel';

export default class ChainViewModel {
  chainStatusId: number;
  chainStatusIdEntity: string;
  chainStatusIdNavigation?: ChainStatusViewModel;
  externalId: any;
  id: number;
  name: string;
  teamId: number;
  teamIdEntity: string;
  teamIdNavigation?: TeamViewModel;

  constructor() {
    this.chainStatusId = 0;
    this.chainStatusIdEntity = '';
    this.chainStatusIdNavigation = new ChainStatusViewModel();
    this.externalId = undefined;
    this.id = 0;
    this.name = '';
    this.teamId = 0;
    this.teamIdEntity = '';
    this.teamIdNavigation = new TeamViewModel();
  }

  setProperties(
    chainStatusId: number,
    externalId: any,
    id: number,
    name: string,
    teamId: number
  ): void {
    this.chainStatusId = chainStatusId;
    this.externalId = externalId;
    this.id = id;
    this.name = name;
    this.teamId = teamId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>d455cc8dfbb49558a2060e017a3a070c</Hash>
</Codenesium>*/