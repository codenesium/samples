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
        public class ContactTypeService : AbstractContactTypeService, IContactTypeService
        {
                public ContactTypeService(
                        ILogger<IContactTypeRepository> logger,
                        IContactTypeRepository contactTypeRepository,
                        IApiContactTypeRequestModelValidator contactTypeModelValidator,
                        IBOLContactTypeMapper bolcontactTypeMapper,
                        IDALContactTypeMapper dalcontactTypeMapper,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper
                        )
                        : base(logger,
                               contactTypeRepository,
                               contactTypeModelValidator,
                               bolcontactTypeMapper,
                               dalcontactTypeMapper,
                               bolBusinessEntityContactMapper,
                               dalBusinessEntityContactMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>21a3baeed476c079ed8909588ffdab02</Hash>
</Codenesium>*/