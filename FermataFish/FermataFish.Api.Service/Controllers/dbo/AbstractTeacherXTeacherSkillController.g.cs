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
	public abstract class AbstractTeacherXTeacherSkillController: AbstractApiController
	{
		protected IBOTeacherXTeacherSkill teacherXTeacherSkillManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherXTeacherSkillController(
			ServiceSettings settings,
			ILogger<AbstractTeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacherXTeacherSkill teacherXTeacherSkillManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.teacherXTeacherSkillManager = teacherXTeacherSkillManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOTeacherXTeacherSkill), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOTeacherXTeacherSkill response = this.teacherXTeacherSkillManager.GetById(id).TeacherXTeacherSkills.FirstOrDefault();
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
		[ProducesResponseType(typeof(List<POCOTeacherXTeacherSkill>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.teacherXTeacherSkillManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.TeacherXTeacherSkills);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOTeacherXTeacherSkill), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] TeacherXTeacherSkillModel model)
		{
			CreateResponse<int> result = await this.teacherXTeacherSkillManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/teacherXTeacherSkills/{result.Id.ToString()}");
				POCOTeacherXTeacherSkill response = this.teacherXTeacherSkillManager.GetById(result.Id).TeacherXTeacherSkills.First();
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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<TeacherXTeacherSkillModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.teacherXTeacherSkillManager.Create(model);

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
		[ProducesResponseType(typeof(POCOTeacherXTeacherSkill), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] TeacherXTeacherSkillModel model)
		{
			try
			{
				ActionResponse result = await this.teacherXTeacherSkillManager.Update(id, model);

				if (result.Success)
				{
					POCOTeacherXTeacherSkill response = this.teacherXTeacherSkillManager.GetById(id).TeacherXTeacherSkills.First();
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
			ActionResponse result = await this.teacherXTeacherSkillManager.Delete(id);

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
		[Route("ByTeacherId/{id}")]
		[ReadOnly]
		[Route("~/api/Teachers/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOTeacherXTeacherSkill>), 200)]
		public virtual IActionResult ByTeacherId(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillManager.GetWhere(x => x.TeacherId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.TeacherXTeacherSkills);
			}
		}

		[HttpGet]
		[Route("ByTeacherSkillId/{id}")]
		[ReadOnly]
		[Route("~/api/TeacherSkills/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOTeacherXTeacherSkill>), 200)]
		public virtual IActionResult ByTeacherSkillId(int id)
		{
			ApiResponse response = this.teacherXTeacherSkillManager.GetWhere(x => x.TeacherSkillId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.TeacherXTeacherSkills);
			}
		}
	}
}

/*<Codenesium>
    <Hash>2cc26a73af33dd9151b64fb89fb50665</Hash>
</Codenesium>*/