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

		Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<PaymentType> PaymentTypeByPaymentTypeId(int paymentTypeId);

		Task<Pet> PetByPetId(int petId);
	}
}

/*<Codenesium>
    <Hash>0f18c3f83080b501d0b962e2d413bbb0</Hash>
</Codenesium>*/