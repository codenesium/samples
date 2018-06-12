using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALLibraryVariableSetMapper
        {
                LibraryVariableSet MapBOToEF(
                        BOLibraryVariableSet bo);

                BOLibraryVariableSet MapEFToBO(
                        LibraryVariableSet efLibraryVariableSet);

                List<BOLibraryVariableSet> MapEFToBO(
                        List<LibraryVariableSet> records);
        }
}

/*<Codenesium>
    <Hash>c8f732907d78e1e6862cad8dafdaf70f</Hash>
</Codenesium>*/