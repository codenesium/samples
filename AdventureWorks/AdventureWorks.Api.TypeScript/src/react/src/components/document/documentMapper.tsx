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
    <Hash>45a2686f7c890985ad1158de8a91cabb</Hash>
</Codenesium>*/