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
	public abstract class AbstractTeacherXTeacherSkillController: AbstractApiController
	{
		protected IBOTeacherXTeacherSkill teacherXTeacherSkillManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherXTeacherSkillController(
			ILogger<AbstractTeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacherXTeacherSkill teacherXTeacherSkillManager
			)
			: base(logger, transactionCoordinator)
		{
			this.teacherXTeacherSkillManager = teacherXTeacherSkillManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillManager.GetById(id);
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
			ApiResponse response = this.teacherXTeacherSkillManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] TeacherXTeacherSkillModel model)
		{
			var result = await this.teacherXTeacherSkillManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<TeacherXTeacherSkillModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.teacherXTeacherSkillManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] TeacherXTeacherSkillModel model)
		{
			var result = await this.teacherXTeacherSkillManager.Update(id, model);

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
			var result = await this.teacherXTeacherSkillManager.Delete(id);

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
		[Route("ByTeacherId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Teachers/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeacherId(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillManager.GetWhere(x => x.TeacherId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTeacherSkillId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/TeacherSkills/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeacherSkillId(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillManager.GetWhere(x => x.TeacherSkillId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>428e41f3c89ab32a9d802f625d499310</Hash>
</Codenesium>*/