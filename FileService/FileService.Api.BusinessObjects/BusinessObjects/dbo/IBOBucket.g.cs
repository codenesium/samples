using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOBucket
	{
		Task<CreateResponse<int>> Create(
			BucketModel model);

		Task<ActionResponse> Update(int id,
		                            BucketModel model);

		Task<ActionResponse> Delete(int id);

		POCOBucket Get(int id);

		List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7dd5e1db3b1bf506b8e38cc62cd398fe</Hash>
</Codenesium>*/