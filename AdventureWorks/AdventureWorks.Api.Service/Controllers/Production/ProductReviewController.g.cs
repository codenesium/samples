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
	public abstract class AbstractProductReviewsController: AbstractEntityFrameworkApiController
	{
		protected IProductReviewRepository _productReviewRepository;
		protected IProductReviewModelValidator _productReviewModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductReviewsController(
			ILogger<AbstractProductReviewsController> logger,
			ApplicationContext context,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator
			) : base(logger,context)
		{
			this._productReviewRepository = productReviewRepository;
			this._productReviewModelValidator = productReviewModelValidator;
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
		[ProductReviewFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productReviewRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductReviewFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productReviewRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductReviewFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductReviewModel model)
		{
			this._productReviewModelValidator.CreateMode();
			var validationResult = this._productReviewModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productReviewRepository.Create(model.ProductID,
				                                              model.ReviewerName,
				                                              model.ReviewDate,
				                                              model.EmailAddress,
				                                              model.Rating,
				                                              model.Comments,
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
		[ProductReviewFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductReviewModel> models)
		{
			this._productReviewModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productReviewModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productReviewRepository.Create(model.ProductID,
				                                     model.ReviewerName,
				                                     model.ReviewDate,
				                                     model.EmailAddress,
				                                     model.Rating,
				                                     model.Comments,
				                                     model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductReviewFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductReviewID,ProductReviewModel model)
		{
			this._productReviewModelValidator.UpdateMode();
			var validationResult = this._productReviewModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productReviewRepository.Update(ProductReviewID,  model.ProductID,
				                                     model.ReviewerName,
				                                     model.ReviewDate,
				                                     model.EmailAddress,
				                                     model.Rating,
				                                     model.Comments,
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
		[ProductReviewFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productReviewRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductReviewFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductReviews")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			var response = new Response();

			this._productReviewRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6f8a43cc964e9e64021184fd66355c9c</Hash>
</Codenesium>*/