using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c8bb16f1f180e304c9d93ee209fddb5f</Hash>
</Codenesium>*/