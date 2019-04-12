import moment from 'moment';

export default class DeviceViewModel {
  dateOfLastPing: any;
  id: number;
  isActive: boolean;
  name: string;
  publicId: any;

  constructor() {
    this.dateOfLastPing = undefined;
    this.id = 0;
    this.isActive = false;
    this.name = '';
    this.publicId = undefined;
  }

  setProperties(
    dateOfLastPing: any,
    id: number,
    isActive: boolean,
    name: string,
    publicId: any
  ): void {
    this.dateOfLastPing = moment(dateOfLastPing, 'YYYY-MM-DD');
    this.id = id;
    this.isActive = isActive;
    this.name = name;
    this.publicId = publicId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>18e6bc7543fd9787f7ce397bbe620a57</Hash>
</Codenesium>*/