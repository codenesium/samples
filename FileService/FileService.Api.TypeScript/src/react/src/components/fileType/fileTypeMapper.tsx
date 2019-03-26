import * as Api from '../../api/models';
import FileTypeViewModel from './fileTypeViewModel';
export default class FileTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.FileTypeClientResponseModel
  ): FileTypeViewModel {
    let response = new FileTypeViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: FileTypeViewModel
  ): Api.FileTypeClientRequestModel {
    let response = new Api.FileTypeClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>b1821774040a3c22256313968507df84</Hash>
</Codenesium>*/