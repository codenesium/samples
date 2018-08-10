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
    <Hash>8b9cd1ba4599651ac550d488c44ecc56</Hash>
</Codenesium>*/