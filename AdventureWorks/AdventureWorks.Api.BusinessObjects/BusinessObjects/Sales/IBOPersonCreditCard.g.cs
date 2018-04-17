using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPersonCreditCard
	{
		Task<CreateResponse<int>> Create(
			PersonCreditCardModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PersonCreditCardModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOPersonCreditCard GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>06e38298592330731920691843f4b7c8</Hash>
</Codenesium>*/