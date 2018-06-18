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
    <Hash>a814cd857c339cf3de06a5519c7755df</Hash>
</Codenesium>*/