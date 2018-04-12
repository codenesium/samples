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
	public abstract class AbstractProductInventoryController: AbstractApiController
	{
		protected IProductInventoryRepository productInventoryRepository;

		protected IProductInventoryModelValidator productInventoryModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductInventoryController(
			ILogger<AbstractProductInventoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductInventoryRepository productInventoryRepository,
			IProductInventoryModelValidator productInventoryModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.productInventoryRepository = productInventoryRepository;
			this.productInventoryModelValidator = productInventoryModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productInventoryRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productInventoryRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductInventoryModel model)
		{
			this.productInventoryModelValidator.CreateMode();
			var validationResult = this.productInventoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productInventoryRepository.Create(
					model.LocationID,
					model.Shelf,
					model.Bin,
					model.Quantity,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductInventoryModel> models)
		{
			this.productInventoryModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.productInventoryModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.productInventoryRepository.Create(
					model.LocationID,
					model.Shelf,
					model.Bin,
					model.Quantity,
					model.Rowguid,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductInventoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductInventoryModel model)
		{
			if (this.productInventoryRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.productInventoryModelValidator.UpdateMode();
			var validationResult = this.productInventoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productInventoryRepository.Update(
					id,
					model.LocationID,
					model.Shelf,
					model.Bin,
					model.Quantity,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
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
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductInventories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.productInventoryRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByLocationID/{id}")]
		[ProductInventoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Locations/{id}/ProductInventories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLocationID(short id)
		{
			Response response = this.productInventoryRepository.GetWhere(x => x.LocationID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>96aeb53de889bba5c1fec2dac83614b3</Hash>
</Codenesium>*/