import * as Api from '../../api/models';
import LinkTypesViewModel from  './linkTypesViewModel';
export default class LinkTypesMapper {
    
	mapApiResponseToViewModel(dto: Api.LinkTypesClientResponseModel) : LinkTypesViewModel 
	{
		let response = new LinkTypesViewModel();
		response.setProperties(dto.id,dto.rwType);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: LinkTypesViewModel) : Api.LinkTypesClientRequestModel
	{
		let response = new Api.LinkTypesClientRequestModel();
		response.setProperties(model.id,model.rwType);
		return response;
	}
};

/*<Codenesium>
    <Hash>739a7dfd29aa59e501490c67349ef972</Hash>
</Codenesium>*/