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
	public abstract class AbstractTeacherXTeacherSkillController: AbstractApiController
	{
		protected ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherXTeacherSkillController(
			ILogger<AbstractTeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillRepository.GetById(id);
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
			ApiResponse response = this.teacherXTeacherSkillRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] TeacherXTeacherSkillModel model)
		{
			var id = this.teacherXTeacherSkillRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<TeacherXTeacherSkillModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.teacherXTeacherSkillRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] TeacherXTeacherSkillModel model)
		{
			this.teacherXTeacherSkillRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.teacherXTeacherSkillRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByTeacherId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Teachers/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeacherId(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillRepository.GetWhere(x => x.TeacherId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTeacherSkillId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/TeacherSkills/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeacherSkillId(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillRepository.GetWhere(x => x.TeacherSkillId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c20223ce499efbef1e4d1e7cff9e1492</Hash>
</Codenesium>*/