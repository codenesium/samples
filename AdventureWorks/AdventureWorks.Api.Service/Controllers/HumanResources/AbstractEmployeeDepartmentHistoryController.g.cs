using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractEmployeeDepartmentHistoryController: AbstractApiController
	{
		protected IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractEmployeeDepartmentHistoryController(
			ILogger<AbstractEmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.employeeDepartmentHistoryRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
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
			ApiResponse response = this.employeeDepartmentHistoryRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] EmployeeDepartmentHistoryModel model)
		{
			var id = this.employeeDepartmentHistoryRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<EmployeeDepartmentHistoryModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.employeeDepartmentHistoryRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] EmployeeDepartmentHistoryModel model)
		{
			this.employeeDepartmentHistoryRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.employeeDepartmentHistoryRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.employeeDepartmentHistoryRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByDepartmentID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Departments/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByDepartmentID(short id)
		{
			ApiResponse response = this.employeeDepartmentHistoryRepository.GetWhere(x => x.DepartmentID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShiftID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Shifts/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShiftID(int id)
		{
			ApiResponse response = this.employeeDepartmentHistoryRepository.GetWhere(x => x.ShiftID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>116fdf3565f4b6304399235bebc367b5</Hash>
</Codenesium>*/