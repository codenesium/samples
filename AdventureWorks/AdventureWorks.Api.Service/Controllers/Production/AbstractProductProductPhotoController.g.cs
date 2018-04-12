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
	public abstract class AbstractProductProductPhotoController: AbstractApiController
	{
		protected IProductProductPhotoRepository productProductPhotoRepository;

		protected IProductProductPhotoModelValidator productProductPhotoModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductProductPhotoController(
			ILogger<AbstractProductProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.productProductPhotoRepository = productProductPhotoRepository;
			this.productProductPhotoModelValidator = productProductPhotoModelValidator;
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
		[ProductProductPhotoFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productProductPhotoRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductProductPhotoFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productProductPhotoRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductProductPhotoModel model)
		{
			this.productProductPhotoModelValidator.CreateMode();
			var validationResult = this.productProductPhotoModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productProductPhotoRepository.Create(
					model.ProductPhotoID,
					model.Primary,
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
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductProductPhotoModel> models)
		{
			this.productProductPhotoModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.productProductPhotoModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.productProductPhotoRepository.Create(
					model.ProductPhotoID,
					model.Primary,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductProductPhotoModel model)
		{
			if (this.productProductPhotoRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.productProductPhotoModelValidator.UpdateMode();
			var validationResult = this.productProductPhotoModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productProductPhotoRepository.Update(
					id,
					model.ProductPhotoID,
					model.Primary,
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
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productProductPhotoRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductProductPhotoFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductProductPhotoes")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.productProductPhotoRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductPhotoID/{id}")]
		[ProductProductPhotoFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductPhotoes/{id}/ProductProductPhotoes")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductPhotoID(int id)
		{
			Response response = this.productProductPhotoRepository.GetWhere(x => x.ProductPhotoID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3dffcbdbe607939bbf8798256a3d8c7f</Hash>
</Codenesium>*/