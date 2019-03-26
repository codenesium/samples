using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractAWBuildVersionController : AbstractApiController
	{
		protected IAWBuildVersionService AWBuildVersionService { get; private set; }

		protected IApiAWBuildVersionServerModelMapper AWBuildVersionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractAWBuildVersionController(
			ApiSettings settings,
			ILogger<AbstractAWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionService aWBuildVersionService,
			IApiAWBuildVersionServerModelMapper aWBuildVersionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.AWBuildVersionService = aWBuildVersionService;
			this.AWBuildVersionModelMapper = aWBuildVersionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAWBuildVersionServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiAWBuildVersionServerResponseModel> response = await this.AWBuildVersionService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiAWBuildVersionServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiAWBuildVersionServerResponseModel response = await this.AWBuildVersionService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiAWBuildVersionServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiAWBuildVersionServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiAWBuildVersionServerResponseModel> records = new List<ApiAWBuildVersionServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiAWBuildVersionServerResponseModel> result = await this.AWBuildVersionService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiAWBuildVersionServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiAWBuildVersionServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiAWBuildVersionServerRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionServerResponseModel> result = await this.AWBuildVersionService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/AWBuildVersions/{result.Record.SystemInformationID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiAWBuildVersionServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiAWBuildVersionServerRequestModel> patch)
		{
			ApiAWBuildVersionServerResponseModel record = await this.AWBuildVersionService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiAWBuildVersionServerRequestModel model = await this.PatchModel(id, patch) as ApiAWBuildVersionServerRequestModel;

				UpdateResponse<ApiAWBuildVersionServerResponseModel> result = await this.AWBuildVersionService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiAWBuildVersionServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiAWBuildVersionServerRequestModel model)
		{
			ApiAWBuildVersionServerRequestModel request = await this.PatchModel(id, this.AWBuildVersionModelMapper.CreatePatch(model)) as ApiAWBuildVersionServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiAWBuildVersionServerResponseModel> result = await this.AWBuildVersionService.Update(id, request);

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
			ActionResponse result = await this.AWBuildVersionService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiAWBuildVersionServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiAWBuildVersionServerRequestModel> patch)
		{
			var record = await this.AWBuildVersionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiAWBuildVersionServerRequestModel request = this.AWBuildVersionModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>49bcb2dbfd39fb67f80e65ea452ca8c0</Hash>
</Codenesium>*/