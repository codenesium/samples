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
                        ILogger<LibraryVariableSetRepository> logger,
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
    <Hash>80345e3f105f3f911622f7da12f20406</Hash>
</Codenesium>*/