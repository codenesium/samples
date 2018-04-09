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
	public abstract class AbstractProductModelIllustrationsController: AbstractApiController
	{
		protected IProductModelIllustrationRepository productModelIllustrationRepository;
		protected IProductModelIllustrationModelValidator productModelIllustrationModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductModelIllustrationsController(
			ILogger<AbstractProductModelIllustrationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
			this.productModelIllustrationModelValidator = productModelIllustrationModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ProductModelIllustrationFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productModelIllustrationRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductModelIllustrationFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productModelIllustrationRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductModelIllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductModelIllustrationModel model)
		{
			this.productModelIllustrationModelValidator.CreateMode();
			var validationResult = this.productModelIllustrationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productModelIllustrationRepository.Create(model.IllustrationID,
				                                                        model.ModifiedDate);
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductModelIllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductModelIllustrationModel> models)
		{
			this.productModelIllustrationModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productModelIllustrationModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productModelIllustrationRepository.Create(model.IllustrationID,
				                                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelIllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,ProductModelIllustrationModel model)
		{
			if(this.productModelIllustrationRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.productModelIllustrationModelValidator.UpdateMode();
			var validationResult = this.productModelIllustrationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productModelIllustrationRepository.Update(id,  model.IllustrationID,
				                                               model.ModifiedDate);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelIllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productModelIllustrationRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ProductModelIllustrationFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/ProductModelIllustrations")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			Response response = this.productModelIllustrationRepository.GetWhere(x => x.ProductModelID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByIllustrationID/{id}")]
		[ProductModelIllustrationFilter]
		[ReadOnlyFilter]
		[Route("~/api/Illustrations/{id}/ProductModelIllustrations")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByIllustrationID(int id)
		{
			Response response = this.productModelIllustrationRepository.GetWhere(x => x.IllustrationID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>328242a7a87a6bd3f99de71e3b752ec6</Hash>
</Codenesium>*/