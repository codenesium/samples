using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class BusinessEntityContactService : AbstractBusinessEntityContactService, IBusinessEntityContactService
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
                               dalbusinessEntityContactMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6b64ed103ad5bad57027d89f8bbf43e1</Hash>
</Codenesium>*/