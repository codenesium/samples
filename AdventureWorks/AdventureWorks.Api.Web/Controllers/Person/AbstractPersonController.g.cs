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
	public abstract class AbstractPersonController: AbstractApiController
	{
		protected IPersonService personService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPersonController(
			ServiceSettings settings,
			ILogger<AbstractPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonService personService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.personService = personService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPersonResponseModel> response = await this.personService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPersonResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPersonResponseModel response = await this.personService.Get(id);

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
		[ProducesResponseType(typeof(ApiPersonResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> result = await this.personService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/People/{result.Record.BusinessEntityID.ToString()}");
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
				CreateResponse<ApiPersonResponseModel> result = await this.personService.Create(model);

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
		[ProducesResponseType(typeof(ApiPersonResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPersonRequestModel model)
		{
			ActionResponse result = await this.personService.Update(id, model);

			if (result.Success)
			{
				ApiPersonResponseModel response = await this.personService.Get(id);

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
			ActionResponse result = await this.personService.Delete(id);

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
		[Route("getLastNameFirstNameMiddleName/{lastName}/{firstName}/{middleName}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			List<ApiPersonResponseModel> response = await this.personService.GetLastNameFirstNameMiddleName(lastName,firstName,middleName);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getAdditionalContactInfo/{additionalContactInfo}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> GetAdditionalContactInfo(string additionalContactInfo)
		{
			List<ApiPersonResponseModel> response = await this.personService.GetAdditionalContactInfo(additionalContactInfo);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getDemographics/{demographics}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> GetDemographics(string demographics)
		{
			List<ApiPersonResponseModel> response = await this.personService.GetDemographics(demographics);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e2faa20026aaadba2775c2a5907d4895</Hash>
</Codenesium>*/