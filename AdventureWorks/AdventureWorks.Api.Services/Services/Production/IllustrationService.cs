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
			IDALIllustrationMapper dalillustrationMapper)
			: base(logger,
			       illustrationRepository,
			       illustrationModelValidator,
			       bolillustrationMapper,
			       dalillustrationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6f570546a28a500ce342b83f078b8950</Hash>
</Codenesium>*/