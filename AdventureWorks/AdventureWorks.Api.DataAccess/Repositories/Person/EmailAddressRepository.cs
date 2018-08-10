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
	public partial class EmailAddressRepository : AbstractEmailAddressRepository, IEmailAddressRepository
	{
		public EmailAddressRepository(
			ILogger<EmailAddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>80c274b40b88771f3bc8687fd7ea24eb</Hash>
</Codenesium>*/