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
	public abstract class AbstractProductVendorsController: AbstractEntityFrameworkApiController
	{
		protected IProductVendorRepository _productVendorRepository;
		protected IProductVendorModelValidator _productVendorModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductVendorsController(
			ILogger<AbstractProductVendorsController> logger,
			ApplicationContext context,
			IProductVendorRepository productVendorRepository,
			IProductVendorModelValidator productVendorModelValidator
			) : base(logger,context)
		{
			this._productVendorRepository = productVendorRepository;
			this._productVendorModelValidator = productVendorModelValidator;
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
			Response response = new Response();

			this._productVendorRepository.GetById(id,response);
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
			Response response = new Response();

			this._productVendorRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._productVendorModelValidator.CreateMode();
			var validationResult = this._productVendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productVendorRepository.Create(model.BusinessEntityID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[ProductVendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductVendorModel> models)
		{
			this._productVendorModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productVendorModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productVendorRepository.Create(model.BusinessEntityID,
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
		public virtual IActionResult Update(int ProductID,ProductVendorModel model)
		{
			this._productVendorModelValidator.UpdateMode();
			var validationResult = this._productVendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productVendorRepository.Update(ProductID,  model.BusinessEntityID,
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
			this._productVendorRepository.Delete(id);
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
			var response = new Response();

			this._productVendorRepository.GetWhere(x => x.ProductID == id, response);
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
			var response = new Response();

			this._productVendorRepository.GetWhere(x => x.BusinessEntityID == id, response);
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
			var response = new Response();

			this._productVendorRepository.GetWhere(x => x.UnitMeasureCode == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a04070d95a7cdb76c8877ff63bda0805</Hash>
</Codenesium>*/