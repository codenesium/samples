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
	public partial class CompositePrimaryKeyService : AbstractCompositePrimaryKeyService, ICompositePrimaryKeyService
	{
		public CompositePrimaryKeyService(
			ILogger<ICompositePrimaryKeyRepository> logger,
			ICompositePrimaryKeyRepository compositePrimaryKeyRepository,
			IApiCompositePrimaryKeyRequestModelValidator compositePrimaryKeyModelValidator,
			IBOLCompositePrimaryKeyMapper bolcompositePrimaryKeyMapper,
			IDALCompositePrimaryKeyMapper dalcompositePrimaryKeyMapper)
			: base(logger,
			       compositePrimaryKeyRepository,
			       compositePrimaryKeyModelValidator,
			       bolcompositePrimaryKeyMapper,
			       dalcompositePrimaryKeyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e86e56d6f3884ceaa6fdd8f898be99b1</Hash>
</Codenesium>*/