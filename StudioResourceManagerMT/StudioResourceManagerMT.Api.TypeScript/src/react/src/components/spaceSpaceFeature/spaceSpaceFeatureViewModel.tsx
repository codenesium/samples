import moment from 'moment';
import SpaceFeatureViewModel from '../spaceFeature/spaceFeatureViewModel';
import SpaceViewModel from '../space/spaceViewModel';

export default class SpaceSpaceFeatureViewModel {
  spaceFeatureId: number;
  spaceFeatureIdEntity: string;
  spaceFeatureIdNavigation?: SpaceFeatureViewModel;
  spaceId: number;
  spaceIdEntity: string;
  spaceIdNavigation?: SpaceViewModel;

  constructor() {
    this.spaceFeatureId = 0;
    this.spaceFeatureIdEntity = '';
    this.spaceFeatureIdNavigation = undefined;
    this.spaceId = 0;
    this.spaceIdEntity = '';
    this.spaceIdNavigation = undefined;
  }

  setProperties(spaceFeatureId: number, spaceId: number): void {
    this.spaceFeatureId = spaceFeatureId;
    this.spaceId = spaceId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>2ae17706c46e20c4d09254875e8bba53</Hash>
</Codenesium>*/