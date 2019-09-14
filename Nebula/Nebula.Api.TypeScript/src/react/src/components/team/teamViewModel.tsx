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
    this.organizationIdNavigation = undefined;
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
    <Hash>59631bcf752155dac4c6dec6b54b890f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/