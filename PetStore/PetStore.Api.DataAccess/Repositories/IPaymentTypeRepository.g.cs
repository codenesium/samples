using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface IPaymentTypeRepository
	{
		Task<PaymentType> Create(PaymentType item);

		Task Update(PaymentType item);

		Task Delete(int id);

		Task<PaymentType> Get(int id);

		Task<List<PaymentType>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> Sales(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9915b3befa7bcdb5956c3da9b302c351</Hash>
</Codenesium>*/