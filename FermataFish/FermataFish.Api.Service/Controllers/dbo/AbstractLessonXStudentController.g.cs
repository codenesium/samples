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
	public abstract class AbstractLessonXStudentController: AbstractApiController
	{
		protected ILessonXStudentRepository lessonXStudentRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonXStudentController(
			ILogger<AbstractLessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXStudentRepository lessonXStudentRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonXStudentRepository = lessonXStudentRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.lessonXStudentRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
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
			ApiResponse response = this.lessonXStudentRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] LessonXStudentModel model)
		{
			var id = this.lessonXStudentRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<LessonXStudentModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.lessonXStudentRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] LessonXStudentModel model)
		{
			this.lessonXStudentRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonXStudentRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLessonId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Lessons/{id}/LessonXStudents")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByLessonId(int id)
		{
			ApiResponse response = this.lessonXStudentRepository.GetWhere(x => x.LessonId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/LessonXStudents")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			ApiResponse response = this.lessonXStudentRepository.GetWhere(x => x.StudentId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>33cf5469f47a75b0bba73348fe579c5e</Hash>
</Codenesium>*/