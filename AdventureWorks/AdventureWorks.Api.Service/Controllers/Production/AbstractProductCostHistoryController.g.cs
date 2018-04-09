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
	public abstract class AbstractProductCostHistoriesController: AbstractApiController
	{
		protected IProductCostHistoryRepository productCostHistoryRepository;
		protected IProductCostHistoryModelValidator productCostHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductCostHistoriesController(
			ILogger<AbstractProductCostHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productCostHistoryRepository = productCostHistoryRepository;
			this.productCostHistoryModelValidator = productCostHistoryModelValidator;
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
			Response response = this.productCostHistoryRepository.GetById(id);
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
			Response response = this.productCostHistoryRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.productCostHistoryModelValidator.CreateMode();
			var validationResult = this.productCostHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productCostHistoryRepository.Create(model.StartDate,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductCostHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductCostHistoryModel> models)
		{
			this.productCostHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productCostHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productCostHistoryRepository.Create(model.StartDate,
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
		public virtual IActionResult Update(int id,ProductCostHistoryModel model)
		{
			if(this.productCostHistoryRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.productCostHistoryModelValidator.UpdateMode();
			var validationResult = this.productCostHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productCostHistoryRepository.Update(id,  model.StartDate,
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
			this.productCostHistoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductCostHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductCostHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.productCostHistoryRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>509216c97aecae29ba5831ddeb7e051a</Hash>
</Codenesium>*/