using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	[Route("api/employees")]
	[ApiController]
	[ApiVersion("1.0")]

	public class EmployeeController : AbstractApiController
	{
		protected IEmployeeService EmployeeService { get; private set; }

		protected IApiEmployeeServerModelMapper EmployeeModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public EmployeeController(
			ApiSettings settings,
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeService employeeService,
			IApiEmployeeServerModelMapper employeeModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.EmployeeService = employeeService;
			this.EmployeeModelMapper = employeeModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiEmployeeServerResponseModel> response = await this.EmployeeService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiEmployeeServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiEmployeeServerResponseModel response = await this.EmployeeService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiEmployeeServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeeServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiEmployeeServerResponseModel> records = new List<ApiEmployeeServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiEmployeeServerResponseModel> result = await this.EmployeeService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiEmployeeServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiEmployeeServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiEmployeeServerRequestModel model)
		{
			CreateResponse<ApiEmployeeServerResponseModel> result = await this.EmployeeService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Employees/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiEmployeeServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiEmployeeServerRequestModel> patch)
		{
			ApiEmployeeServerResponseModel record = await this.EmployeeService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiEmployeeServerRequestModel model = await this.PatchModel(id, patch) as ApiEmployeeServerRequestModel;

				UpdateResponse<ApiEmployeeServerResponseModel> result = await this.EmployeeService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiEmployeeServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeeServerRequestModel model)
		{
			ApiEmployeeServerRequestModel request = await this.PatchModel(id, this.EmployeeModelMapper.CreatePatch(model)) as ApiEmployeeServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiEmployeeServerResponseModel> result = await this.EmployeeService.Update(id, request);

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
			ActionResponse result = await this.EmployeeService.Delete(id);

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
		[Route("{employeeId}/CustomerCommunications")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCustomerCommunicationServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CustomerCommunicationsByEmployeeId(int employeeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCustomerCommunicationServerResponseModel> response = await this.EmployeeService.CustomerCommunicationsByEmployeeId(employeeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{shipperId}/PipelineSteps")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepsByShipperId(int shipperId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineStepServerResponseModel> response = await this.EmployeeService.PipelineStepsByShipperId(shipperId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{employeeId}/PipelineStepNotes")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepNoteServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepNotesByEmployeeId(int employeeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineStepNoteServerResponseModel> response = await this.EmployeeService.PipelineStepNotesByEmployeeId(employeeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiEmployeeServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiEmployeeServerRequestModel> patch)
		{
			var record = await this.EmployeeService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiEmployeeServerRequestModel request = this.EmployeeModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f5a39c4d858530a6abb51db51761e16c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/