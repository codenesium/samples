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
                        IDALBusinessEntityContactMapper dalbusinessEntityContactMapper)
                        : base(logger,
                               businessEntityContactRepository,
                               businessEntityContactModelValidator,
                               bolbusinessEntityContactMapper,
                               dalbusinessEntityContactMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a3c3fe3a26cbdb30a3c4341f352615a5</Hash>
</Codenesium>*/