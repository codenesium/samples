using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial class PenService : AbstractPenService, IPenService
	{
		public PenService(
			ILogger<IPenRepository> logger,
			IPenRepository penRepository,
			IApiPenRequestModelValidator penModelValidator,
			IBOLPenMapper bolpenMapper,
			IDALPenMapper dalpenMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       penRepository,
			       penModelValidator,
			       bolpenMapper,
			       dalpenMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0f95014b02611ea1b12de75b569ff27a</Hash>
</Codenesium>*/