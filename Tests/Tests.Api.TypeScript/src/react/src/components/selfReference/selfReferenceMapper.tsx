import * as Api from '../../api/models';
import SelfReferenceViewModel from  './selfReferenceViewModel';
export default class SelfReferenceMapper {
    
	mapApiResponseToViewModel(dto: Api.SelfReferenceClientResponseModel) : SelfReferenceViewModel 
	{
		let response = new SelfReferenceViewModel();
		response.setProperties(dto.id,dto.selfReferenceId,dto.selfReferenceId2);
		
						if(dto.selfReferenceIdNavigation != null)
				{
				  response.selfReferenceIdNavigation = new SelfReferenceViewModel();
				  response.selfReferenceIdNavigation.setProperties(
				  dto.selfReferenceIdNavigation.id,dto.selfReferenceIdNavigation.selfReferenceId,dto.selfReferenceIdNavigation.selfReferenceId2
				  );
				}
							if(dto.selfReferenceId2Navigation != null)
				{
				  response.selfReferenceId2Navigation = new SelfReferenceViewModel();
				  response.selfReferenceId2Navigation.setProperties(
				  dto.selfReferenceId2Navigation.id,dto.selfReferenceId2Navigation.selfReferenceId,dto.selfReferenceId2Navigation.selfReferenceId2
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: SelfReferenceViewModel) : Api.SelfReferenceClientRequestModel
	{
		let response = new Api.SelfReferenceClientRequestModel();
		response.setProperties(model.id,model.selfReferenceId,model.selfReferenceId2);
		return response;
	}
};

/*<Codenesium>
    <Hash>0239743cae5bdcec8d2de20a2b448f5d</Hash>
</Codenesium>*/