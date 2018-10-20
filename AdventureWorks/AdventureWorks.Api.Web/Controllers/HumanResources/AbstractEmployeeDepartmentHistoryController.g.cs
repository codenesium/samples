using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractEmployeeDepartmentHistoryController : AbstractApiController
	{
		protected IEmployeeDepartmentHistoryService EmployeeDepartmentHistoryService { get; private set; }

		protected IApiEmployeeDepartmentHistoryModelMapper EmployeeDepartmentHistoryModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractEmployeeDepartmentHistoryController(
			ApiSettings settings,
			ILogger<AbstractEmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryService employeeDepartmentHistoryService,
			IApiEmployeeDepartmentHistoryModelMapper employeeDepartmentHistoryModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.EmployeeDepartmentHistoryService = employeeDepartmentHistoryService;
			this.EmployeeDepartmentHistoryModelMapper = employeeDepartmentHistoryModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeDepartmentHistoryService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiEmployeeDepartmentHistoryResponseModel response = await this.EmployeeDepartmentHistoryService.Get(id);

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
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeeDepartmentHistoryRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiEmployeeDepartmentHistoryResponseModel> records = new List<ApiEmployeeDepartmentHistoryResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.EmployeeDepartmentHistoryService.Create(model);

				if (result.Success)
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

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiEmployeeDepartmentHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.EmployeeDepartmentHistoryService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/EmployeeDepartmentHistories/{result.Record.BusinessEntityID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel> patch)
		{
			ApiEmployeeDepartmentHistoryResponseModel record = await this.EmployeeDepartmentHistoryService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiEmployeeDepartmentHistoryRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.EmployeeDepartmentHistoryService.Update(id, model);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeeDepartmentHistoryRequestModel model)
		{
			ApiEmployeeDepartmentHistoryRequestModel request = await this.PatchModel(id, this.EmployeeDepartmentHistoryModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.EmployeeDepartmentHistoryService.Update(id, request);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ActionResponse), 200)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.EmployeeDepartmentHistoryService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("byDepartmentID/{departmentID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDepartmentID(short departmentID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeDepartmentHistoryService.ByDepartmentID(departmentID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byShiftID/{shiftID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> ByShiftID(int shiftID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeDepartmentHistoryService.ByShiftID(shiftID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiEmployeeDepartmentHistoryRequestModel> PatchModel(int id, JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel> patch)
		{
			var record = await this.EmployeeDepartmentHistoryService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiEmployeeDepartmentHistoryRequestModel request = this.EmployeeDepartmentHistoryModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5de614fbc9dda45bef4b04775886a77c</Hash>
</Codenesium>*/