using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class LibraryVariableSetRepository : AbstractLibraryVariableSetRepository, ILibraryVariableSetRepository
	{
		public LibraryVariableSetRepository(
			ILogger<LibraryVariableSetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e973dd2a8f65fd6c73076060ffa56ed1</Hash>
</Codenesium>*/