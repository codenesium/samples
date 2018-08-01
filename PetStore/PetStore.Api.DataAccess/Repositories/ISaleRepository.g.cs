using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISaleRepository
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
    <Hash>8a1610361e2e523dbc89c6216253a63c</Hash>
</Codenesium>*/