using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public class ApiTestAllFieldTypeModelMapper : IApiTestAllFieldTypeModelMapper
	{
		public virtual ApiTestAllFieldTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTestAllFieldTypeClientRequestModel request)
		{
			var response = new ApiTestAllFieldTypeClientResponseModel();
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

		public virtual ApiTestAllFieldTypeClientRequestModel MapClientResponseToRequest(
			ApiTestAllFieldTypeClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>3ec12e247b9b8bfe9d0a4da1f26f5637</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/