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

		ApiResponse GetById(int id);

		POCOBucket GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBucket> GetWhereDirect(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>24ecb1758d12a9f266e1e103a0a87829</Hash>
</Codenesium>*/