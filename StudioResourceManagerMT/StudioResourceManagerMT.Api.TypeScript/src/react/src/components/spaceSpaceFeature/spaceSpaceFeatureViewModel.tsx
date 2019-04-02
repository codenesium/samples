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
    return String();
  }
}


/*<Codenesium>
    <Hash>099e0211352db7c8661bed471f0a0600</Hash>
</Codenesium>*/