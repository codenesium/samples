using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>493418a66928842283b9ec3b9fc55910</Hash>
</Codenesium>*/