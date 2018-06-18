using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractClaspMapper
        {
                public virtual Clasp MapBOToEF(
                        BOClasp bo)
                {
                        Clasp efClasp = new Clasp();

                        efClasp.SetProperties(
                                bo.Id,
                                bo.NextChainId,
                                bo.PreviousChainId);
                        return efClasp;
                }

                public virtual BOClasp MapEFToBO(
                        Clasp ef)
                {
                        var bo = new BOClasp();

                        bo.SetProperties(
                                ef.Id,
                                ef.NextChainId,
                                ef.PreviousChainId);
                        return bo;
                }

                public virtual List<BOClasp> MapEFToBO(
                        List<Clasp> records)
                {
                        List<BOClasp> response = new List<BOClasp>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2df86b92c1dfc953d6aa2380a1bc6d72</Hash>
</Codenesium>*/