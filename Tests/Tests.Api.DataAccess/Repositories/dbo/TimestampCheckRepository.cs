using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial class TimestampCheckRepository : AbstractTimestampCheckRepository, ITimestampCheckRepository
	{
		public TimestampCheckRepository(
			ILogger<TimestampCheckRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>61123a1c7decb424cbaeb32dcb29bf75</Hash>
</Codenesium>*/