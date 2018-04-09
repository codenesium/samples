using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		int Create(string name,
		           Guid externalId);

		void Update(int id, string name,
		            Guid externalId);

		void Delete(int id);

		Response GetById(int id);

		POCOBucket GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOBucket> GetWhereDirect(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>84bb08d84a5d1c7c8c19c5f426b312c7</Hash>
</Codenesium>*/