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

		public virtual List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonStatusRepository.All(skip, take, orderClause);
		}

		public virtual POCOLessonStatus Get(int id)
		{
			return this.lessonStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLessonStatus>> Create(
			LessonStatusModel model)
		{
			CreateResponse<POCOLessonStatus> response = new CreateResponse<POCOLessonStatus>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLessonStatus record = this.lessonStatusRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>019eb66b626a89c83765320e33bfc2f7</Hash>
</Codenesium>*/