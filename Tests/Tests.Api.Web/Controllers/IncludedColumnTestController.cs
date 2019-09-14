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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/includedColumnTests")]
	[ApiController]
	[ApiVersion("1.0")]

	public class IncludedColumnTestController : AbstractApiController
	{
		protected IIncludedColumnTestService IncludedColumnTestService { get; private set; }

		protected IApiIncludedColumnTestServerModelMapper IncludedColumnTestModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public IncludedColumnTestController(
			ApiSettings settings,
			ILogger<IncludedColumnTestController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIncludedColumnTestService includedColumnTestService,
			IApiIncludedColumnTestServerModelMapper includedColumnTestModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.IncludedColumnTestService = includedColumnTestService;
			this.IncludedColumnTestModelMapper = includedColumnTestModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiIncludedColumnTestServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiIncludedColumnTestServerResponseModel> response = await this.IncludedColumnTestService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiIncludedColumnTestServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiIncludedColumnTestServerResponseModel response = await this.IncludedColumnTestService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiIncludedColumnTestServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiIncludedColumnTestServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiIncludedColumnTestServerResponseModel> records = new List<ApiIncludedColumnTestServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiIncludedColumnTestServerResponseModel> result = await this.IncludedColumnTestService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiIncludedColumnTestServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiIncludedColumnTestServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiIncludedColumnTestServerRequestModel model)
		{
			CreateResponse<ApiIncludedColumnTestServerResponseModel> result = await this.IncludedColumnTestService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/IncludedColumnTests/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiIncludedColumnTestServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiIncludedColumnTestServerRequestModel> patch)
		{
			ApiIncludedColumnTestServerResponseModel record = await this.IncludedColumnTestService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiIncludedColumnTestServerRequestModel model = await this.PatchModel(id, patch) as ApiIncludedColumnTestServerRequestModel;

				UpdateResponse<ApiIncludedColumnTestServerResponseModel> result = await this.IncludedColumnTestService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiIncludedColumnTestServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiIncludedColumnTestServerRequestModel model)
		{
			ApiIncludedColumnTestServerRequestModel request = await this.PatchModel(id, this.IncludedColumnTestModelMapper.CreatePatch(model)) as ApiIncludedColumnTestServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiIncludedColumnTestServerResponseModel> result = await this.IncludedColumnTestService.Update(id, request);

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
			ActionResponse result = await this.IncludedColumnTestService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiIncludedColumnTestServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiIncludedColumnTestServerRequestModel> patch)
		{
			var record = await this.IncludedColumnTestService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiIncludedColumnTestServerRequestModel request = this.IncludedColumnTestModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>7878b675220a0f0e4258eedc23da2b2b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/