using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALUnitMeasureMapper
        {
                UnitMeasure MapBOToEF(
                        BOUnitMeasure bo);

                BOUnitMeasure MapEFToBO(
                        UnitMeasure efUnitMeasure);

                List<BOUnitMeasure> MapEFToBO(
                        List<UnitMeasure> records);
        }
}

/*<Codenesium>
    <Hash>aa4c1de507c81d036938dd975cba61ef</Hash>
</Codenesium>*/