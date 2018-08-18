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
    <Hash>14ad1d03667754cecfb97b26838dbf31</Hash>
</Codenesium>*/