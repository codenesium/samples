using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface IPaymentTypeRepository
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
    <Hash>0683037cb230d41a57127c93696e4e87</Hash>
</Codenesium>*/