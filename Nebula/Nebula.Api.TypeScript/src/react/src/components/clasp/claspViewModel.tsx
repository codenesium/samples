import moment from 'moment'
import ChainViewModel from '../chain/chainViewModel'
	

export default class ClaspViewModel {
    id:number;
nextChainId:number;
nextChainIdEntity : string;
nextChainIdNavigation? : ChainViewModel;
previousChainId:number;
previousChainIdEntity : string;
previousChainIdNavigation? : ChainViewModel;

    constructor() {
		this.id = 0;
this.nextChainId = 0;
this.nextChainIdEntity = '';
this.nextChainIdNavigation = new ChainViewModel();
this.previousChainId = 0;
this.previousChainIdEntity = '';
this.previousChainIdNavigation = new ChainViewModel();

    }

	setProperties(id : number,nextChainId : number,previousChainId : number) : void
	{
		this.id = id;
this.nextChainId = nextChainId;
this.previousChainId = previousChainId;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>33932d056de6ea40a7a41585b042083f</Hash>
</Codenesium>*/