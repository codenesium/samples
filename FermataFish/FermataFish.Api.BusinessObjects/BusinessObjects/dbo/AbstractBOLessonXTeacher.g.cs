using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLessonXTeacher: AbstractBOManager
	{
		private ILessonXTeacherRepository lessonXTeacherRepository;
		private IApiLessonXTeacherModelValidator lessonXTeacherModelValidator;
		private ILogger logger;

		public AbstractBOLessonXTeacher(
			ILogger logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			IApiLessonXTeacherModelValidator lessonXTeacherModelValidator)
			: base()

		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
			this.lessonXTeacherModelValidator = lessonXTeacherModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOLessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXTeacherRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOLessonXTeacher> Get(int id)
		{
			return this.lessonXTeacherRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLessonXTeacher>> Create(
			ApiLessonXTeacherModel model)
		{
			CreateResponse<POCOLessonXTeacher> response = new CreateResponse<POCOLessonXTeacher>(await this.lessonXTeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLessonXTeacher record = await this.lessonXTeacherRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonXTeacherModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.lessonXTeacherRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.lessonXTeacherRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9d2e1557b362df992848e3a6a9e98468</Hash>
</Codenesium>*/