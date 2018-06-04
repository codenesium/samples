using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPersonMapper
	{
		BOPerson MapModelToBO(
			int businessEntityID,
			ApiPersonRequestModel model);

		ApiPersonResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> bos);
	}
}

/*<Codenesium>
    <Hash>121427a3876567fbf95a6afb2263aac4</Hash>
</Codenesium>*/