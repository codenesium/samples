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
		private IBOLLessonMapper bolLessonMapper;
		private IDALLessonMapper dalLessonMapper;
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
			this.bolLessonMapper = bollessonMapper;
			this.dalLessonMapper = dallessonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonRepository.All(skip, take, orderClause);

			return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonResponseModel> Get(int id)
		{
			var record = await lessonRepository.Get(id);

			return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLessonResponseModel>> Create(
			ApiLessonRequestModel model)
		{
			CreateResponse<ApiLessonResponseModel> response = new CreateResponse<ApiLessonResponseModel>(await this.lessonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolLessonMapper.MapModelToBO(default (int), model);
				var record = await this.lessonRepository.Create(this.dalLessonMapper.MapBOToEF(bo));

				response.SetRecord(this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record)));
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
				var bo = this.bolLessonMapper.MapModelToBO(id, model);
				await this.lessonRepository.Update(this.dalLessonMapper.MapBOToEF(bo));
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
    <Hash>36bebacea0676800e98e8f08146840e3</Hash>
</Codenesium>*/