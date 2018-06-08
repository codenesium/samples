using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractClientMapper
        {
                public virtual Client MapBOToEF(
                        BOClient bo)
                {
                        Client efClient = new Client();

                        efClient.SetProperties(
                                bo.Email,
                                bo.FirstName,
                                bo.Id,
                                bo.LastName,
                                bo.Notes,
                                bo.Phone);
                        return efClient;
                }

                public virtual BOClient MapEFToBO(
                        Client ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOClient();

                        bo.SetProperties(
                                ef.Id,
                                ef.Email,
                                ef.FirstName,
                                ef.LastName,
                                ef.Notes,
                                ef.Phone);
                        return bo;
                }

                public virtual List<BOClient> MapEFToBO(
                        List<Client> records)
                {
                        List<BOClient> response = new List<BOClient>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4072edfe723fe5073d346510ebbb9862</Hash>
</Codenesium>*/