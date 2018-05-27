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
	public abstract class AbstractBOLesson: AbstractBOManager
	{
		private ILessonRepository lessonRepository;
		private IApiLessonRequestModelValidator lessonModelValidator;
		private IBOLLessonMapper lessonMapper;
		private ILogger logger;

		public AbstractBOLesson(
			ILogger logger,
			ILessonRepository lessonRepository,
			IApiLessonRequestModelValidator lessonModelValidator,
			IBOLLessonMapper lessonMapper)
			: base()

		{
			this.lessonRepository = lessonRepository;
			this.lessonModelValidator = lessonModelValidator;
			this.lessonMapper = lessonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonRepository.All(skip, take, orderClause);

			return this.lessonMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLessonResponseModel> Get(int id)
		{
			var record = await lessonRepository.Get(id);

			return this.lessonMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLessonResponseModel>> Create(
			ApiLessonRequestModel model)
		{
			CreateResponse<ApiLessonResponseModel> response = new CreateResponse<ApiLessonResponseModel>(await this.lessonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.lessonMapper.MapModelToDTO(default (int), model);
				var record = await this.lessonRepository.Create(dto);

				response.SetRecord(this.lessonMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.lessonMapper.MapModelToDTO(id, model);
				await this.lessonRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.lessonRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d5ffc956eb98374e5436633be7655502</Hash>
</Codenesium>*/