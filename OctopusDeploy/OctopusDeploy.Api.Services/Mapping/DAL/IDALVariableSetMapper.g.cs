using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>d0f1dbf90e72ef14c8b242bd1e923c53</Hash>
</Codenesium>*/