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
	public abstract class AbstractSpecialOfferProductController: AbstractApiController
	{
		protected ISpecialOfferProductRepository specialOfferProductRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpecialOfferProductController(
			ILogger<AbstractSpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductRepository specialOfferProductRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.specialOfferProductRepository = specialOfferProductRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.specialOfferProductRepository.GetById(id);
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
			ApiResponse response = this.specialOfferProductRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SpecialOfferProductModel model)
		{
			var id = this.specialOfferProductRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SpecialOfferProductModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.specialOfferProductRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SpecialOfferProductModel model)
		{
			this.specialOfferProductRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.specialOfferProductRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("BySpecialOfferID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SpecialOffers/{id}/SpecialOfferProducts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpecialOfferID(int id)
		{
			ApiResponse response = this.specialOfferProductRepository.GetWhere(x => x.SpecialOfferID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/SpecialOfferProducts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			ApiResponse response = this.specialOfferProductRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>8981a7d3d44c8c9c026025ce25f6557d</Hash>
</Codenesium>*/