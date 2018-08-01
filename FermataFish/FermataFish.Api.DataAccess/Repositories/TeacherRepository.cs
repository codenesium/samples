using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class TeacherRepository : AbstractTeacherRepository, ITeacherRepository
	{
		public TeacherRepository(
			ILogger<TeacherRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3e77324bafad5b1861962a11f08cb42a</Hash>
</Codenesium>*/