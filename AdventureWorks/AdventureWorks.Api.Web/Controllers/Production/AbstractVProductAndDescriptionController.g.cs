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
	public abstract class AbstractVProductAndDescriptionController : AbstractApiController
	{
		protected IVProductAndDescriptionService VProductAndDescriptionService { get; private set; }

		protected IApiVProductAndDescriptionModelMapper VProductAndDescriptionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVProductAndDescriptionController(
			ApiSettings settings,
			ILogger<AbstractVProductAndDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVProductAndDescriptionService vProductAndDescriptionService,
			IApiVProductAndDescriptionModelMapper vProductAndDescriptionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VProductAndDescriptionService = vProductAndDescriptionService;
			this.VProductAndDescriptionModelMapper = vProductAndDescriptionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVProductAndDescriptionResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVProductAndDescriptionResponseModel> response = await this.VProductAndDescriptionService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVProductAndDescriptionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiVProductAndDescriptionResponseModel response = await this.VProductAndDescriptionService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiVProductAndDescriptionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVProductAndDescriptionRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVProductAndDescriptionResponseModel> records = new List<ApiVProductAndDescriptionResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVProductAndDescriptionResponseModel> result = await this.VProductAndDescriptionService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiVProductAndDescriptionResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiVProductAndDescriptionRequestModel model)
		{
			CreateResponse<ApiVProductAndDescriptionResponseModel> result = await this.VProductAndDescriptionService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VProductAndDescriptions/{result.Record.CultureID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVProductAndDescriptionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiVProductAndDescriptionRequestModel> patch)
		{
			ApiVProductAndDescriptionResponseModel record = await this.VProductAndDescriptionService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVProductAndDescriptionRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiVProductAndDescriptionResponseModel> result = await this.VProductAndDescriptionService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVProductAndDescriptionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiVProductAndDescriptionRequestModel model)
		{
			ApiVProductAndDescriptionRequestModel request = await this.PatchModel(id, this.VProductAndDescriptionModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVProductAndDescriptionResponseModel> result = await this.VProductAndDescriptionService.Update(id, request);

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
		public virtual async Task<IActionResult> Delete(string id)
		{
			ActionResponse result = await this.VProductAndDescriptionService.Delete(id);

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
		[Route("byCultureIDProductID/{cultureID}/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVProductAndDescriptionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByCultureIDProductID(string cultureID, int productID)
		{
			ApiVProductAndDescriptionResponseModel response = await this.VProductAndDescriptionService.ByCultureIDProductID(cultureID, productID);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiVProductAndDescriptionRequestModel> PatchModel(string id, JsonPatchDocument<ApiVProductAndDescriptionRequestModel> patch)
		{
			var record = await this.VProductAndDescriptionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVProductAndDescriptionRequestModel request = this.VProductAndDescriptionModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>df8c48577d2ddacdcdbfd4dda5436f85</Hash>
</Codenesium>*/