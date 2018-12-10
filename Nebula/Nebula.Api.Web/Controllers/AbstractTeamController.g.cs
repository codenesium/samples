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
	public abstract class AbstractTeamController : AbstractApiController
	{
		protected ITeamService TeamService { get; private set; }

		protected IApiTeamServerModelMapper TeamModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTeamController(
			ApiSettings settings,
			ILogger<AbstractTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamService teamService,
			IApiTeamServerModelMapper teamModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TeamService = teamService;
			this.TeamModelMapper = teamModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeamServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeamServerResponseModel> response = await this.TeamService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTeamServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTeamServerResponseModel response = await this.TeamService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTeamServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTeamServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTeamServerResponseModel> records = new List<ApiTeamServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTeamServerResponseModel> result = await this.TeamService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTeamServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTeamServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTeamServerRequestModel model)
		{
			CreateResponse<ApiTeamServerResponseModel> result = await this.TeamService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Teams/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTeamServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTeamServerRequestModel> patch)
		{
			ApiTeamServerResponseModel record = await this.TeamService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTeamServerRequestModel model = await this.PatchModel(id, patch) as ApiTeamServerRequestModel;

				UpdateResponse<ApiTeamServerResponseModel> result = await this.TeamService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTeamServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeamServerRequestModel model)
		{
			ApiTeamServerRequestModel request = await this.PatchModel(id, this.TeamModelMapper.CreatePatch(model)) as ApiTeamServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTeamServerResponseModel> result = await this.TeamService.Update(id, request);

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
			ActionResponse result = await this.TeamService.Delete(id);

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
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTeamServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiTeamServerResponseModel response = await this.TeamService.ByName(name);

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
		[Route("{teamId}/Chains")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiChainServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ChainsByTeamId(int teamId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiChainServerResponseModel> response = await this.TeamService.ChainsByTeamId(teamId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTeamServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTeamServerRequestModel> patch)
		{
			var record = await this.TeamService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTeamServerRequestModel request = this.TeamModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9be5833408dbdd6d9f984b7e82240f7c</Hash>
</Codenesium>*/