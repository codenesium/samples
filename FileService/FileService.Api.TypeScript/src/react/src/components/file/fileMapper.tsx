import * as Api from '../../api/models';
import FileViewModel from './fileViewModel';
import BucketViewModel from '../bucket/bucketViewModel';
import FileTypeViewModel from '../fileType/fileTypeViewModel';
export default class FileMapper {
  mapApiResponseToViewModel(dto: Api.FileClientResponseModel): FileViewModel {
    let response = new FileViewModel();
    response.setProperties(
      dto.bucketId,
      dto.dateCreated,
      dto.description,
      dto.expiration,
      dto.extension,
      dto.externalId,
      dto.fileSizeInByte,
      dto.fileTypeId,
      dto.id,
      dto.location,
      dto.privateKey,
      dto.publicKey
    );

    if (dto.bucketIdNavigation != null) {
      response.bucketIdNavigation = new BucketViewModel();
      response.bucketIdNavigation.setProperties(
        dto.bucketIdNavigation.externalId,
        dto.bucketIdNavigation.id,
        dto.bucketIdNavigation.name
      );
    }
    if (dto.fileTypeIdNavigation != null) {
      response.fileTypeIdNavigation = new FileTypeViewModel();
      response.fileTypeIdNavigation.setProperties(
        dto.fileTypeIdNavigation.id,
        dto.fileTypeIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: FileViewModel): Api.FileClientRequestModel {
    let response = new Api.FileClientRequestModel();
    response.setProperties(
      model.bucketId,
      model.dateCreated,
      model.description,
      model.expiration,
      model.extension,
      model.externalId,
      model.fileSizeInByte,
      model.fileTypeId,
      model.id,
      model.location,
      model.privateKey,
      model.publicKey
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>2e625f899931460927f27cf2ee2a9467</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/