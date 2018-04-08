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
	public abstract class AbstractProductListPriceHistoriesController: AbstractApiController
	{
		protected IProductListPriceHistoryRepository productListPriceHistoryRepository;
		protected IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductListPriceHistoriesController(
			ILogger<AbstractProductListPriceHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productListPriceHistoryRepository = productListPriceHistoryRepository;
			this.productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
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

			this.productListPriceHistoryRepository.GetById(id,response);
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

			this.productListPriceHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.productListPriceHistoryModelValidator.CreateMode();
			var validationResult = this.productListPriceHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productListPriceHistoryRepository.Create(model.StartDate,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductListPriceHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductListPriceHistoryModel> models)
		{
			this.productListPriceHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productListPriceHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productListPriceHistoryRepository.Create(model.StartDate,
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
			this.productListPriceHistoryModelValidator.UpdateMode();
			var validationResult = this.productListPriceHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productListPriceHistoryRepository.Update(ProductID,  model.StartDate,
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
			this.productListPriceHistoryRepository.Delete(id);
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

			this.productListPriceHistoryRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>477f7468d885af4b8502b03d199ca94f</Hash>
</Codenesium>*/