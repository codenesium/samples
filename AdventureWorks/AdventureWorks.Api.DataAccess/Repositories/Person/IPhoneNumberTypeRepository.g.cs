using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
	{
		int Create(string name,
		           DateTime modifiedDate);

		void Update(int phoneNumberTypeID, string name,
		            DateTime modifiedDate);

		void Delete(int phoneNumberTypeID);

		Response GetById(int phoneNumberTypeID);

		POCOPhoneNumberType GetByIdDirect(int phoneNumberTypeID);

		Response GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOPhoneNumberType> GetWhereDirect(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>34964e94a319d6bab169887224e2c98c</Hash>
</Codenesium>*/