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
			IApiPetModelValidator petModelValidator)
			: base(logger, petRepository, petModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2196f1eaf166873986038eab78e51621</Hash>
</Codenesium>*/