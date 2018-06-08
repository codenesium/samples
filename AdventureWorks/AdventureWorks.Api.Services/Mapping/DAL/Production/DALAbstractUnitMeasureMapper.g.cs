using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractUnitMeasureMapper
        {
                public virtual UnitMeasure MapBOToEF(
                        BOUnitMeasure bo)
                {
                        UnitMeasure efUnitMeasure = new UnitMeasure();

                        efUnitMeasure.SetProperties(
                                bo.ModifiedDate,
                                bo.Name,
                                bo.UnitMeasureCode);
                        return efUnitMeasure;
                }

                public virtual BOUnitMeasure MapEFToBO(
                        UnitMeasure ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOUnitMeasure();

                        bo.SetProperties(
                                ef.UnitMeasureCode,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOUnitMeasure> MapEFToBO(
                        List<UnitMeasure> records)
                {
                        List<BOUnitMeasure> response = new List<BOUnitMeasure>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9f8adf61886f12eb0bb71a2f033e3f40</Hash>
</Codenesium>*/