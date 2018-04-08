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
	public abstract class AbstractSpecialOfferProductsController: AbstractApiController
	{
		protected ISpecialOfferProductRepository specialOfferProductRepository;
		protected ISpecialOfferProductModelValidator specialOfferProductModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSpecialOfferProductsController(
			ILogger<AbstractSpecialOfferProductsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductRepository specialOfferProductRepository,
			ISpecialOfferProductModelValidator specialOfferProductModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.specialOfferProductRepository = specialOfferProductRepository;
			this.specialOfferProductModelValidator = specialOfferProductModelValidator;
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
		[SpecialOfferProductFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.specialOfferProductRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SpecialOfferProductFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.specialOfferProductRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SpecialOfferProductModel model)
		{
			this.specialOfferProductModelValidator.CreateMode();
			var validationResult = this.specialOfferProductModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.specialOfferProductRepository.Create(model.ProductID,
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
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SpecialOfferProductModel> models)
		{
			this.specialOfferProductModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.specialOfferProductModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.specialOfferProductRepository.Create(model.ProductID,
				                                          model.Rowguid,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int SpecialOfferID,SpecialOfferProductModel model)
		{
			this.specialOfferProductModelValidator.UpdateMode();
			var validationResult = this.specialOfferProductModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.specialOfferProductRepository.Update(SpecialOfferID,  model.ProductID,
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
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.specialOfferProductRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("BySpecialOfferID/{id}")]
		[SpecialOfferProductFilter]
		[ReadOnlyFilter]
		[Route("~/api/SpecialOffers/{id}/SpecialOfferProducts")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySpecialOfferID(int id)
		{
			var response = new Response();

			this.specialOfferProductRepository.GetWhere(x => x.SpecialOfferID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[SpecialOfferProductFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/SpecialOfferProducts")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			var response = new Response();

			this.specialOfferProductRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f25a964d827d29f11f287ae32a9856cf</Hash>
</Codenesium>*/