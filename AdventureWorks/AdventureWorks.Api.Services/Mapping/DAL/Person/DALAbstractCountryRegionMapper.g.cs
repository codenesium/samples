using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCountryRegionMapper
        {
                public virtual CountryRegion MapBOToEF(
                        BOCountryRegion bo)
                {
                        CountryRegion efCountryRegion = new CountryRegion();

                        efCountryRegion.SetProperties(
                                bo.CountryRegionCode,
                                bo.ModifiedDate,
                                bo.Name);
                        return efCountryRegion;
                }

                public virtual BOCountryRegion MapEFToBO(
                        CountryRegion ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOCountryRegion();

                        bo.SetProperties(
                                ef.CountryRegionCode,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOCountryRegion> MapEFToBO(
                        List<CountryRegion> records)
                {
                        List<BOCountryRegion> response = new List<BOCountryRegion>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>91ae14d409870e729bf2c80832f1abaa</Hash>
</Codenesium>*/