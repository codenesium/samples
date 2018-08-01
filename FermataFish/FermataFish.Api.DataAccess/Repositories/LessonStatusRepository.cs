using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class LessonStatusRepository : AbstractLessonStatusRepository, ILessonStatusRepository
	{
		public LessonStatusRepository(
			ILogger<LessonStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>869ed75ad5f0e9cd77071e9c770ca2d6</Hash>
</Codenesium>*/