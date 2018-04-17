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
	public abstract class AbstractLessonController: AbstractApiController
	{
		protected ILessonRepository lessonRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonController(
			ILogger<AbstractLessonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonRepository lessonRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonRepository = lessonRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.lessonRepository.GetById(id);
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
			ApiResponse response = this.lessonRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] LessonModel model)
		{
			var id = this.lessonRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<LessonModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.lessonRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] LessonModel model)
		{
			this.lessonRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLessonStatusId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/LessonStatus/{id}/Lessons")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByLessonStatusId(int id)
		{
			ApiResponse response = this.lessonRepository.GetWhere(x => x.LessonStatusId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/Lessons")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			ApiResponse response = this.lessonRepository.GetWhere(x => x.StudioId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>fcc98d5b8d620df714d016bb20a96f5b</Hash>
</Codenesium>*/