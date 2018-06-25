using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class PhoneNumberTypeRepository : AbstractPhoneNumberTypeRepository, IPhoneNumberTypeRepository
        {
                public PhoneNumberTypeRepository(
                        ILogger<PhoneNumberTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8f835f57d87c2bcecc5c5fe33b2ca0a4</Hash>
</Codenesium>*/