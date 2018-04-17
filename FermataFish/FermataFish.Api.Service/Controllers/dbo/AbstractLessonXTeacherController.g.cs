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
	public abstract class AbstractLessonXTeacherController: AbstractApiController
	{
		protected ILessonXTeacherRepository lessonXTeacherRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonXTeacherController(
			ILogger<AbstractLessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXTeacherRepository lessonXTeacherRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.lessonXTeacherRepository.GetById(id);
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
			ApiResponse response = this.lessonXTeacherRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] LessonXTeacherModel model)
		{
			var id = this.lessonXTeacherRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<LessonXTeacherModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.lessonXTeacherRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] LessonXTeacherModel model)
		{
			this.lessonXTeacherRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonXTeacherRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLessonId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Lessons/{id}/LessonXTeachers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByLessonId(int id)
		{
			ApiResponse response = this.lessonXTeacherRepository.GetWhere(x => x.LessonId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/LessonXTeachers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			ApiResponse response = this.lessonXTeacherRepository.GetWhere(x => x.StudentId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>aaccdf989ed736391bb7eba69e29cf08</Hash>
</Codenesium>*/