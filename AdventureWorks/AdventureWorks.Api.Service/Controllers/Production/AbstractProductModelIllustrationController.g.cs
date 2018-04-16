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
	public abstract class AbstractProductModelIllustrationController: AbstractApiController
	{
		protected IProductModelIllustrationRepository productModelIllustrationRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductModelIllustrationController(
			ILogger<AbstractProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationRepository productModelIllustrationRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productModelIllustrationRepository.GetById(id);
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
			ApiResponse response = this.productModelIllustrationRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductModelIllustrationModel model)
		{
			var id = this.productModelIllustrationRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductModelIllustrationModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.productModelIllustrationRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductModelIllustrationModel model)
		{
			this.productModelIllustrationRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productModelIllustrationRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/ProductModelIllustrations")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			ApiResponse response = this.productModelIllustrationRepository.GetWhere(x => x.ProductModelID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByIllustrationID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Illustrations/{id}/ProductModelIllustrations")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByIllustrationID(int id)
		{
			ApiResponse response = this.productModelIllustrationRepository.GetWhere(x => x.IllustrationID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>39e4ab4e3b6fa07f9e226da65b6d798f</Hash>
</Codenesium>*/