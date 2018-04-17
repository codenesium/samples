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
	public abstract class AbstractBOLessonStatus
	{
		private ILessonStatusRepository lessonStatusRepository;
		private ILessonStatusModelValidator lessonStatusModelValidator;
		private ILogger logger;

		public AbstractBOLessonStatus(
			ILogger logger,
			ILessonStatusRepository lessonStatusRepository,
			ILessonStatusModelValidator lessonStatusModelValidator)

		{
			this.lessonStatusRepository = lessonStatusRepository;
			this.lessonStatusModelValidator = lessonStatusModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			LessonStatusModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.lessonStatusRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LessonStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.lessonStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.lessonStatusRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.lessonStatusRepository.GetById(id);
		}

		public virtual POCOLessonStatus GetByIdDirect(int id)
		{
			return this.lessonStatusRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonStatusRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonStatusRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOLessonStatus> GetWhereDirect(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonStatusRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>f912064ddb72179ae360aaa3197ee5ac</Hash>
</Codenesium>*/