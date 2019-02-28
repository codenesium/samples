import * as Api from '../../api/models';
import CommentViewModel from  './commentViewModel';
export default class CommentMapper {
    
	mapApiResponseToViewModel(dto: Api.CommentClientResponseModel) : CommentViewModel 
	{
		let response = new CommentViewModel();
		response.setProperties(dto.creationDate,dto.id,dto.postId,dto.score,dto.text,dto.userId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CommentViewModel) : Api.CommentClientRequestModel
	{
		let response = new Api.CommentClientRequestModel();
		response.setProperties(model.creationDate,model.id,model.postId,model.score,model.text,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>7be02e8cb3318b593faf8af0185e1971</Hash>
</Codenesium>*/