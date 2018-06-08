using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractAddressTypeMapper
        {
                public virtual AddressType MapBOToEF(
                        BOAddressType bo)
                {
                        AddressType efAddressType = new AddressType();

                        efAddressType.SetProperties(
                                bo.AddressTypeID,
                                bo.ModifiedDate,
                                bo.Name,
                                bo.Rowguid);
                        return efAddressType;
                }

                public virtual BOAddressType MapEFToBO(
                        AddressType ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOAddressType();

                        bo.SetProperties(
                                ef.AddressTypeID,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOAddressType> MapEFToBO(
                        List<AddressType> records)
                {
                        List<BOAddressType> response = new List<BOAddressType>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4240cab08ed186dde6e65766c7ef5720</Hash>
</Codenesium>*/