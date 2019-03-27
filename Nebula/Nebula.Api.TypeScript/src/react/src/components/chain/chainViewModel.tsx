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
    this.chainStatusIdNavigation = undefined;
    this.externalId = undefined;
    this.id = 0;
    this.name = '';
    this.teamId = 0;
    this.teamIdEntity = '';
    this.teamIdNavigation = undefined;
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
    return String(this.externalId);
  }
}


/*<Codenesium>
    <Hash>d1f159cdd48fd3774f7f82e8f84b6d00</Hash>
</Codenesium>*/