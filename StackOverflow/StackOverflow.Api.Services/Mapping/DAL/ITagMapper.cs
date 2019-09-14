using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALTagMapper
	{
		Tag MapModelToEntity(
			int id,
			ApiTagServerRequestModel model);

		ApiTagServerResponseModel MapEntityToModel(
			Tag item);

		List<ApiTagServerResponseModel> MapEntityToModel(
			List<Tag> items);
	}
}

/*<Codenesium>
    <Hash>c35623d78ba73e15dc82a264f9ebf0a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/