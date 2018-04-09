using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int businessEntityID);

		POCOPassword GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOPassword> GetWhereDirect(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bd51bb9a7b2ca028182249ca7368a0d2</Hash>
</Codenesium>*/