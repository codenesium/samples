using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IVEventService
	{
		Task<ApiVEventResponseModel> Get(int id);

		Task<List<ApiVEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1d2b77871b3158698b6d4258139349fc</Hash>
</Codenesium>*/