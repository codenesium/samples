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
	public abstract class AbstractProductModelProductDescriptionCultureController: AbstractApiController
	{
		protected IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductModelProductDescriptionCultureController(
			ILogger<AbstractProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureRepository.GetById(id);
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
			ApiResponse response = this.productModelProductDescriptionCultureRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductModelProductDescriptionCultureModel model)
		{
			var id = this.productModelProductDescriptionCultureRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductModelProductDescriptionCultureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.productModelProductDescriptionCultureRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductModelProductDescriptionCultureModel model)
		{
			this.productModelProductDescriptionCultureRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productModelProductDescriptionCultureRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.ProductModelID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductDescriptionID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ProductDescriptions/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductDescriptionID(int id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.ProductDescriptionID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCultureID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Cultures/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCultureID(string id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.CultureID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e24e8280787bb6fb8196fa7388438d97</Hash>
</Codenesium>*/