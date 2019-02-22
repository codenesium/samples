import moment from 'moment';

export default class DeviceViewModel {
  id: number;
  name: string;
  publicId: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.publicId = undefined;
  }

  setProperties(id: number, name: string, publicId: any): void {
    this.id = id;
    this.name = name;
    this.publicId = publicId;
  }

  toDisplay(): string {
    return String(this.publicId);
  }
}


/*<Codenesium>
    <Hash>f5ec09eaa7c228dd7632d5782a67eb40</Hash>
</Codenesium>*/