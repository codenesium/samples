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
    <Hash>6a9c627bcd153b033f3f50a071ff2965</Hash>
</Codenesium>*/