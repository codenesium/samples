using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOPhoneNumberType: AbstractBOPhoneNumberType, IBOPhoneNumberType
	{
		public BOPhoneNumberType(
			ILogger<PhoneNumberTypeRepository> logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper phoneNumberTypeMapper)
			: base(logger, phoneNumberTypeRepository, phoneNumberTypeModelValidator, phoneNumberTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>9db63d71e433465bdf5eb8120d0f3c74</Hash>
</Codenesium>*/