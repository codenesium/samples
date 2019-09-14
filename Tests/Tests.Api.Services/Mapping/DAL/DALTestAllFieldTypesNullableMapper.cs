using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALTestAllFieldTypesNullableMapper : IDALTestAllFieldTypesNullableMapper
	{
		public virtual TestAllFieldTypesNullable MapModelToEntity(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel model
			)
		{
			TestAllFieldTypesNullable item = new TestAllFieldTypesNullable();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiTestAllFieldTypesNullableServerResponseModel MapEntityToModel(
			TestAllFieldTypesNullable item)
		{
			var model = new ApiTestAllFieldTypesNullableServerResponseModel();

			model.SetProperties(item.Id,
			                    item.FieldBigInt,
			                    item.FieldBinary,
			                    item.FieldBit,
			                    item.FieldChar,
			                    item.FieldDate,
			                    item.FieldDateTime,
			                    item.FieldDateTime2,
			                    item.FieldDateTimeOffset,
			                    item.FieldDecimal,
			                    item.FieldFloat,
			                    item.FieldImage,
			                    item.FieldMoney,
			                    item.FieldNChar,
			                    item.FieldNText,
			                    item.FieldNumeric,
			                    item.FieldNVarchar,
			                    item.FieldReal,
			                    item.FieldSmallDateTime,
			                    item.FieldSmallInt,
			                    item.FieldSmallMoney,
			                    item.FieldText,
			                    item.FieldTime,
			                    item.FieldTimestamp,
			                    item.FieldTinyInt,
			                    item.FieldUniqueIdentifier,
			                    item.FieldVarBinary,
			                    item.FieldVarchar,
			                    item.FieldXML);

			return model;
		}

		public virtual List<ApiTestAllFieldTypesNullableServerResponseModel> MapEntityToModel(
			List<TestAllFieldTypesNullable> items)
		{
			List<ApiTestAllFieldTypesNullableServerResponseModel> response = new List<ApiTestAllFieldTypesNullableServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5fad06247cf04e64e34f29975d3d3eb5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/