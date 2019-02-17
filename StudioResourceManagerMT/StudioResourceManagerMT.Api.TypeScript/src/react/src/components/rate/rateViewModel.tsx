export default class RateViewModel {
  amountPerMinute: number;
  id: number;
  teacherId: number;
  teacherSkillId: number;

  constructor() {
    this.amountPerMinute = 0;
    this.id = 0;
    this.teacherId = 0;
    this.teacherSkillId = 0;
  }

  setProperties(
    amountPerMinute: number,
    id: number,
    teacherId: number,
    teacherSkillId: number
  ): void {
    this.amountPerMinute = amountPerMinute;
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>3d0233b348faedbad62800f8d01aa5e3</Hash>
</Codenesium>*/