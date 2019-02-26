import * as Api from '../../api/models';
import CallAssignmentViewModel from  './callAssignmentViewModel';
	import CallViewModel from '../call/callViewModel'
		import UnitViewModel from '../unit/unitViewModel'
	export default class CallAssignmentMapper {
    
	mapApiResponseToViewModel(dto: Api.CallAssignmentClientResponseModel) : CallAssignmentViewModel 
	{
		let response = new CallAssignmentViewModel();
		response.setProperties(dto.callId,dto.id,dto.unitId);
		
						if(dto.callIdNavigation != null)
				{
				  response.callIdNavigation = new CallViewModel();
				  response.callIdNavigation.setProperties(
				  dto.callIdNavigation.addressId,dto.callIdNavigation.callDispositionId,dto.callIdNavigation.callStatusId,dto.callIdNavigation.callString,dto.callIdNavigation.callTypeId,dto.callIdNavigation.dateCleared,dto.callIdNavigation.dateCreated,dto.callIdNavigation.dateDispatched,dto.callIdNavigation.id,dto.callIdNavigation.quickCallNumber
				  );
				}
							if(dto.unitIdNavigation != null)
				{
				  response.unitIdNavigation = new UnitViewModel();
				  response.unitIdNavigation.setProperties(
				  dto.unitIdNavigation.callSign,dto.unitIdNavigation.id
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CallAssignmentViewModel) : Api.CallAssignmentClientRequestModel
	{
		let response = new Api.CallAssignmentClientRequestModel();
		response.setProperties(model.callId,model.id,model.unitId);
		return response;
	}
};

/*<Codenesium>
    <Hash>7260050b567328294ce8bd50339aa988</Hash>
</Codenesium>*/