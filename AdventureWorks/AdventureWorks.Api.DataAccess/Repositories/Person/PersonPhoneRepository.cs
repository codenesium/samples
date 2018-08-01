using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PersonPhoneRepository : AbstractPersonPhoneRepository, IPersonPhoneRepository
	{
		public PersonPhoneRepository(
			ILogger<PersonPhoneRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fadd1d331c297454fb3e68a29b876b8f</Hash>
</Codenesium>*/