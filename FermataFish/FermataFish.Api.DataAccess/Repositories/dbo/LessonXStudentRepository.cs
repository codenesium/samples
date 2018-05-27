using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class LessonXStudentRepository: AbstractLessonXStudentRepository, ILessonXStudentRepository
	{
		public LessonXStudentRepository(
			IDALLessonXStudentMapper mapper,
			ILogger<LessonXStudentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c51886f305bdf6ed3b4d218ee75194f5</Hash>
</Codenesium>*/