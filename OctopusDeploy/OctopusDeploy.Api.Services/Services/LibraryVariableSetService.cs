using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class LibraryVariableSetService : AbstractLibraryVariableSetService, ILibraryVariableSetService
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
                               dallibraryVariableSetMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce8a7f1464e2633bb7398550943f0b5f</Hash>
</Codenesium>*/