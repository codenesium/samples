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
	public abstract class AbstractBOLessonXTeacher
	{
		private ILessonXTeacherRepository lessonXTeacherRepository;
		private ILessonXTeacherModelValidator lessonXTeacherModelValidator;
		private ILogger logger;

		public AbstractBOLessonXTeacher(
			ILogger logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			ILessonXTeacherModelValidator lessonXTeacherModelValidator)

		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
			this.lessonXTeacherModelValidator = lessonXTeacherModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			LessonXTeacherModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.lessonXTeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.lessonXTeacherRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LessonXTeacherModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.lessonXTeacherRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.lessonXTeacherRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.lessonXTeacherRepository.GetById(id);
		}

		public virtual POCOLessonXTeacher GetByIdDirect(int id)
		{
			return this.lessonXTeacherRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXTeacherRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXTeacherRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOLessonXTeacher> GetWhereDirect(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXTeacherRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d92da0f4d82bc18815c3bb72e9d84a67</Hash>
</Codenesium>*/