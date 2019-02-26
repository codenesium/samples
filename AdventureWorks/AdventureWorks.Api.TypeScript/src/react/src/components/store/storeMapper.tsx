import * as Api from '../../api/models';
import StoreViewModel from  './storeViewModel';
	import SalesPersonViewModel from '../salesPerson/salesPersonViewModel'
	export default class StoreMapper {
    
	mapApiResponseToViewModel(dto: Api.StoreClientResponseModel) : StoreViewModel 
	{
		let response = new StoreViewModel();
		response.setProperties(dto.businessEntityID,dto.demographic,dto.modifiedDate,dto.name,dto.rowguid,dto.salesPersonID);
		
						if(dto.salesPersonIDNavigation != null)
				{
				  response.salesPersonIDNavigation = new SalesPersonViewModel();
				  response.salesPersonIDNavigation.setProperties(
				  dto.salesPersonIDNavigation.bonus,dto.salesPersonIDNavigation.businessEntityID,dto.salesPersonIDNavigation.commissionPct,dto.salesPersonIDNavigation.modifiedDate,dto.salesPersonIDNavigation.rowguid,dto.salesPersonIDNavigation.salesLastYear,dto.salesPersonIDNavigation.salesQuota,dto.salesPersonIDNavigation.salesYTD,dto.salesPersonIDNavigation.territoryID
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: StoreViewModel) : Api.StoreClientRequestModel
	{
		let response = new Api.StoreClientRequestModel();
		response.setProperties(model.businessEntityID,model.demographic,model.modifiedDate,model.name,model.rowguid,model.salesPersonID);
		return response;
	}
};

/*<Codenesium>
    <Hash>7490a55e8c6943ac4ff680b44ce97e6b</Hash>
</Codenesium>*/