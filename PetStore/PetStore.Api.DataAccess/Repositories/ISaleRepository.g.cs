using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>d938339386641d992d78a82f8cd17574</Hash>
</Codenesium>*/