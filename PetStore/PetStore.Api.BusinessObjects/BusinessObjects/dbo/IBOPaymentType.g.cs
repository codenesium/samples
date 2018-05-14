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
		Task<CreateResponse<POCOPaymentType>> Create(
			ApiPaymentTypeModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPaymentTypeModel model);

		Task<ActionResponse> Delete(int id);

		POCOPaymentType Get(int id);

		List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>84658282aba6cf7750144d4f874186ec</Hash>
</Codenesium>*/