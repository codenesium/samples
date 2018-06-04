using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLContactTypeMapper
	{
		BOContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeRequestModel model);

		ApiContactTypeResponseModel MapBOToModel(
			BOContactType boContactType);

		List<ApiContactTypeResponseModel> MapBOToModel(
			List<BOContactType> bos);
	}
}

/*<Codenesium>
    <Hash>2028764c0dcafee8c665c4a26f8b0771</Hash>
</Codenesium>*/