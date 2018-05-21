using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractDepartmentController: AbstractApiController
	{
		protected IBODepartment departmentManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractDepartmentController(
			ServiceSettings settings,
			ILogger<AbstractDepartmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODepartment departmentManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.departmentManager = departmentManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCODepartment>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCODepartment> response = await this.departmentManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCODepartment), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(short id)
		{
			POCODepartment response = await this.departmentManager.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCODepartment), 200)]
		[ProducesResponseType(typeof(CreateResponse<short>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDepartmentModel model)
		{
			CreateResponse<POCODepartment> result = await this.departmentManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.DepartmentID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Departments/{result.Record.DepartmentID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<POCODepartment>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDepartmentModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCODepartment> records = new List<POCODepartment>();
			foreach (var model in models)
			{
				CreateResponse<POCODepartment> result = await this.departmentManager.Create(model);

				if(result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCODepartment), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(short id, [FromBody] ApiDepartmentModel model)
		{
			try
			{
				ActionResponse result = await this.departmentManager.Update(id, model);

				if (result.Success)
				{
					POCODepartment response = await this.departmentManager.Get(id);

					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(short id)
		{
			ActionResponse result = await this.departmentManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("getName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCODepartment), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> GetName(string name)
		{
			POCODepartment response = await this.departmentManager.GetName(name);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}
	}
}

/*<Codenesium>
    <Hash>3b9808a6fc2f046801257164a54679ad</Hash>
</Codenesium>*/