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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>ac8048bdc85b217653c1d9e28dca061f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/