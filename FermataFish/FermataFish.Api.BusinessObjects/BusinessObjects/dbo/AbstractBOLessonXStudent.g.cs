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
	public abstract class AbstractBOLessonXStudent
	{
		private ILessonXStudentRepository lessonXStudentRepository;
		private ILessonXStudentModelValidator lessonXStudentModelValidator;
		private ILogger logger;

		public AbstractBOLessonXStudent(
			ILogger logger,
			ILessonXStudentRepository lessonXStudentRepository,
			ILessonXStudentModelValidator lessonXStudentModelValidator)

		{
			this.lessonXStudentRepository = lessonXStudentRepository;
			this.lessonXStudentModelValidator = lessonXStudentModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			LessonXStudentModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.lessonXStudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.lessonXStudentRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LessonXStudentModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.lessonXStudentRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.lessonXStudentRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.lessonXStudentRepository.GetById(id);
		}

		public virtual POCOLessonXStudent GetByIdDirect(int id)
		{
			return this.lessonXStudentRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXStudentRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXStudentRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOLessonXStudent> GetWhereDirect(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXStudentRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>07c109fbc33e04c686a7538d5f17a5c7</Hash>
</Codenesium>*/