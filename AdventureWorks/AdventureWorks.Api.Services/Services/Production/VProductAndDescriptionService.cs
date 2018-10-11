using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class VProductAndDescriptionService : AbstractVProductAndDescriptionService, IVProductAndDescriptionService
	{
		public VProductAndDescriptionService(
			ILogger<IVProductAndDescriptionRepository> logger,
			IVProductAndDescriptionRepository vProductAndDescriptionRepository,
			IApiVProductAndDescriptionRequestModelValidator vProductAndDescriptionModelValidator,
			IBOLVProductAndDescriptionMapper bolvProductAndDescriptionMapper,
			IDALVProductAndDescriptionMapper dalvProductAndDescriptionMapper)
			: base(logger,
			       vProductAndDescriptionRepository,
			       vProductAndDescriptionModelValidator,
			       bolvProductAndDescriptionMapper,
			       dalvProductAndDescriptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dfe6858039eabc614452c09d7c026001</Hash>
</Codenesium>*/