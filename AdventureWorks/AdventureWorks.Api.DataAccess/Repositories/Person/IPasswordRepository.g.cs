using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		int Create(string passwordHash,
		           string passwordSalt,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string passwordHash,
		            string passwordSalt,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFPassword, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e2ba7360445210956abd6ab4b19163b3</Hash>
</Codenesium>*/