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
	public class BOPen:AbstractBOPen, IBOPen
	{
		public BOPen(
			ILogger<PenRepository> logger,
			IPenRepository penRepository,
			IApiPenModelValidator penModelValidator)
			: base(logger, penRepository, penModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>734454723ad11f8d94f04af6b1c0f8f4</Hash>
</Codenesium>*/