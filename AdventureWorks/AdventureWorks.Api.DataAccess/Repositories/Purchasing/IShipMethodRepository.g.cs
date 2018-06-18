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

                Task<List<ShipMethod>> All(int limit = int.MaxValue, int offset = 0);

                Task<ShipMethod> ByName(string name);

                Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5d27c2c95d9560a0d446cd530a0bc0ff</Hash>
</Codenesium>*/