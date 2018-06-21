using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractAddressMapper
        {
                public virtual Address MapBOToEF(
                        BOAddress bo)
                {
                        Address efAddress = new Address();
                        efAddress.SetProperties(
                                bo.AddressID,
                                bo.AddressLine1,
                                bo.AddressLine2,
                                bo.City,
                                bo.ModifiedDate,
                                bo.PostalCode,
                                bo.Rowguid,
                                bo.StateProvinceID);
                        return efAddress;
                }

                public virtual BOAddress MapEFToBO(
                        Address ef)
                {
                        var bo = new BOAddress();

                        bo.SetProperties(
                                ef.AddressID,
                                ef.AddressLine1,
                                ef.AddressLine2,
                                ef.City,
                                ef.ModifiedDate,
                                ef.PostalCode,
                                ef.Rowguid,
                                ef.StateProvinceID);
                        return bo;
                }

                public virtual List<BOAddress> MapEFToBO(
                        List<Address> records)
                {
                        List<BOAddress> response = new List<BOAddress>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>274d6ac90b3a417636b4570031ae42b8</Hash>
</Codenesium>*/