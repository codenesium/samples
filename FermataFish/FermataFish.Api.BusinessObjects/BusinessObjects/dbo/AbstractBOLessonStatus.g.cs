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
	public abstract class AbstractBOLessonStatus: AbstractBOManager
	{
		private ILessonStatusRepository lessonStatusRepository;
		private IApiLessonStatusModelValidator lessonStatusModelValidator;
		private ILogger logger;

		public AbstractBOLessonStatus(
			ILogger logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusModelValidator lessonStatusModelValidator)
			: base()

		{
			this.lessonStatusRepository = lessonStatusRepository;
			this.lessonStatusModelValidator = lessonStatusModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOLessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonStatusRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOLessonStatus> Get(int id)
		{
			return this.lessonStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLessonStatus>> Create(
			ApiLessonStatusModel model)
		{
			CreateResponse<POCOLessonStatus> response = new CreateResponse<POCOLessonStatus>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLessonStatus record = await this.lessonStatusRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.lessonStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.lessonStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>af005d4875094749735fd1c9c987e373</Hash>
</Codenesium>*/