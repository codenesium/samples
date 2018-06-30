using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>3a4f2c8fdaaba6af58f0b2453e6f584e</Hash>
</Codenesium>*/