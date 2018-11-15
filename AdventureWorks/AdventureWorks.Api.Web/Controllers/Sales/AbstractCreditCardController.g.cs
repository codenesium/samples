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
	public abstract class AbstractCreditCardController : AbstractApiController
	{
		protected ICreditCardService CreditCardService { get; private set; }

		protected IApiCreditCardServerModelMapper CreditCardModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCreditCardController(
			ApiSettings settings,
			ILogger<AbstractCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICreditCardService creditCardService,
			IApiCreditCardServerModelMapper creditCardModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CreditCardService = creditCardService;
			this.CreditCardModelMapper = creditCardModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCreditCardServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCreditCardServerResponseModel> response = await this.CreditCardService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCreditCardServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCreditCardServerResponseModel response = await this.CreditCardService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCreditCardServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCreditCardServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCreditCardServerResponseModel> records = new List<ApiCreditCardServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCreditCardServerResponseModel> result = await this.CreditCardService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCreditCardServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCreditCardServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCreditCardServerRequestModel model)
		{
			CreateResponse<ApiCreditCardServerResponseModel> result = await this.CreditCardService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CreditCards/{result.Record.CreditCardID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCreditCardServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCreditCardServerRequestModel> patch)
		{
			ApiCreditCardServerResponseModel record = await this.CreditCardService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCreditCardServerRequestModel model = await this.PatchModel(id, patch) as ApiCreditCardServerRequestModel;

				UpdateResponse<ApiCreditCardServerResponseModel> result = await this.CreditCardService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCreditCardServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCreditCardServerRequestModel model)
		{
			ApiCreditCardServerRequestModel request = await this.PatchModel(id, this.CreditCardModelMapper.CreatePatch(model)) as ApiCreditCardServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCreditCardServerResponseModel> result = await this.CreditCardService.Update(id, request);

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
			ActionResponse result = await this.CreditCardService.Delete(id);

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
		[Route("byCardNumber/{cardNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCreditCardServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByCardNumber(string cardNumber)
		{
			ApiCreditCardServerResponseModel response = await this.CreditCardService.ByCardNumber(cardNumber);

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
		[Route("{creditCardID}/SalesOrderHeaders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeadersByCreditCardID(int creditCardID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.CreditCardService.SalesOrderHeadersByCreditCardID(creditCardID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCreditCardServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiCreditCardServerRequestModel> patch)
		{
			var record = await this.CreditCardService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCreditCardServerRequestModel request = this.CreditCardModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e32a682253dba5e9705b71cf23386f93</Hash>
</Codenesium>*/