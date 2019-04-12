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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>7ff92410a6d9cb74e3d76d98167b5164</Hash>
</Codenesium>*/