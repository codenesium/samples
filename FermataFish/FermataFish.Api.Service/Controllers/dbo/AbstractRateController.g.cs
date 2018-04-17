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

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractRateController(
			ILogger<AbstractRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRateRepository rateRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.rateRepository = rateRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.rateRepository.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.rateRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] RateModel model)
		{
			var id = this.rateRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<RateModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.rateRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] RateModel model)
		{
			this.rateRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.rateRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByTeacherSkillId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/TeacherSkills/{id}/Rates")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeacherSkillId(int id)
		{
			ApiResponse response = this.rateRepository.GetWhere(x => x.TeacherSkillId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTeacherId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Teachers/{id}/Rates")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeacherId(int id)
		{
			ApiResponse response = this.rateRepository.GetWhere(x => x.TeacherId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1e180f1bf59b0f0a4c438333932a1478</Hash>
</Codenesium>*/