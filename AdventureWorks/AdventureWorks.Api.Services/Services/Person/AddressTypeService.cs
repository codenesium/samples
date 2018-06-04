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
	public class AddressTypeService: AbstractAddressTypeService, IAddressTypeService
	{
		public AddressTypeService(
			ILogger<AddressTypeRepository> logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper BOLaddressTypeMapper,
			IDALAddressTypeMapper DALaddressTypeMapper)
			: base(logger, addressTypeRepository,
			       addressTypeModelValidator,
			       BOLaddressTypeMapper,
			       DALaddressTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>db9a05a9390518576ed217e683c54b84</Hash>
</Codenesium>*/