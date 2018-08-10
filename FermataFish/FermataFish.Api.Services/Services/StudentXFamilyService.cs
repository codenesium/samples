using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class StudentXFamilyService : AbstractStudentXFamilyService, IStudentXFamilyService
	{
		public StudentXFamilyService(
			ILogger<IStudentXFamilyRepository> logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
			IBOLStudentXFamilyMapper bolstudentXFamilyMapper,
			IDALStudentXFamilyMapper dalstudentXFamilyMapper
			)
			: base(logger,
			       studentXFamilyRepository,
			       studentXFamilyModelValidator,
			       bolstudentXFamilyMapper,
			       dalstudentXFamilyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ceda09c5904ba5dce4f91f919a925474</Hash>
</Codenesium>*/