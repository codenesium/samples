using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class AddressRepository : AbstractAddressRepository, IAddressRepository
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
    <Hash>74112467fae15d52b8bd63443a621bce</Hash>
</Codenesium>*/