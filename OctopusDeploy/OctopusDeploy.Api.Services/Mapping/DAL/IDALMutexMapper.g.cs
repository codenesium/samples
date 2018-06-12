using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALMutexMapper
        {
                Mutex MapBOToEF(
                        BOMutex bo);

                BOMutex MapEFToBO(
                        Mutex efMutex);

                List<BOMutex> MapEFToBO(
                        List<Mutex> records);
        }
}

/*<Codenesium>
    <Hash>1512ddb6f25ae7d2c29b6cb70d4f9838</Hash>
</Codenesium>*/