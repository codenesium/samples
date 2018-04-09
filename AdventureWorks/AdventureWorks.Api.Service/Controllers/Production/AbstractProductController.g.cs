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
	public abstract class AbstractProductsController: AbstractApiController
	{
		protected IProductRepository productRepository;
		protected IProductModelValidator productModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductsController(
			ILogger<AbstractProductsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductRepository productRepository,
			IProductModelValidator productModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productRepository = productRepository;
			this.productModelValidator = productModelValidator;
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
		[ProductFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductModel model)
		{
			this.productModelValidator.CreateMode();
			var validationResult = this.productModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productRepository.Create(model.Name,
				                                       model.ProductNumber,
				                                       model.MakeFlag,
				                                       model.FinishedGoodsFlag,
				                                       model.Color,
				                                       model.SafetyStockLevel,
				                                       model.ReorderPoint,
				                                       model.StandardCost,
				                                       model.ListPrice,
				                                       model.Size,
				                                       model.SizeUnitMeasureCode,
				                                       model.WeightUnitMeasureCode,
				                                       model.Weight,
				                                       model.DaysToManufacture,
				                                       model.ProductLine,
				                                       model.@Class,
				                                       model.Style,
				                                       model.ProductSubcategoryID,
				                                       model.ProductModelID,
				                                       model.SellStartDate,
				                                       model.SellEndDate,
				                                       model.DiscontinuedDate,
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
		[ProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductModel> models)
		{
			this.productModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productRepository.Create(model.Name,
				                              model.ProductNumber,
				                              model.MakeFlag,
				                              model.FinishedGoodsFlag,
				                              model.Color,
				                              model.SafetyStockLevel,
				                              model.ReorderPoint,
				                              model.StandardCost,
				                              model.ListPrice,
				                              model.Size,
				                              model.SizeUnitMeasureCode,
				                              model.WeightUnitMeasureCode,
				                              model.Weight,
				                              model.DaysToManufacture,
				                              model.ProductLine,
				                              model.@Class,
				                              model.Style,
				                              model.ProductSubcategoryID,
				                              model.ProductModelID,
				                              model.SellStartDate,
				                              model.SellEndDate,
				                              model.DiscontinuedDate,
				                              model.Rowguid,
				                              model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,ProductModel model)
		{
			if(this.productRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.productModelValidator.UpdateMode();
			var validationResult = this.productModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productRepository.Update(id,  model.Name,
				                              model.ProductNumber,
				                              model.MakeFlag,
				                              model.FinishedGoodsFlag,
				                              model.Color,
				                              model.SafetyStockLevel,
				                              model.ReorderPoint,
				                              model.StandardCost,
				                              model.ListPrice,
				                              model.Size,
				                              model.SizeUnitMeasureCode,
				                              model.WeightUnitMeasureCode,
				                              model.Weight,
				                              model.DaysToManufacture,
				                              model.ProductLine,
				                              model.@Class,
				                              model.Style,
				                              model.ProductSubcategoryID,
				                              model.ProductModelID,
				                              model.SellStartDate,
				                              model.SellEndDate,
				                              model.DiscontinuedDate,
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
		[ProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("BySizeUnitMeasureCode/{id}")]
		[ProductFilter]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/Products")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySizeUnitMeasureCode(string id)
		{
			Response response = this.productRepository.GetWhere(x => x.SizeUnitMeasureCode == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByWeightUnitMeasureCode/{id}")]
		[ProductFilter]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/Products")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByWeightUnitMeasureCode(string id)
		{
			Response response = this.productRepository.GetWhere(x => x.WeightUnitMeasureCode == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByProductSubcategoryID/{id}")]
		[ProductFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductSubcategories/{id}/Products")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductSubcategoryID(int id)
		{
			Response response = this.productRepository.GetWhere(x => x.ProductSubcategoryID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ProductFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/Products")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			Response response = this.productRepository.GetWhere(x => x.ProductModelID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>002b5daedd277d94606b5a9c45e7d527</Hash>
</Codenesium>*/