using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALEventMapper
        {
                Event MapBOToEF(
                        BOEvent bo);

                BOEvent MapEFToBO(
                        Event efEvent);

                List<BOEvent> MapEFToBO(
                        List<Event> records);
        }
}

/*<Codenesium>
    <Hash>4f6ce76fb637ebd6aa392594eef98296</Hash>
</Codenesium>*/