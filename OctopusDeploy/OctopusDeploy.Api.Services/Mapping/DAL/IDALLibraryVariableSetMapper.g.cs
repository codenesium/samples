using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a38a32240c02cc4df238d604e7df5a6b</Hash>
</Codenesium>*/