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

		public virtual List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonRepository.All(skip, take, orderClause);
		}

		public virtual POCOLesson Get(int id)
		{
			return this.lessonRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLesson>> Create(
			LessonModel model)
		{
			CreateResponse<POCOLesson> response = new CreateResponse<POCOLesson>(await this.lessonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLesson record = this.lessonRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>482ad58e4fd07fdb3ac559a66fe1de3c</Hash>
</Codenesium>*/