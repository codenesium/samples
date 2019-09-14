using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALTestAllFieldTypeMapper : IDALTestAllFieldTypeMapper
	{
		public virtual TestAllFieldType MapModelToEntity(
			int id,
			ApiTestAllFieldTypeServerRequestModel model
			)
		{
			TestAllFieldType item = new TestAllFieldType();
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

		public virtual ApiTestAllFieldTypeServerResponseModel MapEntityToModel(
			TestAllFieldType item)
		{
			var model = new ApiTestAllFieldTypeServerResponseModel();

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

		public virtual List<ApiTestAllFieldTypeServerResponseModel> MapEntityToModel(
			List<TestAllFieldType> items)
		{
			List<ApiTestAllFieldTypeServerResponseModel> response = new List<ApiTestAllFieldTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>121168d7222de2f74c1d5e0901598516</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/