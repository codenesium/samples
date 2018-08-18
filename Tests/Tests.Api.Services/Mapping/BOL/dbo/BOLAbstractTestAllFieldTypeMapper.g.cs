using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractTestAllFieldTypeMapper
	{
		public virtual BOTestAllFieldType MapModelToBO(
			int id,
			ApiTestAllFieldTypeRequestModel model
			)
		{
			BOTestAllFieldType boTestAllFieldType = new BOTestAllFieldType();
			boTestAllFieldType.SetProperties(
				id,
				model.FieldBigInt,
				model.FieldBinary,
				model.FieldBit,
				model.FieldChar,
				model.FieldDate,
				model.FieldDateTime,
				model.FieldDateTime2,
				model.FieldDateTimeOffset,
				model.FieldDecimal,
				model.FieldFloat,
				model.FieldImage,
				model.FieldMoney,
				model.FieldNChar,
				model.FieldNText,
				model.FieldNumeric,
				model.FieldNVarchar,
				model.FieldReal,
				model.FieldSmallDateTime,
				model.FieldSmallInt,
				model.FieldSmallMoney,
				model.FieldText,
				model.FieldTime,
				model.FieldTimestamp,
				model.FieldTinyInt,
				model.FieldUniqueIdentifier,
				model.FieldVarBinary,
				model.FieldVarchar,
				model.FieldXML);
			return boTestAllFieldType;
		}

		public virtual ApiTestAllFieldTypeResponseModel MapBOToModel(
			BOTestAllFieldType boTestAllFieldType)
		{
			var model = new ApiTestAllFieldTypeResponseModel();

			model.SetProperties(boTestAllFieldType.Id, boTestAllFieldType.FieldBigInt, boTestAllFieldType.FieldBinary, boTestAllFieldType.FieldBit, boTestAllFieldType.FieldChar, boTestAllFieldType.FieldDate, boTestAllFieldType.FieldDateTime, boTestAllFieldType.FieldDateTime2, boTestAllFieldType.FieldDateTimeOffset, boTestAllFieldType.FieldDecimal, boTestAllFieldType.FieldFloat, boTestAllFieldType.FieldImage, boTestAllFieldType.FieldMoney, boTestAllFieldType.FieldNChar, boTestAllFieldType.FieldNText, boTestAllFieldType.FieldNumeric, boTestAllFieldType.FieldNVarchar, boTestAllFieldType.FieldReal, boTestAllFieldType.FieldSmallDateTime, boTestAllFieldType.FieldSmallInt, boTestAllFieldType.FieldSmallMoney, boTestAllFieldType.FieldText, boTestAllFieldType.FieldTime, boTestAllFieldType.FieldTimestamp, boTestAllFieldType.FieldTinyInt, boTestAllFieldType.FieldUniqueIdentifier, boTestAllFieldType.FieldVarBinary, boTestAllFieldType.FieldVarchar, boTestAllFieldType.FieldXML);

			return model;
		}

		public virtual List<ApiTestAllFieldTypeResponseModel> MapBOToModel(
			List<BOTestAllFieldType> items)
		{
			List<ApiTestAllFieldTypeResponseModel> response = new List<ApiTestAllFieldTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4c76f2810174d325f44f9346d52de651</Hash>
</Codenesium>*/