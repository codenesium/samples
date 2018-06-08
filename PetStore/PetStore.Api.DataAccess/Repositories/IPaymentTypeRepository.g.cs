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

                Task<List<PaymentType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f813d46ef3cfa12986f4894039e3aed4</Hash>
</Codenesium>*/