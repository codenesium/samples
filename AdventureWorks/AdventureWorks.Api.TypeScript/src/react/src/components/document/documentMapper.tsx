import * as Api from '../../api/models';
import DocumentViewModel from './documentViewModel';

export default class DocumentMapper {
  mapApiResponseToViewModel(
    dto: Api.DocumentClientResponseModel
  ): DocumentViewModel {
    let response = new DocumentViewModel();
    response.setProperties(
      dto.changeNumber,
      dto.document1,
      dto.documentLevel,
      dto.documentSummary,
      dto.fileExtension,
      dto.fileName,
      dto.folderFlag,
      dto.modifiedDate,
      dto.owner,
      dto.revision,
      dto.rowguid,
      dto.status,
      dto.title
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: DocumentViewModel
  ): Api.DocumentClientRequestModel {
    let response = new Api.DocumentClientRequestModel();
    response.setProperties(
      model.changeNumber,
      model.document1,
      model.documentLevel,
      model.documentSummary,
      model.fileExtension,
      model.fileName,
      model.folderFlag,
      model.modifiedDate,
      model.owner,
      model.revision,
      model.rowguid,
      model.status,
      model.title
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>11db9d2096af2b5a5fcd7163536096e2</Hash>
</Codenesium>*/