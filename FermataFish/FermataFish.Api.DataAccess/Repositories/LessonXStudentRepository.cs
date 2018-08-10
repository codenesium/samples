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
	public partial class LessonXStudentRepository : AbstractLessonXStudentRepository, ILessonXStudentRepository
	{
		public LessonXStudentRepository(
			ILogger<LessonXStudentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ca0ccabb96fc4900047d78d905d769df</Hash>
</Codenesium>*/