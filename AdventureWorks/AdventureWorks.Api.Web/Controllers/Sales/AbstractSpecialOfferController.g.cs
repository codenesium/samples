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
	public abstract class AbstractSpecialOfferController : AbstractApiController
	{
		protected ISpecialOfferService SpecialOfferService { get; private set; }

		protected IApiSpecialOfferServerModelMapper SpecialOfferModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSpecialOfferController(
			ApiSettings settings,
			ILogger<AbstractSpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferService specialOfferService,
			IApiSpecialOfferServerModelMapper specialOfferModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SpecialOfferService = specialOfferService;
			this.SpecialOfferModelMapper = specialOfferModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpecialOfferServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpecialOfferServerResponseModel> response = await this.SpecialOfferService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpecialOfferServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSpecialOfferServerResponseModel response = await this.SpecialOfferService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiSpecialOfferServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpecialOfferServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSpecialOfferServerResponseModel> records = new List<ApiSpecialOfferServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSpecialOfferServerResponseModel> result = await this.SpecialOfferService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSpecialOfferServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSpecialOfferServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSpecialOfferServerRequestModel model)
		{
			CreateResponse<ApiSpecialOfferServerResponseModel> result = await this.SpecialOfferService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpecialOffers/{result.Record.SpecialOfferID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSpecialOfferServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpecialOfferServerRequestModel> patch)
		{
			ApiSpecialOfferServerResponseModel record = await this.SpecialOfferService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSpecialOfferServerRequestModel model = await this.PatchModel(id, patch) as ApiSpecialOfferServerRequestModel;

				UpdateResponse<ApiSpecialOfferServerResponseModel> result = await this.SpecialOfferService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSpecialOfferServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpecialOfferServerRequestModel model)
		{
			ApiSpecialOfferServerRequestModel request = await this.PatchModel(id, this.SpecialOfferModelMapper.CreatePatch(model)) as ApiSpecialOfferServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSpecialOfferServerResponseModel> result = await this.SpecialOfferService.Update(id, request);

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
			ActionResponse result = await this.SpecialOfferService.Delete(id);

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
		[Route("byRowguid/{rowguid}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpecialOfferServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiSpecialOfferServerResponseModel response = await this.SpecialOfferService.ByRowguid(rowguid);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiSpecialOfferServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSpecialOfferServerRequestModel> patch)
		{
			var record = await this.SpecialOfferService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSpecialOfferServerRequestModel request = this.SpecialOfferModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ac4437defcc50f06a383c3e75a8abaf3</Hash>
</Codenesium>*/