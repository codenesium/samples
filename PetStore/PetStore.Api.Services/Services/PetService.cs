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
	public class PetService: AbstractPetService, IPetService
	{
		public PetService(
			ILogger<PetRepository> logger,
			IPetRepository petRepository,
			IApiPetRequestModelValidator petModelValidator,
			IBOLPetMapper BOLpetMapper,
			IDALPetMapper DALpetMapper)
			: base(logger, petRepository,
			       petModelValidator,
			       BOLpetMapper,
			       DALpetMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>959727c4d5293b3c4c63472073320d78</Hash>
</Codenesium>*/