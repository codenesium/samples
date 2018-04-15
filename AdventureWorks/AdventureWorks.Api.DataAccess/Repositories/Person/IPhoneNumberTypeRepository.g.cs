using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
	{
		int Create(PhoneNumberTypeModel model);

		void Update(int phoneNumberTypeID,
		            PhoneNumberTypeModel model);

		void Delete(int phoneNumberTypeID);

		ApiResponse GetById(int phoneNumberTypeID);

		POCOPhoneNumberType GetByIdDirect(int phoneNumberTypeID);

		ApiResponse GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPhoneNumberType> GetWhereDirect(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9c59987ed5523e89a7aa9e2c2cf27a25</Hash>
</Codenesium>*/