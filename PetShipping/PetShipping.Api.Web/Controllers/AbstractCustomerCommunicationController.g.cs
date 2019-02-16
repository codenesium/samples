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
	public abstract class AbstractCustomerCommunicationController : AbstractApiController
	{
		protected ICustomerCommunicationService CustomerCommunicationService { get; private set; }

		protected IApiCustomerCommunicationServerModelMapper CustomerCommunicationModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCustomerCommunicationController(
			ApiSettings settings,
			ILogger<AbstractCustomerCommunicationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerCommunicationService customerCommunicationService,
			IApiCustomerCommunicationServerModelMapper customerCommunicationModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CustomerCommunicationService = customerCommunicationService;
			this.CustomerCommunicationModelMapper = customerCommunicationModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCustomerCommunicationServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiCustomerCommunicationServerResponseModel> response = await this.CustomerCommunicationService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCustomerCommunicationServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCustomerCommunicationServerResponseModel response = await this.CustomerCommunicationService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCustomerCommunicationServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCustomerCommunicationServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCustomerCommunicationServerResponseModel> records = new List<ApiCustomerCommunicationServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCustomerCommunicationServerResponseModel> result = await this.CustomerCommunicationService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCustomerCommunicationServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCustomerCommunicationServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCustomerCommunicationServerRequestModel model)
		{
			CreateResponse<ApiCustomerCommunicationServerResponseModel> result = await this.CustomerCommunicationService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CustomerCommunications/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCustomerCommunicationServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCustomerCommunicationServerRequestModel> patch)
		{
			ApiCustomerCommunicationServerResponseModel record = await this.CustomerCommunicationService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCustomerCommunicationServerRequestModel model = await this.PatchModel(id, patch) as ApiCustomerCommunicationServerRequestModel;

				UpdateResponse<ApiCustomerCommunicationServerResponseModel> result = await this.CustomerCommunicationService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCustomerCommunicationServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCustomerCommunicationServerRequestModel model)
		{
			ApiCustomerCommunicationServerRequestModel request = await this.PatchModel(id, this.CustomerCommunicationModelMapper.CreatePatch(model)) as ApiCustomerCommunicationServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCustomerCommunicationServerResponseModel> result = await this.CustomerCommunicationService.Update(id, request);

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
			ActionResponse result = await this.CustomerCommunicationService.Delete(id);

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
		[Route("byCustomerId/{customerId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCustomerCommunicationServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCustomerId(int customerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCustomerCommunicationServerResponseModel> response = await this.CustomerCommunicationService.ByCustomerId(customerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byEmployeeId/{employeeId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCustomerCommunicationServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByEmployeeId(int employeeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCustomerCommunicationServerResponseModel> response = await this.CustomerCommunicationService.ByEmployeeId(employeeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCustomerCommunicationServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiCustomerCommunicationServerRequestModel> patch)
		{
			var record = await this.CustomerCommunicationService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCustomerCommunicationServerRequestModel request = this.CustomerCommunicationModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>edf612d4c86eba856ddf9028b457e35b</Hash>
</Codenesium>*/