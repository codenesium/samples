import * as Api from '../../api/models';
import CallViewModel from  './callViewModel';
	import AddressViewModel from '../address/addressViewModel'
		import CallDispositionViewModel from '../callDisposition/callDispositionViewModel'
		import CallStatuViewModel from '../callStatu/callStatuViewModel'
		import CallTypeViewModel from '../callType/callTypeViewModel'
	export default class CallMapper {
    
	mapApiResponseToViewModel(dto: Api.CallClientResponseModel) : CallViewModel 
	{
		let response = new CallViewModel();
		response.setProperties(dto.addressId,dto.callDispositionId,dto.callStatusId,dto.callString,dto.callTypeId,dto.dateCleared,dto.dateCreated,dto.dateDispatched,dto.id,dto.quickCallNumber);
		
						if(dto.addressIdNavigation != null)
				{
				  response.addressIdNavigation = new AddressViewModel();
				  response.addressIdNavigation.setProperties(
				  dto.addressIdNavigation.address1,dto.addressIdNavigation.address2,dto.addressIdNavigation.city,dto.addressIdNavigation.id,dto.addressIdNavigation.state,dto.addressIdNavigation.zip
				  );
				}
							if(dto.callDispositionIdNavigation != null)
				{
				  response.callDispositionIdNavigation = new CallDispositionViewModel();
				  response.callDispositionIdNavigation.setProperties(
				  dto.callDispositionIdNavigation.id,dto.callDispositionIdNavigation.name
				  );
				}
							if(dto.callStatusIdNavigation != null)
				{
				  response.callStatusIdNavigation = new CallStatuViewModel();
				  response.callStatusIdNavigation.setProperties(
				  dto.callStatusIdNavigation.id,dto.callStatusIdNavigation.name
				  );
				}
							if(dto.callTypeIdNavigation != null)
				{
				  response.callTypeIdNavigation = new CallTypeViewModel();
				  response.callTypeIdNavigation.setProperties(
				  dto.callTypeIdNavigation.id,dto.callTypeIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CallViewModel) : Api.CallClientRequestModel
	{
		let response = new Api.CallClientRequestModel();
		response.setProperties(model.addressId,model.callDispositionId,model.callStatusId,model.callString,model.callTypeId,model.dateCleared,model.dateCreated,model.dateDispatched,model.id,model.quickCallNumber);
		return response;
	}
};

/*<Codenesium>
    <Hash>576d88c8a96ff15246ab32200a436308</Hash>
</Codenesium>*/