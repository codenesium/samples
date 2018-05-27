using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PasswordRepository: AbstractPasswordRepository, IPasswordRepository
	{
		public PasswordRepository(
			IDALPasswordMapper mapper,
			ILogger<PasswordRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>a468486a024a2cfdcdd3527aabe7ebd7</Hash>
</Codenesium>*/