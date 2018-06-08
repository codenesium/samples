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
        public class ContactTypeService: AbstractContactTypeService, IContactTypeService
        {
                public ContactTypeService(
                        ILogger<ContactTypeRepository> logger,
                        IContactTypeRepository contactTypeRepository,
                        IApiContactTypeRequestModelValidator contactTypeModelValidator,
                        IBOLContactTypeMapper bolcontactTypeMapper,
                        IDALContactTypeMapper dalcontactTypeMapper)
                        : base(logger,
                               contactTypeRepository,
                               contactTypeModelValidator,
                               bolcontactTypeMapper,
                               dalcontactTypeMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8409063baa538f4a5a5f3e0c8feb5246</Hash>
</Codenesium>*/