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
		Task<CreateResponse<int>> Create(
			PhoneNumberTypeModel model);

		Task<ActionResponse> Update(int phoneNumberTypeID,
		                            PhoneNumberTypeModel model);

		Task<ActionResponse> Delete(int phoneNumberTypeID);

		POCOPhoneNumberType Get(int phoneNumberTypeID);

		List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2f50b4f7eca1f4cc7614fe089eeef99f</Hash>
</Codenesium>*/