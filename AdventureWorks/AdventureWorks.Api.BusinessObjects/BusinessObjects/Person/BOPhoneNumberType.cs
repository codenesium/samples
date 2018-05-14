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
			IApiPhoneNumberTypeModelValidator phoneNumberTypeModelValidator)
			: base(logger, phoneNumberTypeRepository, phoneNumberTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7c4c53ad3affce79bb4c06d893928feb</Hash>
</Codenesium>*/