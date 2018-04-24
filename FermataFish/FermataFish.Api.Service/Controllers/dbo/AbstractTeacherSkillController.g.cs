using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractTeacherSkillController: AbstractApiController
	{
		protected IBOTeacherSkill teacherSkillManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherSkillController(
			ServiceSettings settings,
			ILogger<AbstractTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacherSkill teacherSkillManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.teacherSkillManager = teacherSkillManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOTeacherSkill), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOTeacherSkill response = this.teacherSkillManager.GetById(id).TeacherSkills.FirstOrDefault();
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOTeacherSkill>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.teacherSkillManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.TeacherSkills);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOTeacherSkill), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] TeacherSkillModel model)
		{
			CreateResponse<int> result = await this.teacherSkillManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/teacherSkills/{result.Id.ToString()}");
				POCOTeacherSkill response = this.teacherSkillManager.GetById(result.Id).TeacherSkills.First();
				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<int>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<TeacherSkillModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.teacherSkillManager.Create(model);

				if(result.Success)
				{
					ids.Add(result.Id);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(ids);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOTeacherSkill), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] TeacherSkillModel model)
		{
			try
			{
				ActionResponse result = await this.teacherSkillManager.Update(id, model);

				if (result.Success)
				{
					POCOTeacherSkill response = this.teacherSkillManager.GetById(id).TeacherSkills.First();
					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.teacherSkillManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[ReadOnly]
		[Route("~/api/Studios/{id}/TeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOTeacherSkill>), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			ApiResponse response = this.teacherSkillManager.GetWhere(x => x.StudioId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.TeacherSkills);
			}
		}
	}
}

/*<Codenesium>
    <Hash>c1a2d8f08ef2e4cd053aacf14bbb1c63</Hash>
</Codenesium>*/