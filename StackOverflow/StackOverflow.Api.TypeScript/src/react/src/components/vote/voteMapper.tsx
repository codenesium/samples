import * as Api from '../../api/models';
import VoteViewModel from  './voteViewModel';
export default class VoteMapper {
    
	mapApiResponseToViewModel(dto: Api.VoteClientResponseModel) : VoteViewModel 
	{
		let response = new VoteViewModel();
		response.setProperties(dto.bountyAmount,dto.creationDate,dto.id,dto.postId,dto.userId,dto.voteTypeId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: VoteViewModel) : Api.VoteClientRequestModel
	{
		let response = new Api.VoteClientRequestModel();
		response.setProperties(model.bountyAmount,model.creationDate,model.id,model.postId,model.userId,model.voteTypeId);
		return response;
	}
};

/*<Codenesium>
    <Hash>b637b1f634e851acdc6b10220d1d270f</Hash>
</Codenesium>*/