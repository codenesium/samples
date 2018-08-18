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
    <Hash>398861af88acf01ed9881f279a63167a</Hash>
</Codenesium>*/