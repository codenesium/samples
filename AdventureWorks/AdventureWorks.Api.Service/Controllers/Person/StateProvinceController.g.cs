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
	public abstract class AbstractStateProvincesController: AbstractEntityFrameworkApiController
	{
		protected IStateProvinceRepository _stateProvinceRepository;
		protected IStateProvinceModelValidator _stateProvinceModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractStateProvincesController(
			ILogger<AbstractStateProvincesController> logger,
			ApplicationContext context,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator
			) : base(logger,context)
		{
			this._stateProvinceRepository = stateProvinceRepository;
			this._stateProvinceModelValidator = stateProvinceModelValidator;
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
			Response response = new Response();

			this._stateProvinceRepository.GetById(id,response);
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
			Response response = new Response();

			this._stateProvinceRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._stateProvinceModelValidator.CreateMode();
			var validationResult = this._stateProvinceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._stateProvinceRepository.Create(model.StateProvinceCode,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[StateProvinceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<StateProvinceModel> models)
		{
			this._stateProvinceModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._stateProvinceModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._stateProvinceRepository.Create(model.StateProvinceCode,
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
		public virtual IActionResult Update(int StateProvinceID,StateProvinceModel model)
		{
			this._stateProvinceModelValidator.UpdateMode();
			var validationResult = this._stateProvinceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._stateProvinceRepository.Update(StateProvinceID,  model.StateProvinceCode,
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
			this._stateProvinceRepository.Delete(id);
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
			var response = new Response();

			this._stateProvinceRepository.GetWhere(x => x.CountryRegionCode == id, response);
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
			var response = new Response();

			this._stateProvinceRepository.GetWhere(x => x.TerritoryID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c6e05f425c971e2bbca62bb1dd172b39</Hash>
</Codenesium>*/