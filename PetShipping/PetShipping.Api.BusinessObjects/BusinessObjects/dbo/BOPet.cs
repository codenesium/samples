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
			IPetModelValidator petModelValidator)
			: base(logger, petRepository, petModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b84fed3dea05bbf80fa7c4f56fd81a18</Hash>
</Codenesium>*/