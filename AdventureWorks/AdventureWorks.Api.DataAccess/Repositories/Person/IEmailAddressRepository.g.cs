using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		int Create(int emailAddressID,
		           string emailAddress1,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, int emailAddressID,
		            string emailAddress1,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOEmailAddress GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOEmailAddress> GetWhereDirect(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>732c84e65140c9fb7157029160a73699</Hash>
</Codenesium>*/