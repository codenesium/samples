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

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractLessonService: AbstractService
	{
		private ILessonRepository lessonRepository;
		private IApiLessonRequestModelValidator lessonModelValidator;
		private IBOLLessonMapper BOLLessonMapper;
		private IDALLessonMapper DALLessonMapper;
		private ILogger logger;

		public AbstractLessonService(
			ILogger logger,
			ILessonRepository lessonRepository,
			IApiLessonRequestModelValidator lessonModelValidator,
			IBOLLessonMapper bollessonMapper,
			IDALLessonMapper dallessonMapper)
			: base()

		{
			this.lessonRepository = lessonRepository;
			this.lessonModelValidator = lessonModelValidator;
			this.BOLLessonMapper = bollessonMapper;
			this.DALLessonMapper = dallessonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonRepository.All(skip, take, orderClause);

			return this.BOLLessonMapper.MapBOToModel(this.DALLessonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonResponseModel> Get(int id)
		{
			var record = await lessonRepository.Get(id);

			return this.BOLLessonMapper.MapBOToModel(this.DALLessonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLessonResponseModel>> Create(
			ApiLessonRequestModel model)
		{
			CreateResponse<ApiLessonResponseModel> response = new CreateResponse<ApiLessonResponseModel>(await this.lessonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLessonMapper.MapModelToBO(default (int), model);
				var record = await this.lessonRepository.Create(this.DALLessonMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLessonMapper.MapBOToModel(this.DALLessonMapper.MapEFToBO(record)));
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
				var bo = this.BOLLessonMapper.MapModelToBO(id, model);
				await this.lessonRepository.Update(this.DALLessonMapper.MapBOToEF(bo));
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
    <Hash>31558f48543b91b6e2fb4d3e06cd14d4</Hash>
</Codenesium>*/