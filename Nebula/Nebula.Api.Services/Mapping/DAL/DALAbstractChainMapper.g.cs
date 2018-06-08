using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractChainMapper
        {
                public virtual Chain MapBOToEF(
                        BOChain bo)
                {
                        Chain efChain = new Chain();

                        efChain.SetProperties(
                                bo.ChainStatusId,
                                bo.ExternalId,
                                bo.Id,
                                bo.Name,
                                bo.TeamId);
                        return efChain;
                }

                public virtual BOChain MapEFToBO(
                        Chain ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOChain();

                        bo.SetProperties(
                                ef.Id,
                                ef.ChainStatusId,
                                ef.ExternalId,
                                ef.Name,
                                ef.TeamId);
                        return bo;
                }

                public virtual List<BOChain> MapEFToBO(
                        List<Chain> records)
                {
                        List<BOChain> response = new List<BOChain>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ce5e199c9210ace28fdbfcdf6d35ad9e</Hash>
</Codenesium>*/