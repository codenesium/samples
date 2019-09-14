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

		Task<List<PaymentType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Sale>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6969d1b7cb934efdadb586c62b0957cd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/