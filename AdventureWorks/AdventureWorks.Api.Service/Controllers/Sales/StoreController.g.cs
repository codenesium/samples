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
	public abstract class AbstractStoresController: AbstractEntityFrameworkApiController
	{
		protected IStoreRepository _storeRepository;
		protected IStoreModelValidator _storeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractStoresController(
			ILogger<AbstractStoresController> logger,
			ApplicationContext context,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator
			) : base(logger,context)
		{
			this._storeRepository = storeRepository;
			this._storeModelValidator = storeModelValidator;
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
		[StoreFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._storeRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[StoreFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._storeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[StoreFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(StoreModel model)
		{
			this._storeModelValidator.CreateMode();
			var validationResult = this._storeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._storeRepository.Create(model.Name,
				                                      model.SalesPersonID,
				                                      model.Demographics,
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
		[StoreFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<StoreModel> models)
		{
			this._storeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._storeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._storeRepository.Create(model.Name,
				                             model.SalesPersonID,
				                             model.Demographics,
				                             model.Rowguid,
				                             model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[StoreFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,StoreModel model)
		{
			this._storeModelValidator.UpdateMode();
			var validationResult = this._storeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._storeRepository.Update(BusinessEntityID,  model.Name,
				                             model.SalesPersonID,
				                             model.Demographics,
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
		[StoreFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._storeRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[StoreFilter]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/Stores")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this._storeRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("BySalesPersonID/{id}")]
		[StoreFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesPersons/{id}/Stores")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesPersonID(int id)
		{
			var response = new Response();

			this._storeRepository.GetWhere(x => x.SalesPersonID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>97283a2a0e218ba4e89c00c2efac8b2c</Hash>
</Codenesium>*/