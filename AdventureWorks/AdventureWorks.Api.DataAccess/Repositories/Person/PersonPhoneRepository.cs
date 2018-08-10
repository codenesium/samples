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
    <Hash>341c484cef26d7e30a1bc6c3586fc834</Hash>
</Codenesium>*/