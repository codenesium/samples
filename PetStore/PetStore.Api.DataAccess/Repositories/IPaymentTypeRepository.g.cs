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

		Task<List<Sale>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c664a93d269bfc91806480fad51db923</Hash>
</Codenesium>*/