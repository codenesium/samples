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
	[Route("api/links")]
	[ApiController]
	[ApiVersion("1.0")]

	public class LinkController : AbstractApiController
	{
		protected ILinkService LinkService { get; private set; }

		protected IApiLinkServerModelMapper LinkModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public LinkController(
			ApiSettings settings,
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkService linkService,
			IApiLinkServerModelMapper linkModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.LinkService = linkService;
			this.LinkModelMapper = linkModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiLinkServerResponseModel> response = await this.LinkService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiLinkServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiLinkServerResponseModel response = await this.LinkService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiLinkServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLinkServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiLinkServerResponseModel> records = new List<ApiLinkServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiLinkServerResponseModel> result = await this.LinkService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiLinkServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiLinkServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiLinkServerRequestModel model)
		{
			CreateResponse<ApiLinkServerResponseModel> result = await this.LinkService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Links/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiLinkServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLinkServerRequestModel> patch)
		{
			ApiLinkServerResponseModel record = await this.LinkService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiLinkServerRequestModel model = await this.PatchModel(id, patch) as ApiLinkServerRequestModel;

				UpdateResponse<ApiLinkServerResponseModel> result = await this.LinkService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiLinkServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLinkServerRequestModel model)
		{
			ApiLinkServerRequestModel request = await this.PatchModel(id, this.LinkModelMapper.CreatePatch(model)) as ApiLinkServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiLinkServerResponseModel> result = await this.LinkService.Update(id, request);

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
			ActionResponse result = await this.LinkService.Delete(id);

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
		[Route("byExternalId/{externalId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiLinkServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByExternalId(Guid externalId)
		{
			ApiLinkServerResponseModel response = await this.LinkService.ByExternalId(externalId);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("byChainId/{chainId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByChainId(int chainId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiLinkServerResponseModel> response = await this.LinkService.ByChainId(chainId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{linkId}/LinkLogs")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkLogServerResponseModel>), 200)]
		public async virtual Task<IActionResult> LinkLogsByLinkId(int linkId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiLinkLogServerResponseModel> response = await this.LinkService.LinkLogsByLinkId(linkId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiLinkServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiLinkServerRequestModel> patch)
		{
			var record = await this.LinkService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiLinkServerRequestModel request = this.LinkModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>fda06a4638bb079a3c8f283ed7763930</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/