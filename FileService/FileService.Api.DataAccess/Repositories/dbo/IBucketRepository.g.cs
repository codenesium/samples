using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		int Create(
			string name,
			Guid externalId);

		void Update(int id,
		            string name,
		            Guid externalId);

		void Delete(int id);

		Response GetById(int id);

		POCOBucket GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBucket> GetWhereDirect(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dac049db3b0cd4d3b0389cfff444e64b</Hash>
</Codenesium>*/