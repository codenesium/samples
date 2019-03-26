import * as Api from '../../api/models';
import SpecialOfferViewModel from './specialOfferViewModel';
export default class SpecialOfferMapper {
  mapApiResponseToViewModel(
    dto: Api.SpecialOfferClientResponseModel
  ): SpecialOfferViewModel {
    let response = new SpecialOfferViewModel();
    response.setProperties(
      dto.category,
      dto.description,
      dto.discountPct,
      dto.endDate,
      dto.maxQty,
      dto.minQty,
      dto.modifiedDate,
      dto.rowguid,
      dto.specialOfferID,
      dto.startDate,
      dto.reservedType
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: SpecialOfferViewModel
  ): Api.SpecialOfferClientRequestModel {
    let response = new Api.SpecialOfferClientRequestModel();
    response.setProperties(
      model.category,
      model.description,
      model.discountPct,
      model.endDate,
      model.maxQty,
      model.minQty,
      model.modifiedDate,
      model.rowguid,
      model.specialOfferID,
      model.startDate,
      model.reservedType
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>dd4875a9316f47d481dcb1825557e927</Hash>
</Codenesium>*/