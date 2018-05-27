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
	public class TeacherRepository: AbstractTeacherRepository, ITeacherRepository
	{
		public TeacherRepository(
			IDALTeacherMapper mapper,
			ILogger<TeacherRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3ffcd7117d6afcf9ed086e8c08914cba</Hash>
</Codenesium>*/