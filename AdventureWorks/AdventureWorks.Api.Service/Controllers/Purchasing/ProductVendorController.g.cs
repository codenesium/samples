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
		public virtual IActionResult Update(int productID,ProductVendorModel model)
		{
			this._productVendorModelValidator.UpdateMode();
			var validationResult = this._productVendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productVendorRepository.Update(productID,  model.BusinessEntityID,
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
	}
}

/*<Codenesium>
    <Hash>9c80a143958ef87cbfad257d2fead6b4</Hash>
</Codenesium>*/