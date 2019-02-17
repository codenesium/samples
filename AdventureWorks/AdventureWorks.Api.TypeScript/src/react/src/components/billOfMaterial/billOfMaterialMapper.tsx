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
    <Hash>ad0bf9be5113c794fb22a4a2c6cd4818</Hash>
</Codenesium>*/