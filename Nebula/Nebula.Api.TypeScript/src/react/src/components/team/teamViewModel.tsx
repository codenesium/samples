import OrganizationViewModel from '../organization/organizationViewModel';

export default class TeamViewModel {
  id: number;
  name: string;
  organizationId: number;
  organizationIdEntity: string;
  organizationIdNavigation?: OrganizationViewModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.organizationId = 0;
    this.organizationIdEntity = '';
    this.organizationIdNavigation = undefined;
  }

  setProperties(id: number, name: string, organizationId: number): void {
    this.id = id;
    this.name = name;
    this.organizationId = organizationId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>190723d4fc3b8ef6cfd6ea1e3340f6c3</Hash>
</Codenesium>*/