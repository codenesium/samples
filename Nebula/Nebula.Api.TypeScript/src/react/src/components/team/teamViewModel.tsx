import moment from 'moment';
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
    this.organizationIdNavigation = new OrganizationViewModel();
  }

  setProperties(id: number, name: string, organizationId: number): void {
    this.id = id;
    this.name = name;
    this.organizationId = organizationId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>3602caad57ca37c75e46b486bc21bf4f</Hash>
</Codenesium>*/