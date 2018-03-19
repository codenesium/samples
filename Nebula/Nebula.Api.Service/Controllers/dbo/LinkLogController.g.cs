using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractLinkLogsController: AbstractEntityFrameworkApiController
	{
		protected ILinkLogRepository _linkLogRepository;
		protected ILinkLogModelValidator _linkLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLinkLogsController(
			ILogger<AbstractLinkLogsController> logger,
			ApplicationContext context,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator
			) : base(logger,context)
		{
			this._linkLogRepository = linkLogRepository;
			this._linkLogModelValidator = linkLogModelValidator;
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
		[LinkLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._linkLogRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._linkLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LinkLogModel model)
		{
			this._linkLogModelValidator.CreateMode();
			var validationResult = this._linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._linkLogRepository.Create(model.DateEntered,
				                                        model.LinkId,
				                                        model.Log);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<LinkLogModel> models)
		{
			this._linkLogModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._linkLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._linkLogRepository.Create(model.DateEntered,
				                               model.LinkId,
				                               model.Log);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,LinkLogModel model)
		{
			this._linkLogModelValidator.UpdateMode();
			var validationResult = this._linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._linkLogRepository.Update(id,  model.DateEntered,
				                               model.LinkId,
				                               model.Log);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._linkLogRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByLinkId/{id}")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[Route("~/api/Links/{id}/LinkLogs")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLinkId(int id)
		{
			var response = new Response();

			this._linkLogRepository.GetWhere(x => x.linkId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>586a5baa202a929f0e5e6aa288973c33</Hash>
</Codenesium>*/