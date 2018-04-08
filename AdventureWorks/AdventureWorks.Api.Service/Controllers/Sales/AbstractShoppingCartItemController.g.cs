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
	public abstract class AbstractShoppingCartItemsController: AbstractApiController
	{
		protected IShoppingCartItemRepository shoppingCartItemRepository;
		protected IShoppingCartItemModelValidator shoppingCartItemModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractShoppingCartItemsController(
			ILogger<AbstractShoppingCartItemsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.shoppingCartItemRepository = shoppingCartItemRepository;
			this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
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
		[ShoppingCartItemFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.shoppingCartItemRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ShoppingCartItemFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.shoppingCartItemRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ShoppingCartItemFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ShoppingCartItemModel model)
		{
			this.shoppingCartItemModelValidator.CreateMode();
			var validationResult = this.shoppingCartItemModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.shoppingCartItemRepository.Create(model.ShoppingCartID,
				                                                model.Quantity,
				                                                model.ProductID,
				                                                model.DateCreated,
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
		[ShoppingCartItemFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ShoppingCartItemModel> models)
		{
			this.shoppingCartItemModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.shoppingCartItemModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.shoppingCartItemRepository.Create(model.ShoppingCartID,
				                                       model.Quantity,
				                                       model.ProductID,
				                                       model.DateCreated,
				                                       model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ShoppingCartItemFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ShoppingCartItemID,ShoppingCartItemModel model)
		{
			this.shoppingCartItemModelValidator.UpdateMode();
			var validationResult = this.shoppingCartItemModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.shoppingCartItemRepository.Update(ShoppingCartItemID,  model.ShoppingCartID,
				                                       model.Quantity,
				                                       model.ProductID,
				                                       model.DateCreated,
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
		[ShoppingCartItemFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.shoppingCartItemRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ShoppingCartItemFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ShoppingCartItems")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			var response = new Response();

			this.shoppingCartItemRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>95ce3466c8ad859dfbcc8c7ab8742b9d</Hash>
</Codenesium>*/