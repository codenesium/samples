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
	public abstract class AbstractProductInventoriesController: AbstractEntityFrameworkApiController
	{
		protected IProductInventoryRepository _productInventoryRepository;
		protected IProductInventoryModelValidator _productInventoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductInventoriesController(
			ILogger<AbstractProductInventoriesController> logger,
			ApplicationContext context,
			IProductInventoryRepository productInventoryRepository,
			IProductInventoryModelValidator productInventoryModelValidator
			) : base(logger,context)
		{
			this._productInventoryRepository = productInventoryRepository;
			this._productInventoryModelValidator = productInventoryModelValidator;
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

			this._productInventoryRepository.GetById(id,response);
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

			this._productInventoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._productInventoryModelValidator.CreateMode();
			var validationResult = this._productInventoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productInventoryRepository.Create(model.LocationID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductInventoryModel> models)
		{
			this._productInventoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productInventoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productInventoryRepository.Create(model.LocationID,
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
			this._productInventoryModelValidator.UpdateMode();
			var validationResult = this._productInventoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productInventoryRepository.Update(ProductID,  model.LocationID,
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
			this._productInventoryRepository.Delete(id);
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

			this._productInventoryRepository.GetWhere(x => x.ProductID == id, response);
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

			this._productInventoryRepository.GetWhere(x => x.LocationID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e95907354746fd6bedffeffa9042d3f1</Hash>
</Codenesium>*/