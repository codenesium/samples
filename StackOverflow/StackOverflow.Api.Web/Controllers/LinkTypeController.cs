using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	[Route("api/linkTypes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class LinkTypeController : AbstractApiController
	{
		protected ILinkTypeService LinkTypeService { get; private set; }

		protected IApiLinkTypeServerModelMapper LinkTypeModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public LinkTypeController(
			ApiSettings settings,
			ILogger<LinkTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkTypeService linkTypeService,
			IApiLinkTypeServerModelMapper linkTypeModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.LinkTypeService = linkTypeService;
			this.LinkTypeModelMapper = linkTypeModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkTypeServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiLinkTypeServerResponseModel> response = await this.LinkTypeService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiLinkTypeServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiLinkTypeServerResponseModel response = await this.LinkTypeService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiLinkTypeServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLinkTypeServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiLinkTypeServerResponseModel> records = new List<ApiLinkTypeServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiLinkTypeServerResponseModel> result = await this.LinkTypeService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiLinkTypeServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiLinkTypeServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiLinkTypeServerRequestModel model)
		{
			CreateResponse<ApiLinkTypeServerResponseModel> result = await this.LinkTypeService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/LinkTypes/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiLinkTypeServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLinkTypeServerRequestModel> patch)
		{
			ApiLinkTypeServerResponseModel record = await this.LinkTypeService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiLinkTypeServerRequestModel model = await this.PatchModel(id, patch) as ApiLinkTypeServerRequestModel;

				UpdateResponse<ApiLinkTypeServerResponseModel> result = await this.LinkTypeService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiLinkTypeServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLinkTypeServerRequestModel model)
		{
			ApiLinkTypeServerRequestModel request = await this.PatchModel(id, this.LinkTypeModelMapper.CreatePatch(model)) as ApiLinkTypeServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiLinkTypeServerResponseModel> result = await this.LinkTypeService.Update(id, request);

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
			ActionResponse result = await this.LinkTypeService.Delete(id);

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
		[Route("{linkTypeId}/PostLinks")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostLinksByLinkTypeId(int linkTypeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.LinkTypeService.PostLinksByLinkTypeId(linkTypeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiLinkTypeServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiLinkTypeServerRequestModel> patch)
		{
			var record = await this.LinkTypeService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiLinkTypeServerRequestModel request = this.LinkTypeModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>83a48eb1062af7933b0528ede1ed296c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/