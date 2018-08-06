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
	public abstract class AbstractCultureController : AbstractApiController
	{
		protected ICultureService CultureService { get; private set; }

		protected IApiCultureModelMapper CultureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCultureController(
			ApiSettings settings,
			ILogger<AbstractCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureService cultureService,
			IApiCultureModelMapper cultureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CultureService = cultureService;
			this.CultureModelMapper = cultureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCultureResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiCultureResponseModel> response = await this.CultureService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCultureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiCultureResponseModel response = await this.CultureService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiCultureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCultureRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCultureResponseModel> records = new List<ApiCultureResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCultureResponseModel> result = await this.CultureService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiCultureResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiCultureRequestModel model)
		{
			CreateResponse<ApiCultureResponseModel> result = await this.CultureService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Cultures/{result.Record.CultureID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCultureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiCultureRequestModel> patch)
		{
			ApiCultureResponseModel record = await this.CultureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCultureRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiCultureResponseModel> result = await this.CultureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCultureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCultureRequestModel model)
		{
			ApiCultureRequestModel request = await this.PatchModel(id, this.CultureModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCultureResponseModel> result = await this.CultureService.Update(id, request);

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
			ActionResponse result = await this.CultureService.Delete(id);

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
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCultureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiCultureResponseModel response = await this.CultureService.ByName(name);

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
		[Route("{cultureID}/ProductModelProductDescriptionCultures")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelProductDescriptionCultureResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductModelProductDescriptionCultures(string cultureID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiProductModelProductDescriptionCultureResponseModel> response = await this.CultureService.ProductModelProductDescriptionCultures(cultureID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCultureRequestModel> PatchModel(string id, JsonPatchDocument<ApiCultureRequestModel> patch)
		{
			var record = await this.CultureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCultureRequestModel request = this.CultureModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2b919bd3de14fadfc6a58576f199850f</Hash>
</Codenesium>*/