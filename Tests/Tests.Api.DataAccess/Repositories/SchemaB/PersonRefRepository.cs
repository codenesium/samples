using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class PersonRefRepository : AbstractPersonRefRepository, IPersonRefRepository
	{
		public PersonRefRepository(
			ILogger<PersonRefRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9032fb7c2d7e7da27767b5adc7f9d0bc</Hash>
</Codenesium>*/