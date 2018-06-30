using Codenesium.DataConversionExtensions;
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
        public partial class LibraryVariableSetService : AbstractLibraryVariableSetService, ILibraryVariableSetService
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
    <Hash>24e966981d01c2695958ed2d2562b49c</Hash>
</Codenesium>*/