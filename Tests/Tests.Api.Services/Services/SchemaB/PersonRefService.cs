using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class PersonRefService : AbstractPersonRefService, IPersonRefService
	{
		public PersonRefService(
			ILogger<IPersonRefRepository> logger,
			IPersonRefRepository personRefRepository,
			IApiPersonRefRequestModelValidator personRefModelValidator,
			IBOLPersonRefMapper bolpersonRefMapper,
			IDALPersonRefMapper dalpersonRefMapper)
			: base(logger,
			       personRefRepository,
			       personRefModelValidator,
			       bolpersonRefMapper,
			       dalpersonRefMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8411a4e70a25a0a46c9187971b8eeb54</Hash>
</Codenesium>*/