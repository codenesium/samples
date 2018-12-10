using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	public abstract class AbstractClaspController : AbstractApiController
	{
		protected IClaspService ClaspService { get; private set; }

		protected IApiClaspServerModelMapper ClaspModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractClaspController(
			ApiSettings settings,
			ILogger<AbstractClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspService claspService,
			IApiClaspServerModelMapper claspModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ClaspService = claspService;
			this.ClaspModelMapper = claspModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiClaspServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiClaspServerResponseModel> response = await this.ClaspService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiClaspServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiClaspServerResponseModel response = await this.ClaspService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiClaspServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiClaspServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiClaspServerResponseModel> records = new List<ApiClaspServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiClaspServerResponseModel> result = await this.ClaspService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiClaspServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiClaspServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiClaspServerRequestModel model)
		{
			CreateResponse<ApiClaspServerResponseModel> result = await this.ClaspService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Clasps/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiClaspServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiClaspServerRequestModel> patch)
		{
			ApiClaspServerResponseModel record = await this.ClaspService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiClaspServerRequestModel model = await this.PatchModel(id, patch) as ApiClaspServerRequestModel;

				UpdateResponse<ApiClaspServerResponseModel> result = await this.ClaspService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiClaspServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiClaspServerRequestModel model)
		{
			ApiClaspServerRequestModel request = await this.PatchModel(id, this.ClaspModelMapper.CreatePatch(model)) as ApiClaspServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiClaspServerResponseModel> result = await this.ClaspService.Update(id, request);

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
			ActionResponse result = await this.ClaspService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiClaspServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiClaspServerRequestModel> patch)
		{
			var record = await this.ClaspService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiClaspServerRequestModel request = this.ClaspModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f4fea53ce7d4d7f41ad6d3f42edfed96</Hash>
</Codenesium>*/