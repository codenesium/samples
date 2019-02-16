export default class TeacherSkillViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(
    id: number,
    isDeleted: boolean,
    name: string,
    tenantId: number
  ): void {
    this.id = id;
    this.isDeleted = isDeleted;
    this.name = name;
    this.tenantId = tenantId;
  }
}


/*<Codenesium>
    <Hash>80346f0eb79fc498280540e28628b1a6</Hash>
</Codenesium>*/