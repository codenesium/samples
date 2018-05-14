using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPhoneNumberType
	{
		Task<CreateResponse<POCOPhoneNumberType>> Create(
			ApiPhoneNumberTypeModel model);

		Task<ActionResponse> Update(int phoneNumberTypeID,
		                            ApiPhoneNumberTypeModel model);

		Task<ActionResponse> Delete(int phoneNumberTypeID);

		POCOPhoneNumberType Get(int phoneNumberTypeID);

		List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d37ad3777a3fe280969e2abf77973a73</Hash>
</Codenesium>*/