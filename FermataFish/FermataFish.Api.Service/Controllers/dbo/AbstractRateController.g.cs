using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractRateController: AbstractApiController
	{
		protected IRateRepository rateRepository;

		protected IRateModelValidator rateModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractRateController(
			ILogger<AbstractRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRateRepository rateRepository,
			IRateModelValidator rateModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.rateRepository = rateRepository;
			this.rateModelValidator = rateModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[RateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.rateRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[RateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.rateRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[RateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(RateModel model)
		{
			this.rateModelValidator.CreateMode();
			var validationResult = this.rateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.rateRepository.Create(
					model.AmountPerMinute,
					model.TeacherSkillId,
					model.TeacherId);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[RateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<RateModel> models)
		{
			this.rateModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.rateModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.rateRepository.Create(
					model.AmountPerMinute,
					model.TeacherSkillId,
					model.TeacherId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[RateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, RateModel model)
		{
			if (this.rateRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.rateModelValidator.UpdateMode();
			var validationResult = this.rateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.rateRepository.Update(
					id,
					model.AmountPerMinute,
					model.TeacherSkillId,
					model.TeacherId);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[RateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.rateRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByTeacherSkillId/{id}")]
		[RateFilter]
		[ReadOnlyFilter]
		[Route("~/api/TeacherSkills/{id}/Rates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeacherSkillId(int id)
		{
			Response response = this.rateRepository.GetWhere(x => x.TeacherSkillId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTeacherId/{id}")]
		[RateFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teachers/{id}/Rates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeacherId(int id)
		{
			Response response = this.rateRepository.GetWhere(x => x.TeacherId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>4416ca40fd9896aaf153930864e41a8e</Hash>
</Codenesium>*/