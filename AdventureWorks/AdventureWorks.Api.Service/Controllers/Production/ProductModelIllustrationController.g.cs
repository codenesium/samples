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
	public abstract class AbstractProductModelIllustrationsController: AbstractEntityFrameworkApiController
	{
		protected IProductModelIllustrationRepository _productModelIllustrationRepository;
		protected IProductModelIllustrationModelValidator _productModelIllustrationModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductModelIllustrationsController(
			ILogger<AbstractProductModelIllustrationsController> logger,
			ApplicationContext context,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator
			) : base(logger,context)
		{
			this._productModelIllustrationRepository = productModelIllustrationRepository;
			this._productModelIllustrationModelValidator = productModelIllustrationModelValidator;
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
			Response response = new Response();

			this._productModelIllustrationRepository.GetById(id,response);
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
			Response response = new Response();

			this._productModelIllustrationRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._productModelIllustrationModelValidator.CreateMode();
			var validationResult = this._productModelIllustrationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productModelIllustrationRepository.Create(model.IllustrationID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[ProductModelIllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductModelIllustrationModel> models)
		{
			this._productModelIllustrationModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productModelIllustrationModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productModelIllustrationRepository.Create(model.IllustrationID,
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
		public virtual IActionResult Update(int ProductModelID,ProductModelIllustrationModel model)
		{
			this._productModelIllustrationModelValidator.UpdateMode();
			var validationResult = this._productModelIllustrationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productModelIllustrationRepository.Update(ProductModelID,  model.IllustrationID,
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
			this._productModelIllustrationRepository.Delete(id);
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
			var response = new Response();

			this._productModelIllustrationRepository.GetWhere(x => x.ProductModelID == id, response);
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
			var response = new Response();

			this._productModelIllustrationRepository.GetWhere(x => x.IllustrationID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d3a721627266cd772356916b9b91b910</Hash>
</Codenesium>*/