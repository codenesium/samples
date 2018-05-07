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
	public abstract class AbstractBOLesson
	{
		private ILessonRepository lessonRepository;
		private ILessonModelValidator lessonModelValidator;
		private ILogger logger;

		public AbstractBOLesson(
			ILogger logger,
			ILessonRepository lessonRepository,
			ILessonModelValidator lessonModelValidator)

		{
			this.lessonRepository = lessonRepository;
			this.lessonModelValidator = lessonModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			LessonModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.lessonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.lessonRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LessonModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.lessonRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.lessonRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOLesson Get(int id)
		{
			return this.lessonRepository.Get(id);
		}

		public virtual List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>88bdd1c5dbe536449d7d03c22f8414b7</Hash>
</Codenesium>*/