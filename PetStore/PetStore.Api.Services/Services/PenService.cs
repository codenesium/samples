using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
			IDALPetMapper dalPetMapper
			)
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
    <Hash>79107770fbc7c0d0df016ed549ccca85</Hash>
</Codenesium>*/