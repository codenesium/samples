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

		Task<POCOPhoneNumberType> Get(int phoneNumberTypeID);

		Task<List<POCOPhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>47311e6d146bf83c5a0ea226441438b7</Hash>
</Codenesium>*/