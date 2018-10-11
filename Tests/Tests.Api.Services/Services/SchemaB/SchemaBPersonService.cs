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
	public partial class SchemaBPersonService : AbstractSchemaBPersonService, ISchemaBPersonService
	{
		public SchemaBPersonService(
			ILogger<ISchemaBPersonRepository> logger,
			ISchemaBPersonRepository schemaBPersonRepository,
			IApiSchemaBPersonRequestModelValidator schemaBPersonModelValidator,
			IBOLSchemaBPersonMapper bolschemaBPersonMapper,
			IDALSchemaBPersonMapper dalschemaBPersonMapper)
			: base(logger,
			       schemaBPersonRepository,
			       schemaBPersonModelValidator,
			       bolschemaBPersonMapper,
			       dalschemaBPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>57824ee2d9e1beb2c9e07fa6b2344257</Hash>
</Codenesium>*/