import moment from 'moment';
import ChainViewModel from '../chain/chainViewModel';

export default class ClaspViewModel {
  id: number;
  nextChainId: number;
  nextChainIdEntity: string;
  nextChainIdNavigation?: ChainViewModel;
  previousChainId: number;
  previousChainIdEntity: string;
  previousChainIdNavigation?: ChainViewModel;

  constructor() {
    this.id = 0;
    this.nextChainId = 0;
    this.nextChainIdEntity = '';
    this.nextChainIdNavigation = undefined;
    this.previousChainId = 0;
    this.previousChainIdEntity = '';
    this.previousChainIdNavigation = undefined;
  }

  setProperties(
    id: number,
    nextChainId: number,
    previousChainId: number
  ): void {
    this.id = id;
    this.nextChainId = nextChainId;
    this.previousChainId = previousChainId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>3d65df890d2a5fe585c38c9c2fc8deba</Hash>
</Codenesium>*/