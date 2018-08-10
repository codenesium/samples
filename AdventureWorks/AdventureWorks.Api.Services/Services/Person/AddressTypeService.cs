using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class AddressTypeService : AbstractAddressTypeService, IAddressTypeService
	{
		public AddressTypeService(
			ILogger<IAddressTypeRepository> logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper boladdressTypeMapper,
			IDALAddressTypeMapper daladdressTypeMapper,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
			)
			: base(logger,
			       addressTypeRepository,
			       addressTypeModelValidator,
			       boladdressTypeMapper,
			       daladdressTypeMapper,
			       bolBusinessEntityAddressMapper,
			       dalBusinessEntityAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>da2925e7ff9934b32aa06d4d03d2e06f</Hash>
</Codenesium>*/