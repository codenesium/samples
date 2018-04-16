using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractBusinessEntityContactController: AbstractApiController
	{
		protected IBusinessEntityContactRepository businessEntityContactRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBusinessEntityContactController(
			ILogger<AbstractBusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactRepository businessEntityContactRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.businessEntityContactRepository = businessEntityContactRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.businessEntityContactRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.businessEntityContactRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] BusinessEntityContactModel model)
		{
			var id = this.businessEntityContactRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<BusinessEntityContactModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.businessEntityContactRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] BusinessEntityContactModel model)
		{
			this.businessEntityContactRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.businessEntityContactRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.businessEntityContactRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByPersonID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByPersonID(int id)
		{
			ApiResponse response = this.businessEntityContactRepository.GetWhere(x => x.PersonID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByContactTypeID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ContactTypes/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByContactTypeID(int id)
		{
			ApiResponse response = this.businessEntityContactRepository.GetWhere(x => x.ContactTypeID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>932ac4518e223ba234eadf49f931b226</Hash>
</Codenesium>*/