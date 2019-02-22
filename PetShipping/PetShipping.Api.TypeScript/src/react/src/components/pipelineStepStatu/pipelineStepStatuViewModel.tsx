import moment from 'moment';

export default class PipelineStepStatuViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>79ecc3d987f7d34dbd8360fafdba9210</Hash>
</Codenesium>*/