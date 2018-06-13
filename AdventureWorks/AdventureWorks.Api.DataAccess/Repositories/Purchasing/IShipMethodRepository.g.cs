using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IShipMethodRepository
        {
                Task<ShipMethod> Create(ShipMethod item);

                Task Update(ShipMethod item);

                Task Delete(int shipMethodID);

                Task<ShipMethod> Get(int shipMethodID);

                Task<List<ShipMethod>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ShipMethod> GetName(string name);

                Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>41ce282c8c9b13b58b00db06ddae9f40</Hash>
</Codenesium>*/