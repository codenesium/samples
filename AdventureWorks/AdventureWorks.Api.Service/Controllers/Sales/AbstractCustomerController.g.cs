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
	public abstract class AbstractCustomersController: AbstractApiController
	{
		protected ICustomerRepository customerRepository;
		protected ICustomerModelValidator customerModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCustomersController(
			ILogger<AbstractCustomersController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerRepository customerRepository,
			ICustomerModelValidator customerModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.customerRepository = customerRepository;
			this.customerModelValidator = customerModelValidator;
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
		[CustomerFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.customerRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CustomerFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.customerRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CustomerFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(CustomerModel model)
		{
			this.customerModelValidator.CreateMode();
			var validationResult = this.customerModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.customerRepository.Create(model.PersonID,
				                                        model.StoreID,
				                                        model.TerritoryID,
				                                        model.AccountNumber,
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
		[CustomerFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<CustomerModel> models)
		{
			this.customerModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.customerModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.customerRepository.Create(model.PersonID,
				                               model.StoreID,
				                               model.TerritoryID,
				                               model.AccountNumber,
				                               model.Rowguid,
				                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CustomerFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int CustomerID,CustomerModel model)
		{
			this.customerModelValidator.UpdateMode();
			var validationResult = this.customerModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.customerRepository.Update(CustomerID,  model.PersonID,
				                               model.StoreID,
				                               model.TerritoryID,
				                               model.AccountNumber,
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
		[CustomerFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.customerRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByPersonID/{id}")]
		[CustomerFilter]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/Customers")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPersonID(int id)
		{
			var response = new Response();

			this.customerRepository.GetWhere(x => x.PersonID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByStoreID/{id}")]
		[CustomerFilter]
		[ReadOnlyFilter]
		[Route("~/api/Stores/{id}/Customers")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStoreID(int id)
		{
			var response = new Response();

			this.customerRepository.GetWhere(x => x.StoreID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[CustomerFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/Customers")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			var response = new Response();

			this.customerRepository.GetWhere(x => x.TerritoryID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a9f50f73cbd980d8291f3f322a602ee8</Hash>
</Codenesium>*/