import ChainViewModel from '../chain/chainViewModel';
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
    return String();
  }
}


/*<Codenesium>
    <Hash>8cb1832dfb10dc7e7d49352850d3a731</Hash>
</Codenesium>*/