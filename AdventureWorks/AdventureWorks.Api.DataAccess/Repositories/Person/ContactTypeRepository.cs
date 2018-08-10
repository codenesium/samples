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
    <Hash>cd2375c1eab55dd4424398318d000c01</Hash>
</Codenesium>*/