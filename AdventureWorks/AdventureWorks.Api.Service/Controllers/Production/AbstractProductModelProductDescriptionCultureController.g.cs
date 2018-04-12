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

		protected IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductModelProductDescriptionCultureController(
			ILogger<AbstractProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productModelProductDescriptionCultureRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductModelProductDescriptionCultureModel model)
		{
			this.productModelProductDescriptionCultureModelValidator.CreateMode();
			var validationResult = this.productModelProductDescriptionCultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productModelProductDescriptionCultureRepository.Create(
					model.ProductDescriptionID,
					model.CultureID,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductModelProductDescriptionCultureModel> models)
		{
			this.productModelProductDescriptionCultureModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.productModelProductDescriptionCultureModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.productModelProductDescriptionCultureRepository.Create(
					model.ProductDescriptionID,
					model.CultureID,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductModelProductDescriptionCultureModel model)
		{
			if (this.productModelProductDescriptionCultureRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.productModelProductDescriptionCultureModelValidator.UpdateMode();
			var validationResult = this.productModelProductDescriptionCultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productModelProductDescriptionCultureRepository.Update(
					id,
					model.ProductDescriptionID,
					model.CultureID,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productModelProductDescriptionCultureRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.ProductModelID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductDescriptionID/{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductDescriptions/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductDescriptionID(int id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.ProductDescriptionID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCultureID/{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[Route("~/api/Cultures/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCultureID(string id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.CultureID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>61d318d9b7c60482467665075e442c2c</Hash>
</Codenesium>*/