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
			List<BOContactType> items);
	}
}

/*<Codenesium>
    <Hash>3d6b843a58c00eb6b8cdef98c6372643</Hash>
</Codenesium>*/