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
	public partial class VPersonService : AbstractVPersonService, IVPersonService
	{
		public VPersonService(
			ILogger<IVPersonRepository> logger,
			IVPersonRepository vPersonRepository,
			IApiVPersonRequestModelValidator vPersonModelValidator,
			IBOLVPersonMapper bolvPersonMapper,
			IDALVPersonMapper dalvPersonMapper
			)
			: base(logger,
			       vPersonRepository,
			       vPersonModelValidator,
			       bolvPersonMapper,
			       dalvPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>13828bc17258673ffba06f6ce89118fe</Hash>
</Codenesium>*/