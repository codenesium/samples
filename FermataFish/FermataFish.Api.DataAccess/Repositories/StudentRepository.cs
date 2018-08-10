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
	public partial class StudentRepository : AbstractStudentRepository, IStudentRepository
	{
		public StudentRepository(
			ILogger<StudentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>03e0793d0e01e3c97ae9a36688eac0b0</Hash>
</Codenesium>*/