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
    return String();
  }
}


/*<Codenesium>
    <Hash>c8ec0abe39e36c9da5a74387c44efe4c</Hash>
</Codenesium>*/