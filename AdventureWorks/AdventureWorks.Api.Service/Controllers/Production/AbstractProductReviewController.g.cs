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
	public abstract class AbstractProductReviewsController: AbstractApiController
	{
		protected IProductReviewRepository productReviewRepository;
		protected IProductReviewModelValidator productReviewModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductReviewsController(
			ILogger<AbstractProductReviewsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productReviewRepository = productReviewRepository;
			this.productReviewModelValidator = productReviewModelValidator;
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

			this.productReviewRepository.GetById(id,response);
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

			this.productReviewRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.productReviewModelValidator.CreateMode();
			var validationResult = this.productReviewModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productReviewRepository.Create(model.ProductID,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductReviewFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductReviewModel> models)
		{
			this.productReviewModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productReviewModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productReviewRepository.Create(model.ProductID,
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
			this.productReviewModelValidator.UpdateMode();
			var validationResult = this.productReviewModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productReviewRepository.Update(ProductReviewID,  model.ProductID,
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
			this.productReviewRepository.Delete(id);
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

			this.productReviewRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a77e57ad04e194ab077ad57b02a80e8d</Hash>
</Codenesium>*/