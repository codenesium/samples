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
	public partial class LessonStatusRepository : AbstractLessonStatusRepository, ILessonStatusRepository
	{
		public LessonStatusRepository(
			ILogger<LessonStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f909f38c0b1420ee6fee9db72cda9d9</Hash>
</Codenesium>*/