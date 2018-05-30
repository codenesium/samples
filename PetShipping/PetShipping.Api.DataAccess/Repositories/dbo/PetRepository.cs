using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class PetRepository: AbstractPetRepository, IPetRepository
	{
		public PetRepository(
			IDALPetMapper mapper,
			ILogger<PetRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>089824570bd797b9798b4f932536907e</Hash>
</Codenesium>*/