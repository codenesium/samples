using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALClientCommunicationMapper
        {
                ClientCommunication MapBOToEF(
                        BOClientCommunication bo);

                BOClientCommunication MapEFToBO(
                        ClientCommunication efClientCommunication);

                List<BOClientCommunication> MapEFToBO(
                        List<ClientCommunication> records);
        }
}

/*<Codenesium>
    <Hash>96510037b4106000eaf884ad5610349e</Hash>
</Codenesium>*/