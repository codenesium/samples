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
	public abstract class AbstractProductVendorsController: AbstractApiController
	{
		protected IProductVendorRepository productVendorRepository;
		protected IProductVendorModelValidator productVendorModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductVendorsController(
			ILogger<AbstractProductVendorsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductVendorRepository productVendorRepository,
			IProductVendorModelValidator productVendorModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productVendorRepository = productVendorRepository;
			this.productVendorModelValidator = productVendorModelValidator;
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
		[ProductVendorFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productVendorRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductVendorFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productVendorRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductVendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductVendorModel model)
		{
			this.productVendorModelValidator.CreateMode();
			var validationResult = this.productVendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productVendorRepository.Create(model.BusinessEntityID,
				                                             model.AverageLeadTime,
				                                             model.StandardPrice,
				                                             model.LastReceiptCost,
				                                             model.LastReceiptDate,
				                                             model.MinOrderQty,
				                                             model.MaxOrderQty,
				                                             model.OnOrderQty,
				                                             model.UnitMeasureCode,
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
		[ProductVendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductVendorModel> models)
		{
			this.productVendorModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productVendorModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productVendorRepository.Create(model.BusinessEntityID,
				                                    model.AverageLeadTime,
				                                    model.StandardPrice,
				                                    model.LastReceiptCost,
				                                    model.LastReceiptDate,
				                                    model.MinOrderQty,
				                                    model.MaxOrderQty,
				                                    model.OnOrderQty,
				                                    model.UnitMeasureCode,
				                                    model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductVendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,ProductVendorModel model)
		{
			if(this.productVendorRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.productVendorModelValidator.UpdateMode();
			var validationResult = this.productVendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productVendorRepository.Update(id,  model.BusinessEntityID,
				                                    model.AverageLeadTime,
				                                    model.StandardPrice,
				                                    model.LastReceiptCost,
				                                    model.LastReceiptDate,
				                                    model.MinOrderQty,
				                                    model.MaxOrderQty,
				                                    model.OnOrderQty,
				                                    model.UnitMeasureCode,
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
		[ProductVendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productVendorRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductVendorFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductVendors")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.productVendorRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ProductVendorFilter]
		[ReadOnlyFilter]
		[Route("~/api/Vendors/{id}/ProductVendors")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.productVendorRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[ProductVendorFilter]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/ProductVendors")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			Response response = this.productVendorRepository.GetWhere(x => x.UnitMeasureCode == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c61324270f1b1f168a7803ba79b62f7d</Hash>
</Codenesium>*/