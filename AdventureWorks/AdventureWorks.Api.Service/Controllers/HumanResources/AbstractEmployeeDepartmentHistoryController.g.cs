using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractEmployeeDepartmentHistoryController: AbstractApiController
	{
		protected IBOEmployeeDepartmentHistory employeeDepartmentHistoryManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractEmployeeDepartmentHistoryController(
			ILogger<AbstractEmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployeeDepartmentHistory employeeDepartmentHistoryManager
			)
			: base(logger, transactionCoordinator)
		{
			this.employeeDepartmentHistoryManager = employeeDepartmentHistoryManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.employeeDepartmentHistoryManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.employeeDepartmentHistoryManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] EmployeeDepartmentHistoryModel model)
		{
			var result = await this.employeeDepartmentHistoryManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<EmployeeDepartmentHistoryModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.employeeDepartmentHistoryManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] EmployeeDepartmentHistoryModel model)
		{
			var result = await this.employeeDepartmentHistoryManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.employeeDepartmentHistoryManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.employeeDepartmentHistoryManager.GetWhere(x => x.BusinessEntityID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByDepartmentID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Departments/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByDepartmentID(short id)
		{
			ApiResponse response = this.employeeDepartmentHistoryManager.GetWhere(x => x.DepartmentID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShiftID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Shifts/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShiftID(int id)
		{
			ApiResponse response = this.employeeDepartmentHistoryManager.GetWhere(x => x.ShiftID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1c04a936c05cc0f0265a386d17d719b5</Hash>
</Codenesium>*/