using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>cd64f59d42a09bd1fa5668a9cbbccf88</Hash>
</Codenesium>*/