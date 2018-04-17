using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractLessonXTeacherController: AbstractApiController
	{
		protected IBOLessonXTeacher lessonXTeacherManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonXTeacherController(
			ILogger<AbstractLessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonXTeacher lessonXTeacherManager
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonXTeacherManager = lessonXTeacherManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.lessonXTeacherManager.GetById(id);
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
			ApiResponse response = this.lessonXTeacherManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] LessonXTeacherModel model)
		{
			var result = await this.lessonXTeacherManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<LessonXTeacherModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.lessonXTeacherManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] LessonXTeacherModel model)
		{
			var result = await this.lessonXTeacherManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.lessonXTeacherManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByLessonId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Lessons/{id}/LessonXTeachers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByLessonId(int id)
		{
			ApiResponse response = this.lessonXTeacherManager.GetWhere(x => x.LessonId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/LessonXTeachers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			ApiResponse response = this.lessonXTeacherManager.GetWhere(x => x.StudentId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>b12f1796613f561075a58265f2b63976</Hash>
</Codenesium>*/