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
	public abstract class AbstractCompositePrimaryKeyController : AbstractApiController
	{
		protected ICompositePrimaryKeyService CompositePrimaryKeyService { get; private set; }

		protected IApiCompositePrimaryKeyModelMapper CompositePrimaryKeyModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCompositePrimaryKeyController(
			ApiSettings settings,
			ILogger<AbstractCompositePrimaryKeyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICompositePrimaryKeyService compositePrimaryKeyService,
			IApiCompositePrimaryKeyModelMapper compositePrimaryKeyModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CompositePrimaryKeyService = compositePrimaryKeyService;
			this.CompositePrimaryKeyModelMapper = compositePrimaryKeyModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCompositePrimaryKeyResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCompositePrimaryKeyResponseModel> response = await this.CompositePrimaryKeyService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCompositePrimaryKeyResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCompositePrimaryKeyResponseModel response = await this.CompositePrimaryKeyService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiCompositePrimaryKeyResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCompositePrimaryKeyRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCompositePrimaryKeyResponseModel> records = new List<ApiCompositePrimaryKeyResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCompositePrimaryKeyResponseModel> result = await this.CompositePrimaryKeyService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiCompositePrimaryKeyResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiCompositePrimaryKeyRequestModel model)
		{
			CreateResponse<ApiCompositePrimaryKeyResponseModel> result = await this.CompositePrimaryKeyService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CompositePrimaryKeys/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCompositePrimaryKeyResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCompositePrimaryKeyRequestModel> patch)
		{
			ApiCompositePrimaryKeyResponseModel record = await this.CompositePrimaryKeyService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCompositePrimaryKeyRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiCompositePrimaryKeyResponseModel> result = await this.CompositePrimaryKeyService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCompositePrimaryKeyResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCompositePrimaryKeyRequestModel model)
		{
			ApiCompositePrimaryKeyRequestModel request = await this.PatchModel(id, this.CompositePrimaryKeyModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCompositePrimaryKeyResponseModel> result = await this.CompositePrimaryKeyService.Update(id, request);

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
			ActionResponse result = await this.CompositePrimaryKeyService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiCompositePrimaryKeyRequestModel> PatchModel(int id, JsonPatchDocument<ApiCompositePrimaryKeyRequestModel> patch)
		{
			var record = await this.CompositePrimaryKeyService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCompositePrimaryKeyRequestModel request = this.CompositePrimaryKeyModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ed61fbd626af5621ac1315654f40b02a</Hash>
</Codenesium>*/