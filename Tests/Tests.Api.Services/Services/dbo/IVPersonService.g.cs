using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IVPersonService
	{
		Task<ApiVPersonResponseModel> Get(int personId);

		Task<List<ApiVPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>62a3e487a22ebb4334b676ddf1e791a0</Hash>
</Codenesium>*/