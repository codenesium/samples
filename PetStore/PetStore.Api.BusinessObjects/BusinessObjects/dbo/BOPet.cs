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
			IPetModelValidator petModelValidator)
			: base(logger, petRepository, petModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a4e8c3a0ab24dac2eb9f25ae47df7380</Hash>
</Codenesium>*/