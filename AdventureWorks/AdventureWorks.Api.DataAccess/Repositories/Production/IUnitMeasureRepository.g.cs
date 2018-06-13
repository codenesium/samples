using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IUnitMeasureRepository
        {
                Task<UnitMeasure> Create(UnitMeasure item);

                Task Update(UnitMeasure item);

                Task Delete(string unitMeasureCode);

                Task<UnitMeasure> Get(string unitMeasureCode);

                Task<List<UnitMeasure>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<UnitMeasure> GetName(string name);

                Task<List<BillOfMaterials>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
                Task<List<Product>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>202c806430e96d074bb29ad2a1495736</Hash>
</Codenesium>*/