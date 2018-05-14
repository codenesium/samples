using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
	{
		POCOPhoneNumberType Create(ApiPhoneNumberTypeModel model);

		void Update(int phoneNumberTypeID,
		            ApiPhoneNumberTypeModel model);

		void Delete(int phoneNumberTypeID);

		POCOPhoneNumberType Get(int phoneNumberTypeID);

		List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ecd93cadd5619e25f202c1170d8d962f</Hash>
</Codenesium>*/