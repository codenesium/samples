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
	public partial class PasswordRepository : AbstractPasswordRepository, IPasswordRepository
	{
		public PasswordRepository(
			ILogger<PasswordRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>643d6239587b95257dafb0db75e46402</Hash>
</Codenesium>*/