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
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator)
			: base(logger, phoneNumberTypeRepository, phoneNumberTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>55661f6ec30c7c00cab7c80360a26f47</Hash>
</Codenesium>*/