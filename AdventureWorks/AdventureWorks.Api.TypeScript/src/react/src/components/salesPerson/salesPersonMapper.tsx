import * as Api from '../../api/models';
import SalesPersonViewModel from './salesPersonViewModel';

export default class SalesPersonMapper {
  mapApiResponseToViewModel(
    dto: Api.SalesPersonClientResponseModel
  ): SalesPersonViewModel {
    let response = new SalesPersonViewModel();
    response.setProperties(
      dto.bonus,
      dto.businessEntityID,
      dto.commissionPct,
      dto.modifiedDate,
      dto.rowguid,
      dto.salesLastYear,
      dto.salesQuota,
      dto.salesYTD,
      dto.territoryID
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: SalesPersonViewModel
  ): Api.SalesPersonClientRequestModel {
    let response = new Api.SalesPersonClientRequestModel();
    response.setProperties(
      model.bonus,
      model.businessEntityID,
      model.commissionPct,
      model.modifiedDate,
      model.rowguid,
      model.salesLastYear,
      model.salesQuota,
      model.salesYTD,
      model.territoryID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>0c2fedcac6b5a914505a1bd1bf7f036f</Hash>
</Codenesium>*/