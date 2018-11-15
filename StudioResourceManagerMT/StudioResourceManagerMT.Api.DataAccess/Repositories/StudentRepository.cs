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
    <Hash>79b88e62a9c0e3d4db68059f5d55a4bd</Hash>
</Codenesium>*/