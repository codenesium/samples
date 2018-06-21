using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractStoreMapper
        {
                public virtual Store MapBOToEF(
                        BOStore bo)
                {
                        Store efStore = new Store();
                        efStore.SetProperties(
                                bo.BusinessEntityID,
                                bo.Demographics,
                                bo.ModifiedDate,
                                bo.Name,
                                bo.Rowguid,
                                bo.SalesPersonID);
                        return efStore;
                }

                public virtual BOStore MapEFToBO(
                        Store ef)
                {
                        var bo = new BOStore();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.Demographics,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.Rowguid,
                                ef.SalesPersonID);
                        return bo;
                }

                public virtual List<BOStore> MapEFToBO(
                        List<Store> records)
                {
                        List<BOStore> response = new List<BOStore>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>982905a435a464caebfbc2e7323432fd</Hash>
</Codenesium>*/