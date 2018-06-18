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

                Task<List<UnitMeasure>> All(int limit = int.MaxValue, int offset = 0);

                Task<UnitMeasure> ByName(string name);

                Task<List<BillOfMaterials>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
                Task<List<Product>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>94084b48afff1186baf07067a4080d37</Hash>
</Codenesium>*/