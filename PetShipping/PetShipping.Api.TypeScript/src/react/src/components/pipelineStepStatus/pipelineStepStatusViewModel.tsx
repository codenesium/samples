import moment from 'moment';

export default class PipelineStepStatusViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>20ad70562111cbd7d14624eaab1ffbb5</Hash>
</Codenesium>*/