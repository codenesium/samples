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

                Task<List<ShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ShipMethod> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>e89419c1bd94e35cff3f84c40e0a565e</Hash>
</Codenesium>*/