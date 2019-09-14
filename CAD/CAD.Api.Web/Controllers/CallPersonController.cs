using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	[Route("api/callPersons")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallPersonController : AbstractApiController
	{
		protected ICallPersonService CallPersonService { get; private set; }

		protected IApiCallPersonServerModelMapper CallPersonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public CallPersonController(
			ApiSettings settings,
			ILogger<CallPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallPersonService callPersonService,
			IApiCallPersonServerModelMapper callPersonModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CallPersonService = callPersonService;
			this.CallPersonModelMapper = callPersonModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCallPersonServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiCallPersonServerResponseModel> response = await this.CallPersonService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCallPersonServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCallPersonServerResponseModel response = await this.CallPersonService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCallPersonServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCallPersonServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCallPersonServerResponseModel> records = new List<ApiCallPersonServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCallPersonServerResponseModel> result = await this.CallPersonService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCallPersonServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCallPersonServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCallPersonServerRequestModel model)
		{
			CreateResponse<ApiCallPersonServerResponseModel> result = await this.CallPersonService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CallPersons/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCallPersonServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCallPersonServerRequestModel> patch)
		{
			ApiCallPersonServerResponseModel record = await this.CallPersonService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCallPersonServerRequestModel model = await this.PatchModel(id, patch) as ApiCallPersonServerRequestModel;

				UpdateResponse<ApiCallPersonServerResponseModel> result = await this.CallPersonService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCallPersonServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCallPersonServerRequestModel model)
		{
			ApiCallPersonServerRequestModel request = await this.PatchModel(id, this.CallPersonModelMapper.CreatePatch(model)) as ApiCallPersonServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCallPersonServerResponseModel> result = await this.CallPersonService.Update(id, request);

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
			ActionResponse result = await this.CallPersonService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiCallPersonServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiCallPersonServerRequestModel> patch)
		{
			var record = await this.CallPersonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCallPersonServerRequestModel request = this.CallPersonModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>243d0143fb4fbc050afcc2b6de67bc7d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/