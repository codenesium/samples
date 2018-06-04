using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class LessonXStudentRepository: AbstractLessonXStudentRepository, ILessonXStudentRepository
	{
		public LessonXStudentRepository(
			ILogger<LessonXStudentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fb7e350c5edb8db5d6757a29bc7cc288</Hash>
</Codenesium>*/