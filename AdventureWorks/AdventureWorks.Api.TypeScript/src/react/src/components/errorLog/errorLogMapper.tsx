import * as Api from '../../api/models';
import ErrorLogViewModel from  './errorLogViewModel';
export default class ErrorLogMapper {
    
	mapApiResponseToViewModel(dto: Api.ErrorLogClientResponseModel) : ErrorLogViewModel 
	{
		let response = new ErrorLogViewModel();
		response.setProperties(dto.errorLine,dto.errorLogID,dto.errorMessage,dto.errorNumber,dto.errorProcedure,dto.errorSeverity,dto.errorState,dto.errorTime,dto.userName);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ErrorLogViewModel) : Api.ErrorLogClientRequestModel
	{
		let response = new Api.ErrorLogClientRequestModel();
		response.setProperties(model.errorLine,model.errorLogID,model.errorMessage,model.errorNumber,model.errorProcedure,model.errorSeverity,model.errorState,model.errorTime,model.userName);
		return response;
	}
};

/*<Codenesium>
    <Hash>78dc9c4071bb5cffb16517b238ac66e1</Hash>
</Codenesium>*/