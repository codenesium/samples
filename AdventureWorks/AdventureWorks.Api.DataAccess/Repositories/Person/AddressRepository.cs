using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class AddressRepository : AbstractAddressRepository, IAddressRepository
        {
                public AddressRepository(
                        ILogger<AddressRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>95cfb8da70f25f655c3660e92b3bc572</Hash>
</Codenesium>*/