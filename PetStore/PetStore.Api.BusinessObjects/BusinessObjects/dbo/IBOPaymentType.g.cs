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

		POCOPaymentType Get(int id);

		List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>97405a52a437038509cbf35fa60fb679</Hash>
</Codenesium>*/