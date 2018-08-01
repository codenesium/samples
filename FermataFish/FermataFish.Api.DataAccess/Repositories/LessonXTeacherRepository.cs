using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>b4d0fa5b9902408e3452810025452086</Hash>
</Codenesium>*/