import moment from 'moment';
import MachineViewModel from '../machine/machineViewModel';
import TeamViewModel from '../team/teamViewModel';

export default class MachineRefTeamViewModel {
  id: number;
  machineId: number;
  machineIdEntity: string;
  machineIdNavigation?: MachineViewModel;
  teamId: number;
  teamIdEntity: string;
  teamIdNavigation?: TeamViewModel;

  constructor() {
    this.id = 0;
    this.machineId = 0;
    this.machineIdEntity = '';
    this.machineIdNavigation = undefined;
    this.teamId = 0;
    this.teamIdEntity = '';
    this.teamIdNavigation = undefined;
  }

  setProperties(id: number, machineId: number, teamId: number): void {
    this.id = id;
    this.machineId = machineId;
    this.teamId = teamId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>7140091323af008246ed19e7ed17179e</Hash>
</Codenesium>*/