using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPaymentType
	{
		Task<CreateResponse<int>> Create(
			PaymentTypeModel model);

		Task<ActionResponse> Update(int id,
		                            PaymentTypeModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPaymentType GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPaymentType> GetWhereDirect(Expression<Func<EFPaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>de93757c5024179cbf706c4797d83846</Hash>
</Codenesium>*/