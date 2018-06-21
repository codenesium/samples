using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>b7577a43e6476606623c19d757e7e89d</Hash>
</Codenesium>*/