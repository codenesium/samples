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
	public partial class LessonXTeacherRepository : AbstractLessonXTeacherRepository, ILessonXTeacherRepository
	{
		public LessonXTeacherRepository(
			ILogger<LessonXTeacherRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>413398d8c963db66ace9f591cfcfc1ad</Hash>
</Codenesium>*/