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
	public abstract class AbstractJobCandidateController : AbstractApiController
	{
		protected IJobCandidateService JobCandidateService { get; private set; }

		protected IApiJobCandidateServerModelMapper JobCandidateModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractJobCandidateController(
			ApiSettings settings,
			ILogger<AbstractJobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateService jobCandidateService,
			IApiJobCandidateServerModelMapper jobCandidateModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.JobCandidateService = jobCandidateService;
			this.JobCandidateModelMapper = jobCandidateModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiJobCandidateServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiJobCandidateServerResponseModel> response = await this.JobCandidateService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiJobCandidateServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiJobCandidateServerResponseModel response = await this.JobCandidateService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiJobCandidateServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiJobCandidateServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiJobCandidateServerResponseModel> records = new List<ApiJobCandidateServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiJobCandidateServerResponseModel> result = await this.JobCandidateService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiJobCandidateServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiJobCandidateServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiJobCandidateServerRequestModel model)
		{
			CreateResponse<ApiJobCandidateServerResponseModel> result = await this.JobCandidateService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/JobCandidates/{result.Record.JobCandidateID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiJobCandidateServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiJobCandidateServerRequestModel> patch)
		{
			ApiJobCandidateServerResponseModel record = await this.JobCandidateService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiJobCandidateServerRequestModel model = await this.PatchModel(id, patch) as ApiJobCandidateServerRequestModel;

				UpdateResponse<ApiJobCandidateServerResponseModel> result = await this.JobCandidateService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiJobCandidateServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiJobCandidateServerRequestModel model)
		{
			ApiJobCandidateServerRequestModel request = await this.PatchModel(id, this.JobCandidateModelMapper.CreatePatch(model)) as ApiJobCandidateServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiJobCandidateServerResponseModel> result = await this.JobCandidateService.Update(id, request);

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
			ActionResponse result = await this.JobCandidateService.Delete(id);

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
		[Route("byBusinessEntityID/{businessEntityID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiJobCandidateServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByBusinessEntityID(int? businessEntityID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiJobCandidateServerResponseModel> response = await this.JobCandidateService.ByBusinessEntityID(businessEntityID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiJobCandidateServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiJobCandidateServerRequestModel> patch)
		{
			var record = await this.JobCandidateService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiJobCandidateServerRequestModel request = this.JobCandidateModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b04b45e5477ea5360ad3e122622dcdea</Hash>
</Codenesium>*/