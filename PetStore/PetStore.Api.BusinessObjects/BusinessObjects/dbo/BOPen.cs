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
			IPenModelValidator penModelValidator)
			: base(logger, penRepository, penModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>06306434d0335b0c09758c2609a3af90</Hash>
</Codenesium>*/