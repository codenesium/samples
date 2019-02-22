using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial class AddressRepository : AbstractAddressRepository, IAddressRepository
	{
		public AddressRepository(
			ILogger<AddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>33d5a188e00bb537d1ebf54e6bd833df</Hash>
</Codenesium>*/