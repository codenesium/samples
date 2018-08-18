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
    <Hash>0b1a09772c5cc9050b0d5ef46dc515f3</Hash>
</Codenesium>*/