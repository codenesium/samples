import * as Api from '../../api/models';
import SaleViewModel from './saleViewModel';
export default class SaleMapper {
  mapApiResponseToViewModel(dto: Api.SaleClientResponseModel): SaleViewModel {
    let response = new SaleViewModel();
    response.setProperties(dto.customerId, dto.date, dto.id);

    return response;
  }

  mapViewModelToApiRequest(model: SaleViewModel): Api.SaleClientRequestModel {
    let response = new Api.SaleClientRequestModel();
    response.setProperties(model.customerId, model.date, model.id);
    return response;
  }
}


/*<Codenesium>
    <Hash>7a82f609d55b8345b1b016c76f592f47</Hash>
</Codenesium>*/