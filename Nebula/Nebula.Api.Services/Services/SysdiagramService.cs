using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class SysdiagramService : AbstractSysdiagramService, ISysdiagramService
	{
		public SysdiagramService(
			ILogger<ISysdiagramRepository> logger,
			ISysdiagramRepository sysdiagramRepository,
			IApiSysdiagramRequestModelValidator sysdiagramModelValidator,
			IBOLSysdiagramMapper bolsysdiagramMapper,
			IDALSysdiagramMapper dalsysdiagramMapper
			)
			: base(logger,
			       sysdiagramRepository,
			       sysdiagramModelValidator,
			       bolsysdiagramMapper,
			       dalsysdiagramMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>10cfa4b8bbfe19ee4eb93104359530f2</Hash>
</Codenesium>*/