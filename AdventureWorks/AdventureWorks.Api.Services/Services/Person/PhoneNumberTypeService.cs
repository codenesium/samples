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
        public class PhoneNumberTypeService : AbstractPhoneNumberTypeService, IPhoneNumberTypeService
        {
                public PhoneNumberTypeService(
                        ILogger<IPhoneNumberTypeRepository> logger,
                        IPhoneNumberTypeRepository phoneNumberTypeRepository,
                        IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
                        IBOLPhoneNumberTypeMapper bolphoneNumberTypeMapper,
                        IDALPhoneNumberTypeMapper dalphoneNumberTypeMapper,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper
                        )
                        : base(logger,
                               phoneNumberTypeRepository,
                               phoneNumberTypeModelValidator,
                               bolphoneNumberTypeMapper,
                               dalphoneNumberTypeMapper,
                               bolPersonPhoneMapper,
                               dalPersonPhoneMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2489cebacfe918ef0a4076717a4ea3ed</Hash>
</Codenesium>*/