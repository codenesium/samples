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
    this.dateOfLastPing = dateOfLastPing;
    this.id = id;
    this.isActive = isActive;
    this.name = name;
    this.publicId = publicId;
  }

  toDisplay(): string {
    return String(this.publicId);
  }
}


/*<Codenesium>
    <Hash>3d3c935bf787b8afcb111d475b317be2</Hash>
</Codenesium>*/