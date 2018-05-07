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

		public virtual POCOLessonStatus Get(int id)
		{
			return this.lessonStatusRepository.Get(id);
		}

		public virtual List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonStatusRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c379b3dbb30596ca6103069b756c1afb</Hash>
</Codenesium>*/