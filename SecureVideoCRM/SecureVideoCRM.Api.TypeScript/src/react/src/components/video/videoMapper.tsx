import * as Api from '../../api/models';
import VideoViewModel from './videoViewModel';
export default class VideoMapper {
  mapApiResponseToViewModel(dto: Api.VideoClientResponseModel): VideoViewModel {
    let response = new VideoViewModel();
    response.setProperties(dto.description, dto.id, dto.title, dto.url);

    return response;
  }

  mapViewModelToApiRequest(model: VideoViewModel): Api.VideoClientRequestModel {
    let response = new Api.VideoClientRequestModel();
    response.setProperties(model.description, model.id, model.title, model.url);
    return response;
  }
}


/*<Codenesium>
    <Hash>94f44487da925e8f616a756d932e113c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/