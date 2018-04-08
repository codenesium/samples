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
			Response response = new Response();

			this.productRepository.GetById(id,response);
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
			Response response = new Response();

			this.productRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
		public virtual IActionResult Update(int ProductID,ProductModel model)
		{
			this.productModelValidator.UpdateMode();
			var validationResult = this.productModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productRepository.Update(ProductID,  model.Name,
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
			var response = new Response();

			this.productRepository.GetWhere(x => x.SizeUnitMeasureCode == id, response);
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
			var response = new Response();

			this.productRepository.GetWhere(x => x.WeightUnitMeasureCode == id, response);
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
			var response = new Response();

			this.productRepository.GetWhere(x => x.ProductSubcategoryID == id, response);
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
			var response = new Response();

			this.productRepository.GetWhere(x => x.ProductModelID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>799ae27abdbd67e735a3d7f5124f94bb</Hash>
</Codenesium>*/