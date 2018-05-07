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

		POCOPhoneNumberType Get(int phoneNumberTypeID);

		List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ce23381dea6c159b5f5be9bd942c1e7d</Hash>
</Codenesium>*/