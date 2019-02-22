import * as Api from '../../api/models';
import TestAllFieldTypeViewModel from './testAllFieldTypeViewModel';
export default class TestAllFieldTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.TestAllFieldTypeClientResponseModel
  ): TestAllFieldTypeViewModel {
    let response = new TestAllFieldTypeViewModel();
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
      dto.fieldGeography,
      dto.fieldGeometry,
      dto.fieldHierarchyId,
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
      dto.fieldVariant,
      dto.fieldXML,
      dto.id
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: TestAllFieldTypeViewModel
  ): Api.TestAllFieldTypeClientRequestModel {
    let response = new Api.TestAllFieldTypeClientRequestModel();
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
      model.fieldGeography,
      model.fieldGeometry,
      model.fieldHierarchyId,
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
      model.fieldVariant,
      model.fieldXML,
      model.id
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>16e9d26aa9ba3b9d00bf9fff010a88d0</Hash>
</Codenesium>*/