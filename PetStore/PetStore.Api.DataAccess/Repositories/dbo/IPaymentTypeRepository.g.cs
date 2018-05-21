using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPaymentTypeRepository
	{
		Task<POCOPaymentType> Create(ApiPaymentTypeModel model);

		Task Update(int id,
		            ApiPaymentTypeModel model);

		Task Delete(int id);

		Task<POCOPaymentType> Get(int id);

		Task<List<POCOPaymentType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1cccd77ea2464a3ac3a44639616b9f89</Hash>
</Codenesium>*/