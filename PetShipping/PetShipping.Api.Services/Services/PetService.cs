using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>ba5e01628c12b126d30dd7c787a851ae</Hash>
</Codenesium>*/