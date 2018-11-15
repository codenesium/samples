using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractTestAllFieldTypesNullableMapper
	{
		public virtual BOTestAllFieldTypesNullable MapModelToBO(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel model
			)
		{
			BOTestAllFieldTypesNullable boTestAllFieldTypesNullable = new BOTestAllFieldTypesNullable();
			boTestAllFieldTypesNullable.SetProperties(
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
			return boTestAllFieldTypesNullable;
		}

		public virtual ApiTestAllFieldTypesNullableServerResponseModel MapBOToModel(
			BOTestAllFieldTypesNullable boTestAllFieldTypesNullable)
		{
			var model = new ApiTestAllFieldTypesNullableServerResponseModel();

			model.SetProperties(boTestAllFieldTypesNullable.Id, boTestAllFieldTypesNullable.FieldBigInt, boTestAllFieldTypesNullable.FieldBinary, boTestAllFieldTypesNullable.FieldBit, boTestAllFieldTypesNullable.FieldChar, boTestAllFieldTypesNullable.FieldDate, boTestAllFieldTypesNullable.FieldDateTime, boTestAllFieldTypesNullable.FieldDateTime2, boTestAllFieldTypesNullable.FieldDateTimeOffset, boTestAllFieldTypesNullable.FieldDecimal, boTestAllFieldTypesNullable.FieldFloat, boTestAllFieldTypesNullable.FieldImage, boTestAllFieldTypesNullable.FieldMoney, boTestAllFieldTypesNullable.FieldNChar, boTestAllFieldTypesNullable.FieldNText, boTestAllFieldTypesNullable.FieldNumeric, boTestAllFieldTypesNullable.FieldNVarchar, boTestAllFieldTypesNullable.FieldReal, boTestAllFieldTypesNullable.FieldSmallDateTime, boTestAllFieldTypesNullable.FieldSmallInt, boTestAllFieldTypesNullable.FieldSmallMoney, boTestAllFieldTypesNullable.FieldText, boTestAllFieldTypesNullable.FieldTime, boTestAllFieldTypesNullable.FieldTimestamp, boTestAllFieldTypesNullable.FieldTinyInt, boTestAllFieldTypesNullable.FieldUniqueIdentifier, boTestAllFieldTypesNullable.FieldVarBinary, boTestAllFieldTypesNullable.FieldVarchar, boTestAllFieldTypesNullable.FieldXML);

			return model;
		}

		public virtual List<ApiTestAllFieldTypesNullableServerResponseModel> MapBOToModel(
			List<BOTestAllFieldTypesNullable> items)
		{
			List<ApiTestAllFieldTypesNullableServerResponseModel> response = new List<ApiTestAllFieldTypesNullableServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e9878c2ed017ae27d4b9b81a0b6f17ba</Hash>
</Codenesium>*/