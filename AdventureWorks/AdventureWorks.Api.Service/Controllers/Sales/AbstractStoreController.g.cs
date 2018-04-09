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
	public abstract class AbstractStoresController: AbstractApiController
	{
		protected IStoreRepository storeRepository;
		protected IStoreModelValidator storeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractStoresController(
			ILogger<AbstractStoresController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.storeRepository = storeRepository;
			this.storeModelValidator = storeModelValidator;
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
			Response response = this.storeRepository.GetById(id);
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
			Response response = this.storeRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.storeModelValidator.CreateMode();
			var validationResult = this.storeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.storeRepository.Create(model.Name,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[StoreFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<StoreModel> models)
		{
			this.storeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.storeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.storeRepository.Create(model.Name,
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
		public virtual IActionResult Update(int id,StoreModel model)
		{
			if(this.storeRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.storeModelValidator.UpdateMode();
			var validationResult = this.storeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.storeRepository.Update(id,  model.Name,
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
			this.storeRepository.Delete(id);
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
			Response response = this.storeRepository.GetWhere(x => x.BusinessEntityID == id);
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
			Response response = this.storeRepository.GetWhere(x => x.SalesPersonID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>ad66d3501e1a62a81f633b2e72b8002b</Hash>
</Codenesium>*/