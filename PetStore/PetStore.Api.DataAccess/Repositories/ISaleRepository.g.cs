using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface ISaleRepository
	{
		Task<Sale> Create(Sale item);

		Task Update(Sale item);

		Task Delete(int id);

		Task<Sale> Get(int id);

		Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0);

		Task<PaymentType> GetPaymentType(int paymentTypeId);

		Task<Pet> GetPet(int petId);
	}
}

/*<Codenesium>
    <Hash>38fd2cbc0a314708f29df726573dda18</Hash>
</Codenesium>*/