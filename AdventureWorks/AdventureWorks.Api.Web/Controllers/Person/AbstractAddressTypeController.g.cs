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
	public abstract class AbstractAddressTypeController : AbstractApiController
	{
		protected IAddressTypeService AddressTypeService { get; private set; }

		protected IApiAddressTypeModelMapper AddressTypeModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractAddressTypeController(
			ApiSettings settings,
			ILogger<AbstractAddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeService addressTypeService,
			IApiAddressTypeModelMapper addressTypeModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.AddressTypeService = addressTypeService;
			this.AddressTypeModelMapper = addressTypeModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAddressTypeResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiAddressTypeResponseModel> response = await this.AddressTypeService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiAddressTypeResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiAddressTypeResponseModel response = await this.AddressTypeService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiAddressTypeResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiAddressTypeRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiAddressTypeResponseModel> records = new List<ApiAddressTypeResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiAddressTypeResponseModel> result = await this.AddressTypeService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiAddressTypeResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiAddressTypeRequestModel model)
		{
			CreateResponse<ApiAddressTypeResponseModel> result = await this.AddressTypeService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/AddressTypes/{result.Record.AddressTypeID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiAddressTypeResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiAddressTypeRequestModel> patch)
		{
			ApiAddressTypeResponseModel record = await this.AddressTypeService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiAddressTypeRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiAddressTypeResponseModel> result = await this.AddressTypeService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiAddressTypeResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiAddressTypeRequestModel model)
		{
			ApiAddressTypeRequestModel request = await this.PatchModel(id, this.AddressTypeModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiAddressTypeResponseModel> result = await this.AddressTypeService.Update(id, request);

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
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.AddressTypeService.Delete(id);

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
		[ProducesResponseType(typeof(ApiAddressTypeResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiAddressTypeResponseModel response = await this.AddressTypeService.ByName(name);

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
		[Route("{addressTypeID}/BusinessEntityAddresses")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> BusinessEntityAddresses(int addressTypeID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiBusinessEntityAddressResponseModel> response = await this.AddressTypeService.BusinessEntityAddresses(addressTypeID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiAddressTypeRequestModel> PatchModel(int id, JsonPatchDocument<ApiAddressTypeRequestModel> patch)
		{
			var record = await this.AddressTypeService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiAddressTypeRequestModel request = this.AddressTypeModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d1baa9d40f3a22c6a2fb60bccf6c3b1f</Hash>
</Codenesium>*/