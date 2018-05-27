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
		private IApiLessonStatusRequestModelValidator lessonStatusModelValidator;
		private IBOLLessonStatusMapper lessonStatusMapper;
		private ILogger logger;

		public AbstractBOLessonStatus(
			ILogger logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper lessonStatusMapper)
			: base()

		{
			this.lessonStatusRepository = lessonStatusRepository;
			this.lessonStatusModelValidator = lessonStatusModelValidator;
			this.lessonStatusMapper = lessonStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonStatusRepository.All(skip, take, orderClause);

			return this.lessonStatusMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLessonStatusResponseModel> Get(int id)
		{
			var record = await lessonStatusRepository.Get(id);

			return this.lessonStatusMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
			ApiLessonStatusRequestModel model)
		{
			CreateResponse<ApiLessonStatusResponseModel> response = new CreateResponse<ApiLessonStatusResponseModel>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.lessonStatusMapper.MapModelToDTO(default (int), model);
				var record = await this.lessonStatusRepository.Create(dto);

				response.SetRecord(this.lessonStatusMapper.MapDTOToModel(record));
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
				var dto = this.lessonStatusMapper.MapModelToDTO(id, model);
				await this.lessonStatusRepository.Update(id, dto);
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
    <Hash>53274f56f379b1a1b96169703a1e830a</Hash>
</Codenesium>*/