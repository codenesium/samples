using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class TeacherRepository: AbstractTeacherRepository, ITeacherRepository
	{
		public TeacherRepository(
			ILogger<TeacherRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>af1edf3b47257616b6f13a7a82caf866</Hash>
</Codenesium>*/