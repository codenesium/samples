import * as Api from '../../api/models';
import TeacherViewModel from  './teacherViewModel';
export default class TeacherMapper {
    
	mapApiResponseToViewModel(dto: Api.TeacherClientResponseModel) : TeacherViewModel 
	{
		let response = new TeacherViewModel();
		response.setProperties(dto.birthday,dto.email,dto.firstName,dto.id,dto.lastName,dto.phone,dto.userId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TeacherViewModel) : Api.TeacherClientRequestModel
	{
		let response = new Api.TeacherClientRequestModel();
		response.setProperties(model.birthday,model.email,model.firstName,model.id,model.lastName,model.phone,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>b0e82ed4b0c9742276fb9c3cce7519fb</Hash>
</Codenesium>*/