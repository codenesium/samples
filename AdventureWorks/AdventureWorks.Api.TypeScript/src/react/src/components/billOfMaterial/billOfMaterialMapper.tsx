import * as Api from '../../api/models';
import BillOfMaterialViewModel from './billOfMaterialViewModel';

export default class BillOfMaterialMapper {
  mapApiResponseToViewModel(
    dto: Api.BillOfMaterialClientResponseModel
  ): BillOfMaterialViewModel {
    let response = new BillOfMaterialViewModel();
    response.setProperties(
      dto.billOfMaterialsID,
      dto.bOMLevel,
      dto.componentID,
      dto.endDate,
      dto.modifiedDate,
      dto.perAssemblyQty,
      dto.productAssemblyID,
      dto.startDate,
      dto.unitMeasureCode
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: BillOfMaterialViewModel
  ): Api.BillOfMaterialClientRequestModel {
    let response = new Api.BillOfMaterialClientRequestModel();
    response.setProperties(
      model.billOfMaterialsID,
      model.bOMLevel,
      model.componentID,
      model.endDate,
      model.modifiedDate,
      model.perAssemblyQty,
      model.productAssemblyID,
      model.startDate,
      model.unitMeasureCode
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>65d4bbe4082d024fbb43e4a7b7cf3c97</Hash>
</Codenesium>*/