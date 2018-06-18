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
        public class PhoneNumberTypeService: AbstractPhoneNumberTypeService, IPhoneNumberTypeService
        {
                public PhoneNumberTypeService(
                        ILogger<IPhoneNumberTypeRepository> logger,
                        IPhoneNumberTypeRepository phoneNumberTypeRepository,
                        IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
                        IBOLPhoneNumberTypeMapper bolphoneNumberTypeMapper,
                        IDALPhoneNumberTypeMapper dalphoneNumberTypeMapper
                        ,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper

                        )
                        : base(logger,
                               phoneNumberTypeRepository,
                               phoneNumberTypeModelValidator,
                               bolphoneNumberTypeMapper,
                               dalphoneNumberTypeMapper
                               ,
                               bolPersonPhoneMapper,
                               dalPersonPhoneMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e006cd60124782c9170cce748aa44746</Hash>
</Codenesium>*/