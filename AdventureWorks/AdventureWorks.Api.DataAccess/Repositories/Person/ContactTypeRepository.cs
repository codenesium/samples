using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ContactTypeRepository: AbstractContactTypeRepository, IContactTypeRepository
	{
		public ContactTypeRepository(
			ILogger<ContactTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>5f99f2012949d6fa5e2c79b72b02faa4</Hash>
</Codenesium>*/