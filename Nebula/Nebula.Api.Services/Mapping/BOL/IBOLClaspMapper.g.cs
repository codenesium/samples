using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IBOLClaspMapper
	{
		BOClasp MapModelToBO(
			int id,
			ApiClaspRequestModel model);

		ApiClaspResponseModel MapBOToModel(
			BOClasp boClasp);

		List<ApiClaspResponseModel> MapBOToModel(
			List<BOClasp> items);
	}
}

/*<Codenesium>
    <Hash>85d4be1443443e50743b83a48364f849</Hash>
</Codenesium>*/