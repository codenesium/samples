using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiTestAllFieldTypeServerModelMapper : IApiTestAllFieldTypeServerModelMapper
	{
		public virtual ApiTestAllFieldTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTestAllFieldTypeServerRequestModel request)
		{
			var response = new ApiTestAllFieldTypeServerResponseModel();
			response.SetProperties(id,
			                       request.FieldBigInt,
			                       request.FieldBinary,
			                       request.FieldBit,
			                       request.FieldChar,
			                       request.FieldDate,
			                       request.FieldDateTime,
			                       request.FieldDateTime2,
			                       request.FieldDateTimeOffset,
			                       request.FieldDecimal,
			                       request.FieldFloat,
			                       request.FieldImage,
			                       request.FieldMoney,
			                       request.FieldNChar,
			                       request.FieldNText,
			                       request.FieldNumeric,
			                       request.FieldNVarchar,
			                       request.FieldReal,
			                       request.FieldSmallDateTime,
			                       request.FieldSmallInt,
			                       request.FieldSmallMoney,
			                       request.FieldText,
			                       request.FieldTime,
			                       request.FieldTimestamp,
			                       request.FieldTinyInt,
			                       request.FieldUniqueIdentifier,
			                       request.FieldVarBinary,
			                       request.FieldVarchar,
			                       request.FieldXML);
			return response;
		}

		public virtual ApiTestAllFieldTypeServerRequestModel MapServerResponseToRequest(
			ApiTestAllFieldTypeServerResponseModel response)
		{
			var request = new ApiTestAllFieldTypeServerRequestModel();
			request.SetProperties(
				response.FieldBigInt,
				response.FieldBinary,
				response.FieldBit,
				response.FieldChar,
				response.FieldDate,
				response.FieldDateTime,
				response.FieldDateTime2,
				response.FieldDateTimeOffset,
				response.FieldDecimal,
				response.FieldFloat,
				response.FieldImage,
				response.FieldMoney,
				response.FieldNChar,
				response.FieldNText,
				response.FieldNumeric,
				response.FieldNVarchar,
				response.FieldReal,
				response.FieldSmallDateTime,
				response.FieldSmallInt,
				response.FieldSmallMoney,
				response.FieldText,
				response.FieldTime,
				response.FieldTimestamp,
				response.FieldTinyInt,
				response.FieldUniqueIdentifier,
				response.FieldVarBinary,
				response.FieldVarchar,
				response.FieldXML);
			return request;
		}

		public virtual ApiTestAllFieldTypeClientRequestModel MapServerResponseToClientRequest(
			ApiTestAllFieldTypeServerResponseModel response)
		{
			var request = new ApiTestAllFieldTypeClientRequestModel();
			request.SetProperties(
				response.FieldBigInt,
				response.FieldBinary,
				response.FieldBit,
				response.FieldChar,
				response.FieldDate,
				response.FieldDateTime,
				response.FieldDateTime2,
				response.FieldDateTimeOffset,
				response.FieldDecimal,
				response.FieldFloat,
				response.FieldImage,
				response.FieldMoney,
				response.FieldNChar,
				response.FieldNText,
				response.FieldNumeric,
				response.FieldNVarchar,
				response.FieldReal,
				response.FieldSmallDateTime,
				response.FieldSmallInt,
				response.FieldSmallMoney,
				response.FieldText,
				response.FieldTime,
				response.FieldTimestamp,
				response.FieldTinyInt,
				response.FieldUniqueIdentifier,
				response.FieldVarBinary,
				response.FieldVarchar,
				response.FieldXML);
			return request;
		}

		public JsonPatchDocument<ApiTestAllFieldTypeServerRequestModel> CreatePatch(ApiTestAllFieldTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTestAllFieldTypeServerRequestModel>();
			patch.Replace(x => x.FieldBigInt, model.FieldBigInt);
			patch.Replace(x => x.FieldBinary, model.FieldBinary);
			patch.Replace(x => x.FieldBit, model.FieldBit);
			patch.Replace(x => x.FieldChar, model.FieldChar);
			patch.Replace(x => x.FieldDate, model.FieldDate);
			patch.Replace(x => x.FieldDateTime, model.FieldDateTime);
			patch.Replace(x => x.FieldDateTime2, model.FieldDateTime2);
			patch.Replace(x => x.FieldDateTimeOffset, model.FieldDateTimeOffset);
			patch.Replace(x => x.FieldDecimal, model.FieldDecimal);
			patch.Replace(x => x.FieldFloat, model.FieldFloat);
			patch.Replace(x => x.FieldImage, model.FieldImage);
			patch.Replace(x => x.FieldMoney, model.FieldMoney);
			patch.Replace(x => x.FieldNChar, model.FieldNChar);
			patch.Replace(x => x.FieldNText, model.FieldNText);
			patch.Replace(x => x.FieldNumeric, model.FieldNumeric);
			patch.Replace(x => x.FieldNVarchar, model.FieldNVarchar);
			patch.Replace(x => x.FieldReal, model.FieldReal);
			patch.Replace(x => x.FieldSmallDateTime, model.FieldSmallDateTime);
			patch.Replace(x => x.FieldSmallInt, model.FieldSmallInt);
			patch.Replace(x => x.FieldSmallMoney, model.FieldSmallMoney);
			patch.Replace(x => x.FieldText, model.FieldText);
			patch.Replace(x => x.FieldTime, model.FieldTime);
			patch.Replace(x => x.FieldTimestamp, model.FieldTimestamp);
			patch.Replace(x => x.FieldTinyInt, model.FieldTinyInt);
			patch.Replace(x => x.FieldUniqueIdentifier, model.FieldUniqueIdentifier);
			patch.Replace(x => x.FieldVarBinary, model.FieldVarBinary);
			patch.Replace(x => x.FieldVarchar, model.FieldVarchar);
			patch.Replace(x => x.FieldXML, model.FieldXML);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ba7832748b134a610b71f900a1f61138</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/