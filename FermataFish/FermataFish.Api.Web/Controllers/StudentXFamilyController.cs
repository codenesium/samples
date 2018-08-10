using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
{
	[Route("api/studentXFamilies")]
	[ApiController]
	[ApiVersion("1.0")]
	public class StudentXFamilyController : AbstractStudentXFamilyController
	{
		public StudentXFamilyController(
			ApiSettings settings,
			ILogger<StudentXFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentXFamilyService studentXFamilyService,
			IApiStudentXFamilyModelMapper studentXFamilyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       studentXFamilyService,
			       studentXFamilyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9ece60fa6a3c232a1b48a4615fc94eac</Hash>
</Codenesium>*/