import moment from 'moment';

export default class TeacherSkillViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>6b6a0590f2aaaab67ea10d25746c080b</Hash>
</Codenesium>*/