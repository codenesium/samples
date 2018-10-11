using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class StudentService : AbstractStudentService, IStudentService
	{
		public StudentService(
			ILogger<IStudentRepository> logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolstudentMapper,
			IDALStudentMapper dalstudentMapper,
			IBOLEventStudentMapper bolEventStudentMapper,
			IDALEventStudentMapper dalEventStudentMapper)
			: base(logger,
			       studentRepository,
			       studentModelValidator,
			       bolstudentMapper,
			       dalstudentMapper,
			       bolEventStudentMapper,
			       dalEventStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8833e0c9a79d7f366852203a48ef7e14</Hash>
</Codenesium>*/