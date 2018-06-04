using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public class PenService: AbstractPenService, IPenService
	{
		public PenService(
			ILogger<PenRepository> logger,
			IPenRepository penRepository,
			IApiPenRequestModelValidator penModelValidator,
			IBOLPenMapper BOLpenMapper,
			IDALPenMapper DALpenMapper)
			: base(logger, penRepository,
			       penModelValidator,
			       BOLpenMapper,
			       DALpenMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ad53484d0352b46cf3363769deb016b8</Hash>
</Codenesium>*/