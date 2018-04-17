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

		ApiResponse GetById(int phoneNumberTypeID);

		POCOPhoneNumberType GetByIdDirect(int phoneNumberTypeID);

		ApiResponse GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPhoneNumberType> GetWhereDirect(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>df46d3fee6c63944e5c53af6b08dd424</Hash>
</Codenesium>*/