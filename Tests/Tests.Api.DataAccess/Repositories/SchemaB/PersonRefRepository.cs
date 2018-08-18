using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>1441490a9ab494cc5ae7cdae25ca3663</Hash>
</Codenesium>*/