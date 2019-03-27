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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>13d03e78c41293f40b8086c337c48ee2</Hash>
</Codenesium>*/