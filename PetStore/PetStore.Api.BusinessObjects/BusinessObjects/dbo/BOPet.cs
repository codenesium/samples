using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class BOPet:AbstractBOPet, IBOPet
	{
		public BOPet(
			ILogger<PetRepository> logger,
			IPetRepository petRepository,
			IApiPetRequestModelValidator petModelValidator,
			IBOLPetMapper petMapper)
			: base(logger, petRepository, petModelValidator, petMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>80212c54bfcd621b8a6682e25b40fd75</Hash>
</Codenesium>*/