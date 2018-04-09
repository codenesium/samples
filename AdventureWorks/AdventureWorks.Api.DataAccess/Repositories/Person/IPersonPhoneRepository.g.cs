using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		int Create(string phoneNumber,
		           int phoneNumberTypeID,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string phoneNumber,
		            int phoneNumberTypeID,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOPersonPhone GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOPersonPhone> GetWhereDirect(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c8eac4dffc58b35dc0dbf9c13d183bdf</Hash>
</Codenesium>*/