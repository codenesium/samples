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
	public abstract class AbstractLessonStatusService: AbstractService
	{
		private ILessonStatusRepository lessonStatusRepository;
		private IApiLessonStatusRequestModelValidator lessonStatusModelValidator;
		private IBOLLessonStatusMapper BOLLessonStatusMapper;
		private IDALLessonStatusMapper DALLessonStatusMapper;
		private ILogger logger;

		public AbstractLessonStatusService(
			ILogger logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper bollessonStatusMapper,
			IDALLessonStatusMapper dallessonStatusMapper)
			: base()

		{
			this.lessonStatusRepository = lessonStatusRepository;
			this.lessonStatusModelValidator = lessonStatusModelValidator;
			this.BOLLessonStatusMapper = bollessonStatusMapper;
			this.DALLessonStatusMapper = dallessonStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonStatusRepository.All(skip, take, orderClause);

			return this.BOLLessonStatusMapper.MapBOToModel(this.DALLessonStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonStatusResponseModel> Get(int id)
		{
			var record = await lessonStatusRepository.Get(id);

			return this.BOLLessonStatusMapper.MapBOToModel(this.DALLessonStatusMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
			ApiLessonStatusRequestModel model)
		{
			CreateResponse<ApiLessonStatusResponseModel> response = new CreateResponse<ApiLessonStatusResponseModel>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLessonStatusMapper.MapModelToBO(default (int), model);
				var record = await this.lessonStatusRepository.Create(this.DALLessonStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLessonStatusMapper.MapBOToModel(this.DALLessonStatusMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLLessonStatusMapper.MapModelToBO(id, model);
				await this.lessonStatusRepository.Update(this.DALLessonStatusMapper.MapBOToEF(bo));
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
    <Hash>59ed64edc2da058826fc152027b16564</Hash>
</Codenesium>*/