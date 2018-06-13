using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface IPaymentTypeRepository
        {
                Task<PaymentType> Create(PaymentType item);

                Task Update(PaymentType item);

                Task Delete(int id);

                Task<PaymentType> Get(int id);

                Task<List<PaymentType>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Sale>> Sales(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5d63110b29ef3a86c6af59805de2e549</Hash>
</Codenesium>*/