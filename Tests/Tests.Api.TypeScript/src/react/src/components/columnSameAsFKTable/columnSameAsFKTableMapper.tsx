import * as Api from '../../api/models';
import ColumnSameAsFKTableViewModel from  './columnSameAsFKTableViewModel';
	import PersonViewModel from '../person/personViewModel'
	export default class ColumnSameAsFKTableMapper {
    
	mapApiResponseToViewModel(dto: Api.ColumnSameAsFKTableClientResponseModel) : ColumnSameAsFKTableViewModel 
	{
		let response = new ColumnSameAsFKTableViewModel();
		response.setProperties(dto.id,dto.person,dto.personId);
		
						if(dto.personNavigation != null)
				{
				  response.personNavigation = new PersonViewModel();
				  response.personNavigation.setProperties(
				  dto.personNavigation.personId,dto.personNavigation.personName
				  );
				}
							if(dto.personIdNavigation != null)
				{
				  response.personIdNavigation = new PersonViewModel();
				  response.personIdNavigation.setProperties(
				  dto.personIdNavigation.personId,dto.personIdNavigation.personName
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ColumnSameAsFKTableViewModel) : Api.ColumnSameAsFKTableClientRequestModel
	{
		let response = new Api.ColumnSameAsFKTableClientRequestModel();
		response.setProperties(model.id,model.person,model.personId);
		return response;
	}
};

/*<Codenesium>
    <Hash>aab3d8f56051e4f0df2efa422edb9d26</Hash>
</Codenesium>*/