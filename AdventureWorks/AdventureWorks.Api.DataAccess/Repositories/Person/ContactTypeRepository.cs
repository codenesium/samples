using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>3cb95ef239ca8d499294b890f167afde</Hash>
</Codenesium>*/