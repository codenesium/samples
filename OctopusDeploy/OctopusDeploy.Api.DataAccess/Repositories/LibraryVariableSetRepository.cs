using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class LibraryVariableSetRepository : AbstractLibraryVariableSetRepository, ILibraryVariableSetRepository
        {
                public LibraryVariableSetRepository(
                        ILogger<LibraryVariableSetRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>047b5c50d4ba2f9819314c8f7b30d196</Hash>
</Codenesium>*/