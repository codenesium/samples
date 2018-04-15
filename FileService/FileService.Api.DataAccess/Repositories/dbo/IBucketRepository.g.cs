using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		int Create(BucketModel model);

		void Update(int id,
		            BucketModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOBucket GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBucket> GetWhereDirect(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>27433b3a20efc563b19bcd67bc819adf</Hash>
</Codenesium>*/