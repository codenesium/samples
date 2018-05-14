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
			IApiAddressTypeModelValidator addressTypeModelValidator)
			: base(logger, addressTypeRepository, addressTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cda4b7f52e17465d81a9af6bd2283f39</Hash>
</Codenesium>*/