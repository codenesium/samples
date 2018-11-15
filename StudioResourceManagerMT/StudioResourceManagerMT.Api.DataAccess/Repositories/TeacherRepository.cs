using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
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
    <Hash>4b835353297c6311196534a770f85bcf</Hash>
</Codenesium>*/