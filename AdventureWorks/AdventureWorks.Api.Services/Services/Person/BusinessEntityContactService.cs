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
                        ILogger<BusinessEntityContactRepository> logger,
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
    <Hash>996f63b0a4c632d0d2aa610b0381ff72</Hash>
</Codenesium>*/