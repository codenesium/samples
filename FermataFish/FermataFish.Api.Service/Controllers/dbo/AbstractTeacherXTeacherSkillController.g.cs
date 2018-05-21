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
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOTeacherXTeacherSkill>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOTeacherXTeacherSkill> response = await this.teacherXTeacherSkillManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOTeacherXTeacherSkill), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOTeacherXTeacherSkill response = await this.teacherXTeacherSkillManager.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOTeacherXTeacherSkill), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTeacherXTeacherSkillModel model)
		{
			CreateResponse<POCOTeacherXTeacherSkill> result = await this.teacherXTeacherSkillManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/TeacherXTeacherSkills/{result.Record.Id.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<POCOTeacherXTeacherSkill>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTeacherXTeacherSkillModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOTeacherXTeacherSkill> records = new List<POCOTeacherXTeacherSkill>();
			foreach (var model in models)
			{
				CreateResponse<POCOTeacherXTeacherSkill> result = await this.teacherXTeacherSkillManager.Create(model);

				if(result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOTeacherXTeacherSkill), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeacherXTeacherSkillModel model)
		{
			try
			{
				ActionResponse result = await this.teacherXTeacherSkillManager.Update(id, model);

				if (result.Success)
				{
					POCOTeacherXTeacherSkill response = await this.teacherXTeacherSkillManager.Get(id);

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
	}
}

/*<Codenesium>
    <Hash>241929d333189d7330758a2912427195</Hash>
</Codenesium>*/