using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class DestinationRepository : AbstractDestinationRepository, IDestinationRepository
        {
                public DestinationRepository(
                        ILogger<DestinationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>41ea065fd51b53c490a04ba371150f89</Hash>
</Codenesium>*/