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
	public partial class IllustrationService : AbstractIllustrationService, IIllustrationService
	{
		public IllustrationService(
			ILogger<IIllustrationRepository> logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper bolillustrationMapper,
			IDALIllustrationMapper dalillustrationMapper,
			IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
			IDALProductModelIllustrationMapper dalProductModelIllustrationMapper
			)
			: base(logger,
			       illustrationRepository,
			       illustrationModelValidator,
			       bolillustrationMapper,
			       dalillustrationMapper,
			       bolProductModelIllustrationMapper,
			       dalProductModelIllustrationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f80c165df6c9f3e733002df4ef5a518</Hash>
</Codenesium>*/