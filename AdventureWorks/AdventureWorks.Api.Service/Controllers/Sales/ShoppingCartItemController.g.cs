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
	public abstract class AbstractShoppingCartItemsController: AbstractEntityFrameworkApiController
	{
		protected IShoppingCartItemRepository _shoppingCartItemRepository;
		protected IShoppingCartItemModelValidator _shoppingCartItemModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractShoppingCartItemsController(
			ILogger<AbstractShoppingCartItemsController> logger,
			ApplicationContext context,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator
			) : base(logger,context)
		{
			this._shoppingCartItemRepository = shoppingCartItemRepository;
			this._shoppingCartItemModelValidator = shoppingCartItemModelValidator;
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

			this._shoppingCartItemRepository.GetById(id,response);
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

			this._shoppingCartItemRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._shoppingCartItemModelValidator.CreateMode();
			var validationResult = this._shoppingCartItemModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._shoppingCartItemRepository.Create(model.ShoppingCartID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[ShoppingCartItemFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ShoppingCartItemModel> models)
		{
			this._shoppingCartItemModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._shoppingCartItemModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._shoppingCartItemRepository.Create(model.ShoppingCartID,
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
		public virtual IActionResult Update(int shoppingCartItemID,ShoppingCartItemModel model)
		{
			this._shoppingCartItemModelValidator.UpdateMode();
			var validationResult = this._shoppingCartItemModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._shoppingCartItemRepository.Update(shoppingCartItemID,  model.ShoppingCartID,
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
			this._shoppingCartItemRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>ad28ee189e6fc5df141e23786c3627f1</Hash>
</Codenesium>*/