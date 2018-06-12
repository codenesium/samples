using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class LibraryVariableSetRepository: AbstractLibraryVariableSetRepository, ILibraryVariableSetRepository
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
    <Hash>abbffd288a8e86d035bb138d188c8fcf</Hash>
</Codenesium>*/