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
			IApiPenRequestModelValidator penModelValidator,
			IBOLPenMapper penMapper)
			: base(logger, penRepository, penModelValidator, penMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3cda38c294908c91582c8243d56198ba</Hash>
</Codenesium>*/