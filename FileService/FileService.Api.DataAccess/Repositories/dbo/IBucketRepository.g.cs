using System;
using System.Linq.Expressions;
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

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFBucket, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>54428918c63e629264d5772db4383378</Hash>
</Codenesium>*/