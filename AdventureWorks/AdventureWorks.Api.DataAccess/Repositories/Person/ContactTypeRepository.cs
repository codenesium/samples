using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ContactTypeRepository: AbstractContactTypeRepository, IContactTypeRepository
	{
		public ContactTypeRepository(
			IDALContactTypeMapper mapper,
			ILogger<ContactTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b1c42d120f6292fa297f7badbb2f2df2</Hash>
</Codenesium>*/