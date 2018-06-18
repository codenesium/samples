using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>131ecea07b93c08b6846eab9395daff0</Hash>
</Codenesium>*/