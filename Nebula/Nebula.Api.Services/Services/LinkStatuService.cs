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
	public partial class LinkStatuService : AbstractLinkStatuService, ILinkStatuService
	{
		public LinkStatuService(
			ILogger<ILinkStatuRepository> logger,
			ILinkStatuRepository linkStatuRepository,
			IApiLinkStatuRequestModelValidator linkStatuModelValidator,
			IBOLLinkStatuMapper bollinkStatuMapper,
			IDALLinkStatuMapper dallinkStatuMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper
			)
			: base(logger,
			       linkStatuRepository,
			       linkStatuModelValidator,
			       bollinkStatuMapper,
			       dallinkStatuMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c6dbbb79d475c084d93e9f90ee7a5467</Hash>
</Codenesium>*/