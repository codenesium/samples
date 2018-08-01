using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public abstract class AbstractDocumentController : AbstractApiController
	{
		protected IDocumentService DocumentService { get; private set; }

		protected IApiDocumentModelMapper DocumentModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractDocumentController(
			ApiSettings settings,
			ILogger<AbstractDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentService documentService,
			IApiDocumentModelMapper documentModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.DocumentService = documentService;
			this.DocumentModelMapper = documentModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDocumentResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiDocumentResponseModel> response = await this.DocumentService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDocumentResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(Guid id)
		{
			ApiDocumentResponseModel response = await this.DocumentService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiDocumentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDocumentRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDocumentResponseModel> records = new List<ApiDocumentResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDocumentResponseModel> result = await this.DocumentService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiDocumentResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> result = await this.DocumentService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Documents/{result.Record.Rowguid}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiDocumentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<ApiDocumentRequestModel> patch)
		{
			ApiDocumentResponseModel record = await this.DocumentService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiDocumentRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiDocumentResponseModel> result = await this.DocumentService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiDocumentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(Guid id, [FromBody] ApiDocumentRequestModel model)
		{
			ApiDocumentRequestModel request = await this.PatchModel(id, this.DocumentModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiDocumentResponseModel> result = await this.DocumentService.Update(id, request);

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
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(Guid id)
		{
			ActionResponse result = await this.DocumentService.Delete(id);

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
		[Route("byFileNameRevision/{fileName}/{revision}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDocumentResponseModel>), 200)]
		public async virtual Task<IActionResult> ByFileNameRevision(string fileName, string revision)
		{
			List<ApiDocumentResponseModel> response = await this.DocumentService.ByFileNameRevision(fileName, revision);

			return this.Ok(response);
		}

		private async Task<ApiDocumentRequestModel> PatchModel(Guid id, JsonPatchDocument<ApiDocumentRequestModel> patch)
		{
			var record = await this.DocumentService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiDocumentRequestModel request = this.DocumentModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>fd19b21fd4cb5442d2a33bfb7d1284d1</Hash>
</Codenesium>*/