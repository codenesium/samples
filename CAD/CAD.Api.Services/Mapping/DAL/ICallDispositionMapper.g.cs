using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallDispositionMapper
	{
		CallDisposition MapModelToEntity(
			int id,
			ApiCallDispositionServerRequestModel model);

		ApiCallDispositionServerResponseModel MapEntityToModel(
			CallDisposition item);

		List<ApiCallDispositionServerResponseModel> MapEntityToModel(
			List<CallDisposition> items);
	}
}

/*<Codenesium>
    <Hash>9ab7fce1742c19d3b048fa42360aa26e</Hash>
</Codenesium>*/