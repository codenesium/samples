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
	public abstract class AbstractProductCostHistoriesController: AbstractEntityFrameworkApiController
	{
		protected IProductCostHistoryRepository _productCostHistoryRepository;
		protected IProductCostHistoryModelValidator _productCostHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductCostHistoriesController(
			ILogger<AbstractProductCostHistoriesController> logger,
			ApplicationContext context,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator
			) : base(logger,context)
		{
			this._productCostHistoryRepository = productCostHistoryRepository;
			this._productCostHistoryModelValidator = productCostHistoryModelValidator;
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
		[ProductCostHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productCostHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductCostHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productCostHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductCostHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductCostHistoryModel model)
		{
			this._productCostHistoryModelValidator.CreateMode();
			var validationResult = this._productCostHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productCostHistoryRepository.Create(model.StartDate,
				                                                   model.EndDate,
				                                                   model.StandardCost,
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
		[ProductCostHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductCostHistoryModel> models)
		{
			this._productCostHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productCostHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productCostHistoryRepository.Create(model.StartDate,
				                                          model.EndDate,
				                                          model.StandardCost,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductCostHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int productID,ProductCostHistoryModel model)
		{
			this._productCostHistoryModelValidator.UpdateMode();
			var validationResult = this._productCostHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productCostHistoryRepository.Update(productID,  model.StartDate,
				                                          model.EndDate,
				                                          model.StandardCost,
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
		[ProductCostHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productCostHistoryRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>80dfc179b931f4955b5246cd74b02c28</Hash>
</Codenesium>*/