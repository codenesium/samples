import moment from 'moment';
import SpaceFeatureViewModel from '../spaceFeature/spaceFeatureViewModel';
import SpaceViewModel from '../space/spaceViewModel';

export default class SpaceSpaceFeatureViewModel {
  id: number;
  spaceFeatureId: number;
  spaceFeatureIdEntity: string;
  spaceFeatureIdNavigation?: SpaceFeatureViewModel;
  spaceId: number;
  spaceIdEntity: string;
  spaceIdNavigation?: SpaceViewModel;

  constructor() {
    this.id = 0;
    this.spaceFeatureId = 0;
    this.spaceFeatureIdEntity = '';
    this.spaceFeatureIdNavigation = undefined;
    this.spaceId = 0;
    this.spaceIdEntity = '';
    this.spaceIdNavigation = undefined;
  }

  setProperties(id: number, spaceFeatureId: number, spaceId: number): void {
    this.id = id;
    this.spaceFeatureId = spaceFeatureId;
    this.spaceId = spaceId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>e84e9187fe85be155c77f9317f727082</Hash>
</Codenesium>*/