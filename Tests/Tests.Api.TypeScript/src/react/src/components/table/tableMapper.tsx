import * as Api from '../../api/models';
import TableViewModel from  './tableViewModel';
export default class TableMapper {
    
	mapApiResponseToViewModel(dto: Api.TableClientResponseModel) : TableViewModel 
	{
		let response = new TableViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TableViewModel) : Api.TableClientRequestModel
	{
		let response = new Api.TableClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>21f12371ec67a42152e07a63d2830693</Hash>
</Codenesium>*/