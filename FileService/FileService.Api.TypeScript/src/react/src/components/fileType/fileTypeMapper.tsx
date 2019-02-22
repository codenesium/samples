import * as Api from '../../api/models';
import FileTypeViewModel from  './fileTypeViewModel';
export default class FileTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.FileTypeClientResponseModel) : FileTypeViewModel 
	{
		let response = new FileTypeViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: FileTypeViewModel) : Api.FileTypeClientRequestModel
	{
		let response = new Api.FileTypeClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>a3ddaf84e457c60f356cd8b5fe08f724</Hash>
</Codenesium>*/