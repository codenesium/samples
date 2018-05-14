using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOPet:AbstractBOPet, IBOPet
	{
		public BOPet(
			ILogger<PetRepository> logger,
			IPetRepository petRepository,
			IApiPetModelValidator petModelValidator)
			: base(logger, petRepository, petModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>69c14882d5ba66a1871004a08587a161</Hash>
</Codenesium>*/