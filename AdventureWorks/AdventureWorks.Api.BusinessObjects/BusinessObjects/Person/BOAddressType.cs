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
			IAddressTypeModelValidator addressTypeModelValidator)
			: base(logger, addressTypeRepository, addressTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f88b7df30dde46ca3aed5975bd018b13</Hash>
</Codenesium>*/