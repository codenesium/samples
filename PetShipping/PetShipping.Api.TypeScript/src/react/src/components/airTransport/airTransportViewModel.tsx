import moment from 'moment';
import HandlerViewModel from '../handler/handlerViewModel';

export default class AirTransportViewModel {
  airlineId: number;
  flightNumber: string;
  handlerId: number;
  handlerIdEntity: string;
  handlerIdNavigation?: HandlerViewModel;
  id: number;
  landDate: any;
  pipelineStepId: number;
  takeoffDate: any;

  constructor() {
    this.airlineId = 0;
    this.flightNumber = '';
    this.handlerId = 0;
    this.handlerIdEntity = '';
    this.handlerIdNavigation = undefined;
    this.id = 0;
    this.landDate = undefined;
    this.pipelineStepId = 0;
    this.takeoffDate = undefined;
  }

  setProperties(
    airlineId: number,
    flightNumber: string,
    handlerId: number,
    id: number,
    landDate: any,
    pipelineStepId: number,
    takeoffDate: any
  ): void {
    this.airlineId = airlineId;
    this.flightNumber = flightNumber;
    this.handlerId = handlerId;
    this.id = id;
    this.landDate = moment(landDate, 'YYYY-MM-DD');
    this.pipelineStepId = pipelineStepId;
    this.takeoffDate = moment(takeoffDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String(this.airlineId);
  }
}


/*<Codenesium>
    <Hash>1b0fcab9d9e75687a3391111ee80002e</Hash>
</Codenesium>*/