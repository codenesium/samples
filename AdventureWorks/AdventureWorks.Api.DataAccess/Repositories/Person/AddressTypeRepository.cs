using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class AddressTypeRepository : AbstractAddressTypeRepository, IAddressTypeRepository
	{
		public AddressTypeRepository(
			ILogger<AddressTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>99f72f16f270de71bb15f6efe5073873</Hash>
</Codenesium>*/