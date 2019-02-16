import * as Api from '../../api/models';
import TestAllFieldTypesNullableViewModel from './testAllFieldTypesNullableViewModel';
export default class TestAllFieldTypesNullableMapper {
  mapApiResponseToViewModel(
    dto: Api.TestAllFieldTypesNullableClientResponseModel
  ): TestAllFieldTypesNullableViewModel {
    let response = new TestAllFieldTypesNullableViewModel();
    response.setProperties(
      dto.fieldBigInt,
      dto.fieldBinary,
      dto.fieldBit,
      dto.fieldChar,
      dto.fieldDate,
      dto.fieldDateTime,
      dto.fieldDateTime2,
      dto.fieldDateTimeOffset,
      dto.fieldDecimal,
      dto.fieldFloat,
      dto.fieldImage,
      dto.fieldMoney,
      dto.fieldNChar,
      dto.fieldNText,
      dto.fieldNumeric,
      dto.fieldNVarchar,
      dto.fieldReal,
      dto.fieldSmallDateTime,
      dto.fieldSmallInt,
      dto.fieldSmallMoney,
      dto.fieldText,
      dto.fieldTime,
      dto.fieldTimestamp,
      dto.fieldTinyInt,
      dto.fieldUniqueIdentifier,
      dto.fieldVarBinary,
      dto.fieldVarchar,
      dto.fieldXML,
      dto.id
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: TestAllFieldTypesNullableViewModel
  ): Api.TestAllFieldTypesNullableClientRequestModel {
    let response = new Api.TestAllFieldTypesNullableClientRequestModel();
    response.setProperties(
      model.fieldBigInt,
      model.fieldBinary,
      model.fieldBit,
      model.fieldChar,
      model.fieldDate,
      model.fieldDateTime,
      model.fieldDateTime2,
      model.fieldDateTimeOffset,
      model.fieldDecimal,
      model.fieldFloat,
      model.fieldImage,
      model.fieldMoney,
      model.fieldNChar,
      model.fieldNText,
      model.fieldNumeric,
      model.fieldNVarchar,
      model.fieldReal,
      model.fieldSmallDateTime,
      model.fieldSmallInt,
      model.fieldSmallMoney,
      model.fieldText,
      model.fieldTime,
      model.fieldTimestamp,
      model.fieldTinyInt,
      model.fieldUniqueIdentifier,
      model.fieldVarBinary,
      model.fieldVarchar,
      model.fieldXML,
      model.id
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>12453a336c10c55db0c7ef1e556b99a3</Hash>
</Codenesium>*/