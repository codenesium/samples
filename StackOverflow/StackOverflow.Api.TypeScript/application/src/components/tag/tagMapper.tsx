import * as Api from '../../api/models';
import TagViewModel from './tagViewModel';
export default class TagMapper {
  mapApiResponseToViewModel(dto: Api.TagClientResponseModel): TagViewModel {
    let response = new TagViewModel();
    response.setProperties(
      dto.count,
      dto.excerptPostId,
      dto.id,
      dto.tagName,
      dto.wikiPostId
    );

    return response;
  }

  mapViewModelToApiRequest(model: TagViewModel): Api.TagClientRequestModel {
    let response = new Api.TagClientRequestModel();
    response.setProperties(
      model.count,
      model.excerptPostId,
      model.id,
      model.tagName,
      model.wikiPostId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>a4089f23c8cc60c159d8a548f17a5a49</Hash>
</Codenesium>*/