using System;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		int Create(Guid externalId,
		           string name);

		void Update(int id, Guid externalId,
		            string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Bucket, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>69a0bbb67801f33d652dbb0e7c44b028</Hash>
</Codenesium>*/