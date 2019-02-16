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
    this.landDate = landDate;
    this.pipelineStepId = pipelineStepId;
    this.takeoffDate = takeoffDate;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>b3b4136265c81a288583b995a87943c1</Hash>
</Codenesium>*/