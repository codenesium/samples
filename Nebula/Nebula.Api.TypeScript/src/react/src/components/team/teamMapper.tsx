import * as Api from '../../api/models';
import TeamViewModel from  './teamViewModel';
	import OrganizationViewModel from '../organization/organizationViewModel'
	export default class TeamMapper {
    
	mapApiResponseToViewModel(dto: Api.TeamClientResponseModel) : TeamViewModel 
	{
		let response = new TeamViewModel();
		response.setProperties(dto.id,dto.name,dto.organizationId);
		
						if(dto.organizationIdNavigation != null)
				{
				  response.organizationIdNavigation = new OrganizationViewModel();
				  response.organizationIdNavigation.setProperties(
				  dto.organizationIdNavigation.id,dto.organizationIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TeamViewModel) : Api.TeamClientRequestModel
	{
		let response = new Api.TeamClientRequestModel();
		response.setProperties(model.id,model.name,model.organizationId);
		return response;
	}
};

/*<Codenesium>
    <Hash>7fad733fddf7693561e6c3486199b2db</Hash>
</Codenesium>*/