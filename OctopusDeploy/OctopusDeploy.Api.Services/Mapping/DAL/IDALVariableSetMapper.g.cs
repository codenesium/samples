using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALVariableSetMapper
        {
                VariableSet MapBOToEF(
                        BOVariableSet bo);

                BOVariableSet MapEFToBO(
                        VariableSet efVariableSet);

                List<BOVariableSet> MapEFToBO(
                        List<VariableSet> records);
        }
}

/*<Codenesium>
    <Hash>d50e31bde7f25e2dfd7624fcb4e6e7ac</Hash>
</Codenesium>*/