using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractClientCommunicationMapper
        {
                public virtual ClientCommunication MapBOToEF(
                        BOClientCommunication bo)
                {
                        ClientCommunication efClientCommunication = new ClientCommunication();

                        efClientCommunication.SetProperties(
                                bo.ClientId,
                                bo.DateCreated,
                                bo.EmployeeId,
                                bo.Id,
                                bo.Notes);
                        return efClientCommunication;
                }

                public virtual BOClientCommunication MapEFToBO(
                        ClientCommunication ef)
                {
                        var bo = new BOClientCommunication();

                        bo.SetProperties(
                                ef.Id,
                                ef.ClientId,
                                ef.DateCreated,
                                ef.EmployeeId,
                                ef.Notes);
                        return bo;
                }

                public virtual List<BOClientCommunication> MapEFToBO(
                        List<ClientCommunication> records)
                {
                        List<BOClientCommunication> response = new List<BOClientCommunication>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f5477c18f202df4bd25e63cca4e16365</Hash>
</Codenesium>*/