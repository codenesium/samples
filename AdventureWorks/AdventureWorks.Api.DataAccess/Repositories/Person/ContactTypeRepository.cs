using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ContactTypeRepository : AbstractContactTypeRepository, IContactTypeRepository
	{
		public ContactTypeRepository(
			ILogger<ContactTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>56348a9e0f3bc5d84f6e1f5a1bbe3482</Hash>
</Codenesium>*/