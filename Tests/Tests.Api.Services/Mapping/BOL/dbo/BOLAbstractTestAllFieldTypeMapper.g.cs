using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractTestAllFieldTypeMapper
	{
		public virtual BOTestAllFieldType MapModelToBO(
			int id,
			ApiTestAllFieldTypeServerRequestModel model
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

		public virtual ApiTestAllFieldTypeServerResponseModel MapBOToModel(
			BOTestAllFieldType boTestAllFieldType)
		{
			var model = new ApiTestAllFieldTypeServerResponseModel();

			model.SetProperties(boTestAllFieldType.Id, boTestAllFieldType.FieldBigInt, boTestAllFieldType.FieldBinary, boTestAllFieldType.FieldBit, boTestAllFieldType.FieldChar, boTestAllFieldType.FieldDate, boTestAllFieldType.FieldDateTime, boTestAllFieldType.FieldDateTime2, boTestAllFieldType.FieldDateTimeOffset, boTestAllFieldType.FieldDecimal, boTestAllFieldType.FieldFloat, boTestAllFieldType.FieldImage, boTestAllFieldType.FieldMoney, boTestAllFieldType.FieldNChar, boTestAllFieldType.FieldNText, boTestAllFieldType.FieldNumeric, boTestAllFieldType.FieldNVarchar, boTestAllFieldType.FieldReal, boTestAllFieldType.FieldSmallDateTime, boTestAllFieldType.FieldSmallInt, boTestAllFieldType.FieldSmallMoney, boTestAllFieldType.FieldText, boTestAllFieldType.FieldTime, boTestAllFieldType.FieldTimestamp, boTestAllFieldType.FieldTinyInt, boTestAllFieldType.FieldUniqueIdentifier, boTestAllFieldType.FieldVarBinary, boTestAllFieldType.FieldVarchar, boTestAllFieldType.FieldXML);

			return model;
		}

		public virtual List<ApiTestAllFieldTypeServerResponseModel> MapBOToModel(
			List<BOTestAllFieldType> items)
		{
			List<ApiTestAllFieldTypeServerResponseModel> response = new List<ApiTestAllFieldTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2e1e1fda3cb54af7cf6e050f0a487a1c</Hash>
</Codenesium>*/