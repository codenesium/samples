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
    return String(this.spaceFeatureId);
  }
}


/*<Codenesium>
    <Hash>80ba5c9224f629c135a6a9a6a085eeb9</Hash>
</Codenesium>*/