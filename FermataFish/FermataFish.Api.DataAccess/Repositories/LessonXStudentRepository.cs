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
    <Hash>f16c2cb5631951a61780dfcbe2116f7f</Hash>
</Codenesium>*/