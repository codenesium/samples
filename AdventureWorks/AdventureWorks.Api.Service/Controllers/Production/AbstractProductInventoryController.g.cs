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
	public abstract class AbstractProductInventoriesController: AbstractApiController
	{
		protected IProductInventoryRepository productInventoryRepository;
		protected IProductInventoryModelValidator productInventoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductInventoriesController(
			ILogger<AbstractProductInventoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductInventoryRepository productInventoryRepository,
			IProductInventoryModelValidator productInventoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productInventoryRepository = productInventoryRepository;
			this.productInventoryModelValidator = productInventoryModelValidator;
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
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.productInventoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.productInventoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductInventoryModel model)
		{
			this.productInventoryModelValidator.CreateMode();
			var validationResult = this.productInventoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productInventoryRepository.Create(model.LocationID,
				                                                model.Shelf,
				                                                model.Bin,
				                                                model.Quantity,
				                                                model.Rowguid,
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
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductInventoryModel> models)
		{
			this.productInventoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productInventoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productInventoryRepository.Create(model.LocationID,
				                                       model.Shelf,
				                                       model.Bin,
				                                       model.Quantity,
				                                       model.Rowguid,
				                                       model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductID,ProductInventoryModel model)
		{
			this.productInventoryModelValidator.UpdateMode();
			var validationResult = this.productInventoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productInventoryRepository.Update(ProductID,  model.LocationID,
				                                       model.Shelf,
				                                       model.Bin,
				                                       model.Quantity,
				                                       model.Rowguid,
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
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productInventoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductInventories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			var response = new Response();

			this.productInventoryRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByLocationID/{id}")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Locations/{id}/ProductInventories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLocationID(short id)
		{
			var response = new Response();

			this.productInventoryRepository.GetWhere(x => x.LocationID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1781f56a81bc05dcc32e33e31f67452c</Hash>
</Codenesium>*/