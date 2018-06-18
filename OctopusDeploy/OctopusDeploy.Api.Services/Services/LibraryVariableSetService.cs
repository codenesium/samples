using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class LibraryVariableSetService: AbstractLibraryVariableSetService, ILibraryVariableSetService
        {
                public LibraryVariableSetService(
                        ILogger<ILibraryVariableSetRepository> logger,
                        ILibraryVariableSetRepository libraryVariableSetRepository,
                        IApiLibraryVariableSetRequestModelValidator libraryVariableSetModelValidator,
                        IBOLLibraryVariableSetMapper bollibraryVariableSetMapper,
                        IDALLibraryVariableSetMapper dallibraryVariableSetMapper

                        )
                        : base(logger,
                               libraryVariableSetRepository,
                               libraryVariableSetModelValidator,
                               bollibraryVariableSetMapper,
                               dallibraryVariableSetMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d303a98eac81c5c1b0d04b007e2dab22</Hash>
</Codenesium>*/