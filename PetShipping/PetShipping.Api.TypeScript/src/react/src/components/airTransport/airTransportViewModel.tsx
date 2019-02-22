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
    this.handlerIdNavigation = new HandlerViewModel();
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
    this.airlineId = moment(airlineId, 'YYYY-MM-DD');
    this.flightNumber = moment(flightNumber, 'YYYY-MM-DD');
    this.handlerId = moment(handlerId, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.landDate = moment(landDate, 'YYYY-MM-DD');
    this.pipelineStepId = moment(pipelineStepId, 'YYYY-MM-DD');
    this.takeoffDate = moment(takeoffDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>498e43099f4bef4587b7e0a8d878a811</Hash>
</Codenesium>*/