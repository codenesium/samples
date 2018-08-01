using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class StudentXFamilyRepository : AbstractStudentXFamilyRepository, IStudentXFamilyRepository
	{
		public StudentXFamilyRepository(
			ILogger<StudentXFamilyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>73d93fbc4c6a2673225aa623fe97cbf3</Hash>
</Codenesium>*/