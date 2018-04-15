using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		int Create(EmailAddressModel model);

		void Update(int businessEntityID,
		            EmailAddressModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmailAddress GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmailAddress> GetWhereDirect(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>823368348bca05dd3ee2572aa5b381ce</Hash>
</Codenesium>*/