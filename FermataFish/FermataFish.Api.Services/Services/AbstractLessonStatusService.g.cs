using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractLessonStatusService : AbstractService
	{
		protected ILessonStatusRepository LessonStatusRepository { get; private set; }

		protected IApiLessonStatusRequestModelValidator LessonStatusModelValidator { get; private set; }

		protected IBOLLessonStatusMapper BolLessonStatusMapper { get; private set; }

		protected IDALLessonStatusMapper DalLessonStatusMapper { get; private set; }

		private ILogger logger;

		public AbstractLessonStatusService(
			ILogger logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper bolLessonStatusMapper,
			IDALLessonStatusMapper dalLessonStatusMapper)
			: base()
		{
			this.LessonStatusRepository = lessonStatusRepository;
			this.LessonStatusModelValidator = lessonStatusModelValidator;
			this.BolLessonStatusMapper = bolLessonStatusMapper;
			this.DalLessonStatusMapper = dalLessonStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LessonStatusRepository.All(limit, offset);

			return this.BolLessonStatusMapper.MapBOToModel(this.DalLessonStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonStatusResponseModel> Get(int id)
		{
			var record = await this.LessonStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLessonStatusMapper.MapBOToModel(this.DalLessonStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
			ApiLessonStatusRequestModel model)
		{
			CreateResponse<ApiLessonStatusResponseModel> response = new CreateResponse<ApiLessonStatusResponseModel>(await this.LessonStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLessonStatusMapper.MapModelToBO(default(int), model);
				var record = await this.LessonStatusRepository.Create(this.DalLessonStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLessonStatusMapper.MapBOToModel(this.DalLessonStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLessonStatusResponseModel>> Update(
			int id,
			ApiLessonStatusRequestModel model)
		{
			var validationResult = await this.LessonStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLessonStatusMapper.MapModelToBO(id, model);
				await this.LessonStatusRepository.Update(this.DalLessonStatusMapper.MapBOToEF(bo));

				var record = await this.LessonStatusRepository.Get(id);

				return new UpdateResponse<ApiLessonStatusResponseModel>(this.BolLessonStatusMapper.MapBOToModel(this.DalLessonStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLessonStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LessonStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LessonStatusRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiLessonStatusResponseModel>> ByStudioId(int studioId, int limit = 0, int offset = int.MaxValue)
		{
			List<LessonStatus> records = await this.LessonStatusRepository.ByStudioId(studioId, limit, offset);

			return this.BolLessonStatusMapper.MapBOToModel(this.DalLessonStatusMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0ec523ba78e5ffe179a54f4781025a81</Hash>
</Codenesium>*/