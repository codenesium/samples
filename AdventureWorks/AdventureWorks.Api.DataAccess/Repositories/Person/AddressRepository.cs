using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class AddressRepository: AbstractAddressRepository, IAddressRepository
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
    <Hash>ee1f30826e223bf6304fddcd18452c82</Hash>
</Codenesium>*/