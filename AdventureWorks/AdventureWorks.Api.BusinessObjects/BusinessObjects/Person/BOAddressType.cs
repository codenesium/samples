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
	public class BOAddressType: AbstractBOAddressType, IBOAddressType
	{
		public BOAddressType(
			ILogger<AddressTypeRepository> logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper addressTypeMapper)
			: base(logger, addressTypeRepository, addressTypeModelValidator, addressTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4be7f69efcc6b8adb292231df7396d10</Hash>
</Codenesium>*/