using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractBusinessEntityContactController: AbstractApiController
	{
		protected IBusinessEntityContactService businessEntityContactService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractBusinessEntityContactController(
			ServiceSettings settings,
			ILogger<AbstractBusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactService businessEntityContactService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.businessEntityContactService = businessEntityContactService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiBusinessEntityContactResponseModel> response = await this.businessEntityContactService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiBusinessEntityContactResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiBusinessEntityContactResponseModel response = await this.businessEntityContactService.Get(id);

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
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiBusinessEntityContactResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiBusinessEntityContactRequestModel model)
		{
			CreateResponse<ApiBusinessEntityContactResponseModel> result = await this.businessEntityContactService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/BusinessEntityContacts/{result.Record.BusinessEntityID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBusinessEntityContactRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiBusinessEntityContactResponseModel> records = new List<ApiBusinessEntityContactResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiBusinessEntityContactResponseModel> result = await this.businessEntityContactService.Create(model);

				if(result.Success)
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

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiBusinessEntityContactResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityContactRequestModel model)
		{
			ActionResponse result = await this.businessEntityContactService.Update(id, model);

			if (result.Success)
			{
				ApiBusinessEntityContactResponseModel response = await this.businessEntityContactService.Get(id);

				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.businessEntityContactService.Delete(id);

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
		[Route("getContactTypeID/{contactTypeID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
		public async virtual Task<IActionResult> GetContactTypeID(int contactTypeID)
		{
			List<ApiBusinessEntityContactResponseModel> response = await this.businessEntityContactService.GetContactTypeID(contactTypeID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getPersonID/{personID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
		public async virtual Task<IActionResult> GetPersonID(int personID)
		{
			List<ApiBusinessEntityContactResponseModel> response = await this.businessEntityContactService.GetPersonID(personID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c5ee9de9b922bc027647f6e6e7bdfe97</Hash>
</Codenesium>*/