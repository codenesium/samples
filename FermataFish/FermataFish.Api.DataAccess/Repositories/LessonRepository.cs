using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class LessonRepository : AbstractLessonRepository, ILessonRepository
	{
		public LessonRepository(
			ILogger<LessonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9f5ea12dcb6c3eeac638a4b028fac950</Hash>
</Codenesium>*/