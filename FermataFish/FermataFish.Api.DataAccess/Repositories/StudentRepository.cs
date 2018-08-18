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
    <Hash>c97450a82404cfd92e5095ad82cd6c36</Hash>
</Codenesium>*/