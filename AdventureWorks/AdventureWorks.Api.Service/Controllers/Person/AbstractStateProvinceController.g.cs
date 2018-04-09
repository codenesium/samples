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
	public abstract class AbstractStateProvincesController: AbstractApiController
	{
		protected IStateProvinceRepository stateProvinceRepository;
		protected IStateProvinceModelValidator stateProvinceModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractStateProvincesController(
			ILogger<AbstractStateProvincesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
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
		[StateProvinceFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.stateProvinceRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[StateProvinceFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.stateProvinceRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[StateProvinceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(StateProvinceModel model)
		{
			this.stateProvinceModelValidator.CreateMode();
			var validationResult = this.stateProvinceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.stateProvinceRepository.Create(model.StateProvinceCode,
				                                             model.CountryRegionCode,
				                                             model.IsOnlyStateProvinceFlag,
				                                             model.Name,
				                                             model.TerritoryID,
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
		[StateProvinceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<StateProvinceModel> models)
		{
			this.stateProvinceModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.stateProvinceModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.stateProvinceRepository.Create(model.StateProvinceCode,
				                                    model.CountryRegionCode,
				                                    model.IsOnlyStateProvinceFlag,
				                                    model.Name,
				                                    model.TerritoryID,
				                                    model.Rowguid,
				                                    model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[StateProvinceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,StateProvinceModel model)
		{
			if(this.stateProvinceRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.stateProvinceModelValidator.UpdateMode();
			var validationResult = this.stateProvinceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.stateProvinceRepository.Update(id,  model.StateProvinceCode,
				                                    model.CountryRegionCode,
				                                    model.IsOnlyStateProvinceFlag,
				                                    model.Name,
				                                    model.TerritoryID,
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
		[StateProvinceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.stateProvinceRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[StateProvinceFilter]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/StateProvinces")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			Response response = this.stateProvinceRepository.GetWhere(x => x.CountryRegionCode == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[StateProvinceFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/StateProvinces")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			Response response = this.stateProvinceRepository.GetWhere(x => x.TerritoryID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>490341d5d52e24790a83d445f3c51397</Hash>
</Codenesium>*/