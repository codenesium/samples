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
	public abstract class AbstractBusinessEntityAddressController: AbstractApiController
	{
		protected IBusinessEntityAddressRepository businessEntityAddressRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBusinessEntityAddressController(
			ILogger<AbstractBusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityAddressRepository businessEntityAddressRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.businessEntityAddressRepository.GetById(id);
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
			ApiResponse response = this.businessEntityAddressRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] BusinessEntityAddressModel model)
		{
			var id = this.businessEntityAddressRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<BusinessEntityAddressModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.businessEntityAddressRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] BusinessEntityAddressModel model)
		{
			this.businessEntityAddressRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.businessEntityAddressRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.businessEntityAddressRepository.GetWhere(x => x.BusinessEntityID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByAddressID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Addresses/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByAddressID(int id)
		{
			ApiResponse response = this.businessEntityAddressRepository.GetWhere(x => x.AddressID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByAddressTypeID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/AddressTypes/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByAddressTypeID(int id)
		{
			ApiResponse response = this.businessEntityAddressRepository.GetWhere(x => x.AddressTypeID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6601477038576f13ce6deefde6a690a8</Hash>
</Codenesium>*/