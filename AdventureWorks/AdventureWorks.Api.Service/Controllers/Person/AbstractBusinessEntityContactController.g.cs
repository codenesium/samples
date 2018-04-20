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
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.businessEntityContactManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.businessEntityContactManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] BusinessEntityContactModel model)
		{
			var result = await this.businessEntityContactManager.Create(model);

			if(result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.settings.ExternalBaseUrl}/api/businessEntityContacts/{result.Id.ToString()}");
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<BusinessEntityContactModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			foreach (var model in models)
			{
				var result = await this.businessEntityContactManager.Create(model);

				if(!result.Success)
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.NoContent();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] BusinessEntityContactModel model)
		{
			var result = await this.businessEntityContactManager.Update(id, model);

			if(result.Success)
			{
				return this.NoContent();
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
			var result = await this.businessEntityContactManager.Delete(id);

			if(result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnly]
		[Route("~/api/BusinessEntities/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.businessEntityContactManager.GetWhere(x => x.BusinessEntityID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByPersonID/{id}")]
		[ReadOnly]
		[Route("~/api/People/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByPersonID(int id)
		{
			ApiResponse response = this.businessEntityContactManager.GetWhere(x => x.PersonID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByContactTypeID/{id}")]
		[ReadOnly]
		[Route("~/api/ContactTypes/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByContactTypeID(int id)
		{
			ApiResponse response = this.businessEntityContactManager.GetWhere(x => x.ContactTypeID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6447c37c08b0d0cd01573dad20774934</Hash>
</Codenesium>*/