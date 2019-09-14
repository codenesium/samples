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
	[Route("api/chains")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ChainController : AbstractApiController
	{
		protected IChainService ChainService { get; private set; }

		protected IApiChainServerModelMapper ChainModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public ChainController(
			ApiSettings settings,
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainService chainService,
			IApiChainServerModelMapper chainModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ChainService = chainService;
			this.ChainModelMapper = chainModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiChainServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiChainServerResponseModel> response = await this.ChainService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiChainServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiChainServerResponseModel response = await this.ChainService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiChainServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiChainServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiChainServerResponseModel> records = new List<ApiChainServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiChainServerResponseModel> result = await this.ChainService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiChainServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiChainServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiChainServerRequestModel model)
		{
			CreateResponse<ApiChainServerResponseModel> result = await this.ChainService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Chains/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiChainServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiChainServerRequestModel> patch)
		{
			ApiChainServerResponseModel record = await this.ChainService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiChainServerRequestModel model = await this.PatchModel(id, patch) as ApiChainServerRequestModel;

				UpdateResponse<ApiChainServerResponseModel> result = await this.ChainService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiChainServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiChainServerRequestModel model)
		{
			ApiChainServerRequestModel request = await this.PatchModel(id, this.ChainModelMapper.CreatePatch(model)) as ApiChainServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiChainServerResponseModel> result = await this.ChainService.Update(id, request);

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
			ActionResponse result = await this.ChainService.Delete(id);

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
		[ProducesResponseType(typeof(ApiChainServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByExternalId(Guid externalId)
		{
			ApiChainServerResponseModel response = await this.ChainService.ByExternalId(externalId);

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
		[Route("{nextChainId}/Clasps")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiClaspServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ClaspsByNextChainId(int nextChainId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiClaspServerResponseModel> response = await this.ChainService.ClaspsByNextChainId(nextChainId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{previousChainId}/ClaspsByPreviousChainId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiClaspServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ClaspsByPreviousChainId(int previousChainId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiClaspServerResponseModel> response = await this.ChainService.ClaspsByPreviousChainId(previousChainId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{chainId}/Links")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> LinksByChainId(int chainId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiLinkServerResponseModel> response = await this.ChainService.LinksByChainId(chainId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiChainServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiChainServerRequestModel> patch)
		{
			var record = await this.ChainService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiChainServerRequestModel request = this.ChainModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1d84f24cbd09ae6d178454d8c633c630</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/