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
    <Hash>a9f6314c05f7a8a6b48bae40fbc5337b</Hash>
</Codenesium>*/