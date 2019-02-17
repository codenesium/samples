import * as Api from '../../api/models';
import BusinessEntityViewModel from './businessEntityViewModel';
export default class BusinessEntityMapper {
  mapApiResponseToViewModel(
    dto: Api.BusinessEntityClientResponseModel
  ): BusinessEntityViewModel {
    let response = new BusinessEntityViewModel();
    response.setProperties(dto.businessEntityID, dto.modifiedDate, dto.rowguid);

    return response;
  }

  mapViewModelToApiRequest(
    model: BusinessEntityViewModel
  ): Api.BusinessEntityClientRequestModel {
    let response = new Api.BusinessEntityClientRequestModel();
    response.setProperties(
      model.businessEntityID,
      model.modifiedDate,
      model.rowguid
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>a9ee35ddcd5e3f37ec31e832555d230c</Hash>
</Codenesium>*/