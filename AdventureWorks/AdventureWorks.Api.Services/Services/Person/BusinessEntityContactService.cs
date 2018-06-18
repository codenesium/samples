using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class BusinessEntityContactService: AbstractBusinessEntityContactService, IBusinessEntityContactService
        {
                public BusinessEntityContactService(
                        ILogger<IBusinessEntityContactRepository> logger,
                        IBusinessEntityContactRepository businessEntityContactRepository,
                        IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
                        IBOLBusinessEntityContactMapper bolbusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalbusinessEntityContactMapper

                        )
                        : base(logger,
                               businessEntityContactRepository,
                               businessEntityContactModelValidator,
                               bolbusinessEntityContactMapper,
                               dalbusinessEntityContactMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>06375048452fec5910cc7afb9b30393a</Hash>
</Codenesium>*/