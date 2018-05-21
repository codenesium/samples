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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractBusinessEntityContactController: AbstractApiController
	{
		protected IBOBusinessEntityContact businessEntityContactManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBusinessEntityContactController(
			ServiceSettings settings,
			ILogger<AbstractBusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityContact businessEntityContactManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.businessEntityContactManager = businessEntityContactManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOBusinessEntityContact>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOBusinessEntityContact> response = await this.businessEntityContactManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOBusinessEntityContact), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOBusinessEntityContact response = await this.businessEntityContactManager.Get(id);

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
		[ProducesResponseType(typeof(POCOBusinessEntityContact), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiBusinessEntityContactModel model)
		{
			CreateResponse<POCOBusinessEntityContact> result = await this.businessEntityContactManager.Create(model);

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
		[ProducesResponseType(typeof(List<POCOBusinessEntityContact>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBusinessEntityContactModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOBusinessEntityContact> records = new List<POCOBusinessEntityContact>();
			foreach (var model in models)
			{
				CreateResponse<POCOBusinessEntityContact> result = await this.businessEntityContactManager.Create(model);

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
		[ProducesResponseType(typeof(POCOBusinessEntityContact), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityContactModel model)
		{
			try
			{
				ActionResponse result = await this.businessEntityContactManager.Update(id, model);

				if (result.Success)
				{
					POCOBusinessEntityContact response = await this.businessEntityContactManager.Get(id);

					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.businessEntityContactManager.Delete(id);

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
		[ProducesResponseType(typeof(List<POCOBusinessEntityContact>), 200)]
		public async virtual Task<IActionResult> GetContactTypeID(int contactTypeID)
		{
			List<POCOBusinessEntityContact> response = await this.businessEntityContactManager.GetContactTypeID(contactTypeID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getPersonID/{personID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOBusinessEntityContact>), 200)]
		public async virtual Task<IActionResult> GetPersonID(int personID)
		{
			List<POCOBusinessEntityContact> response = await this.businessEntityContactManager.GetPersonID(personID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c1c1613f1816a6175c16cbfd5eef4232</Hash>
</Codenesium>*/