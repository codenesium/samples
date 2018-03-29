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
	public abstract class AbstractProductListPriceHistoriesController: AbstractEntityFrameworkApiController
	{
		protected IProductListPriceHistoryRepository _productListPriceHistoryRepository;
		protected IProductListPriceHistoryModelValidator _productListPriceHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductListPriceHistoriesController(
			ILogger<AbstractProductListPriceHistoriesController> logger,
			ApplicationContext context,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator
			) : base(logger,context)
		{
			this._productListPriceHistoryRepository = productListPriceHistoryRepository;
			this._productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
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
		[ProductListPriceHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productListPriceHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductListPriceHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productListPriceHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductListPriceHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductListPriceHistoryModel model)
		{
			this._productListPriceHistoryModelValidator.CreateMode();
			var validationResult = this._productListPriceHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productListPriceHistoryRepository.Create(model.StartDate,
				                                                        model.EndDate,
				                                                        model.ListPrice,
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
		[ProductListPriceHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductListPriceHistoryModel> models)
		{
			this._productListPriceHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productListPriceHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productListPriceHistoryRepository.Create(model.StartDate,
				                                               model.EndDate,
				                                               model.ListPrice,
				                                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductListPriceHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductID,ProductListPriceHistoryModel model)
		{
			this._productListPriceHistoryModelValidator.UpdateMode();
			var validationResult = this._productListPriceHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productListPriceHistoryRepository.Update(ProductID,  model.StartDate,
				                                               model.EndDate,
				                                               model.ListPrice,
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
		[ProductListPriceHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productListPriceHistoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductListPriceHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductListPriceHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			var response = new Response();

			this._productListPriceHistoryRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>232451e2147c934d09f221dffca2bf58</Hash>
</Codenesium>*/