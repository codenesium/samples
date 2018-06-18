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
                        ILogger<IContactTypeRepository> logger,
                        IContactTypeRepository contactTypeRepository,
                        IApiContactTypeRequestModelValidator contactTypeModelValidator,
                        IBOLContactTypeMapper bolcontactTypeMapper,
                        IDALContactTypeMapper dalcontactTypeMapper
                        ,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper

                        )
                        : base(logger,
                               contactTypeRepository,
                               contactTypeModelValidator,
                               bolcontactTypeMapper,
                               dalcontactTypeMapper
                               ,
                               bolBusinessEntityContactMapper,
                               dalBusinessEntityContactMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>5ff6eb43393fd6cd53b6c8cdf63b5495</Hash>
</Codenesium>*/