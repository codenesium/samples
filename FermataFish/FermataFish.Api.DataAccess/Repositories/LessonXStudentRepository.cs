using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>108ed62a41955565423242c196fdb347</Hash>
</Codenesium>*/