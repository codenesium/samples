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
	public abstract class AbstractPersonController : AbstractApiController
	{
		protected IPersonService PersonService { get; private set; }

		protected IApiPersonModelMapper PersonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPersonController(
			ApiSettings settings,
			ILogger<AbstractPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonService personService,
			IApiPersonModelMapper personModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PersonService = personService;
			this.PersonModelMapper = personModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPersonResponseModel> response = await this.PersonService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPersonResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPersonResponseModel response = await this.PersonService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPersonRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPersonResponseModel> records = new List<ApiPersonResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPersonResponseModel> result = await this.PersonService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiPersonResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> result = await this.PersonService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/People/{result.Record.BusinessEntityID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPersonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPersonRequestModel> patch)
		{
			ApiPersonResponseModel record = await this.PersonService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPersonRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPersonResponseModel> result = await this.PersonService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPersonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPersonRequestModel model)
		{
			ApiPersonRequestModel request = await this.PatchModel(id, this.PersonModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPersonResponseModel> result = await this.PersonService.Update(id, request);

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
			ActionResponse result = await this.PersonService.Delete(id);

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
		[Route("byLastNameFirstNameMiddleName/{lastName}/{firstName}/{middleName}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPersonResponseModel> response = await this.PersonService.ByLastNameFirstNameMiddleName(lastName, firstName, middleName, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byAdditionalContactInfo/{additionalContactInfo}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> ByAdditionalContactInfo(string additionalContactInfo, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPersonResponseModel> response = await this.PersonService.ByAdditionalContactInfo(additionalContactInfo, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byDemographics/{demographic}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDemographic(string demographic, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPersonResponseModel> response = await this.PersonService.ByDemographic(demographic, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{personID}/BusinessEntityContactsByPersonID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
		public async virtual Task<IActionResult> BusinessEntityContactsByPersonID(int personID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBusinessEntityContactResponseModel> response = await this.PersonService.BusinessEntityContactsByPersonID(personID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{businessEntityID}/EmailAddressesByBusinessEntityID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmailAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> EmailAddressesByBusinessEntityID(int businessEntityID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEmailAddressResponseModel> response = await this.PersonService.EmailAddressesByBusinessEntityID(businessEntityID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{businessEntityID}/PasswordsByBusinessEntityID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPasswordResponseModel>), 200)]
		public async virtual Task<IActionResult> PasswordsByBusinessEntityID(int businessEntityID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPasswordResponseModel> response = await this.PersonService.PasswordsByBusinessEntityID(businessEntityID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{businessEntityID}/PersonPhonesByBusinessEntityID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonPhoneResponseModel>), 200)]
		public async virtual Task<IActionResult> PersonPhonesByBusinessEntityID(int businessEntityID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPersonPhoneResponseModel> response = await this.PersonService.PersonPhonesByBusinessEntityID(businessEntityID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPersonRequestModel> PatchModel(int id, JsonPatchDocument<ApiPersonRequestModel> patch)
		{
			var record = await this.PersonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPersonRequestModel request = this.PersonModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>123bbffbc99ea70ec40b3cfb02d52648</Hash>
</Codenesium>*/