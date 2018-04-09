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
	public abstract class AbstractProductModelProductDescriptionCulturesController: AbstractApiController
	{
		protected IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;
		protected IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductModelProductDescriptionCulturesController(
			ILogger<AbstractProductModelProductDescriptionCulturesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
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
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productModelProductDescriptionCultureRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductModelProductDescriptionCultureModel model)
		{
			this.productModelProductDescriptionCultureModelValidator.CreateMode();
			var validationResult = this.productModelProductDescriptionCultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productModelProductDescriptionCultureRepository.Create(model.ProductDescriptionID,
				                                                                     model.CultureID,
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
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductModelProductDescriptionCultureModel> models)
		{
			this.productModelProductDescriptionCultureModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productModelProductDescriptionCultureModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productModelProductDescriptionCultureRepository.Create(model.ProductDescriptionID,
				                                                            model.CultureID,
				                                                            model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,ProductModelProductDescriptionCultureModel model)
		{
			if(this.productModelProductDescriptionCultureRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.productModelProductDescriptionCultureModelValidator.UpdateMode();
			var validationResult = this.productModelProductDescriptionCultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productModelProductDescriptionCultureRepository.Update(id,  model.ProductDescriptionID,
				                                                            model.CultureID,
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
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productModelProductDescriptionCultureRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.ProductModelID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByProductDescriptionID/{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductDescriptions/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductDescriptionID(int id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.ProductDescriptionID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByCultureID/{id}")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[Route("~/api/Cultures/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCultureID(string id)
		{
			Response response = this.productModelProductDescriptionCultureRepository.GetWhere(x => x.CultureID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>b5f46de4915fab6514eec856ca58a315</Hash>
</Codenesium>*/