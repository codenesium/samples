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

                Task<List<UnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<UnitMeasure> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>298dcdfcfdebdee22dcbaacc33d97286</Hash>
</Codenesium>*/