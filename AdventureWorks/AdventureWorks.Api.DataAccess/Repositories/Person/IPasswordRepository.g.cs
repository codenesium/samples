using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		int Create(PasswordModel model);

		void Update(int businessEntityID,
		            PasswordModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOPassword GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPassword> GetWhereDirect(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6d1c568e4ef56d8998534df2f2ae99e3</Hash>
</Codenesium>*/