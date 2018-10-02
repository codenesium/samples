using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial class SysdiagramRepository : AbstractSysdiagramRepository, ISysdiagramRepository
	{
		public SysdiagramRepository(
			ILogger<SysdiagramRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0771161955c6bec494362c4bac298ff6</Hash>
</Codenesium>*/