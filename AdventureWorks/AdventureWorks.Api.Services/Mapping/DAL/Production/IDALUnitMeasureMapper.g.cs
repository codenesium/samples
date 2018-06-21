using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>301f8134e29d678f40edf9c798b8b73f</Hash>
</Codenesium>*/