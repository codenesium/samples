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
			ILogger<PhoneNumberTypeRepository> logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper BOLphoneNumberTypeMapper,
			IDALPhoneNumberTypeMapper DALphoneNumberTypeMapper)
			: base(logger, phoneNumberTypeRepository,
			       phoneNumberTypeModelValidator,
			       BOLphoneNumberTypeMapper,
			       DALphoneNumberTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e4ae2d259c98b34a22d0f7cd88a5bb4e</Hash>
</Codenesium>*/