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
	public abstract class AbstractLessonXTeacherService : AbstractService
	{
		protected ILessonXTeacherRepository LessonXTeacherRepository { get; private set; }

		protected IApiLessonXTeacherRequestModelValidator LessonXTeacherModelValidator { get; private set; }

		protected IBOLLessonXTeacherMapper BolLessonXTeacherMapper { get; private set; }

		protected IDALLessonXTeacherMapper DalLessonXTeacherMapper { get; private set; }

		private ILogger logger;

		public AbstractLessonXTeacherService(
			ILogger logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
			IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
			IDALLessonXTeacherMapper dalLessonXTeacherMapper)
			: base()
		{
			this.LessonXTeacherRepository = lessonXTeacherRepository;
			this.LessonXTeacherModelValidator = lessonXTeacherModelValidator;
			this.BolLessonXTeacherMapper = bolLessonXTeacherMapper;
			this.DalLessonXTeacherMapper = dalLessonXTeacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonXTeacherResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LessonXTeacherRepository.All(limit, offset);

			return this.BolLessonXTeacherMapper.MapBOToModel(this.DalLessonXTeacherMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonXTeacherResponseModel> Get(int id)
		{
			var record = await this.LessonXTeacherRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLessonXTeacherMapper.MapBOToModel(this.DalLessonXTeacherMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
			ApiLessonXTeacherRequestModel model)
		{
			CreateResponse<ApiLessonXTeacherResponseModel> response = new CreateResponse<ApiLessonXTeacherResponseModel>(await this.LessonXTeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLessonXTeacherMapper.MapModelToBO(default(int), model);
				var record = await this.LessonXTeacherRepository.Create(this.DalLessonXTeacherMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLessonXTeacherMapper.MapBOToModel(this.DalLessonXTeacherMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLessonXTeacherResponseModel>> Update(
			int id,
			ApiLessonXTeacherRequestModel model)
		{
			var validationResult = await this.LessonXTeacherModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLessonXTeacherMapper.MapModelToBO(id, model);
				await this.LessonXTeacherRepository.Update(this.DalLessonXTeacherMapper.MapBOToEF(bo));

				var record = await this.LessonXTeacherRepository.Get(id);

				return new UpdateResponse<ApiLessonXTeacherResponseModel>(this.BolLessonXTeacherMapper.MapBOToModel(this.DalLessonXTeacherMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLessonXTeacherResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LessonXTeacherModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LessonXTeacherRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>565e06683ed552648a5c884affa007a9</Hash>
</Codenesium>*/