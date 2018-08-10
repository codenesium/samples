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
	public abstract class AbstractLessonXStudentService : AbstractService
	{
		protected ILessonXStudentRepository LessonXStudentRepository { get; private set; }

		protected IApiLessonXStudentRequestModelValidator LessonXStudentModelValidator { get; private set; }

		protected IBOLLessonXStudentMapper BolLessonXStudentMapper { get; private set; }

		protected IDALLessonXStudentMapper DalLessonXStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractLessonXStudentService(
			ILogger logger,
			ILessonXStudentRepository lessonXStudentRepository,
			IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper)
			: base()
		{
			this.LessonXStudentRepository = lessonXStudentRepository;
			this.LessonXStudentModelValidator = lessonXStudentModelValidator;
			this.BolLessonXStudentMapper = bolLessonXStudentMapper;
			this.DalLessonXStudentMapper = dalLessonXStudentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonXStudentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LessonXStudentRepository.All(limit, offset);

			return this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonXStudentResponseModel> Get(int id)
		{
			var record = await this.LessonXStudentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
			ApiLessonXStudentRequestModel model)
		{
			CreateResponse<ApiLessonXStudentResponseModel> response = new CreateResponse<ApiLessonXStudentResponseModel>(await this.LessonXStudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLessonXStudentMapper.MapModelToBO(default(int), model);
				var record = await this.LessonXStudentRepository.Create(this.DalLessonXStudentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLessonXStudentResponseModel>> Update(
			int id,
			ApiLessonXStudentRequestModel model)
		{
			var validationResult = await this.LessonXStudentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLessonXStudentMapper.MapModelToBO(id, model);
				await this.LessonXStudentRepository.Update(this.DalLessonXStudentMapper.MapBOToEF(bo));

				var record = await this.LessonXStudentRepository.Get(id);

				return new UpdateResponse<ApiLessonXStudentResponseModel>(this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLessonXStudentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LessonXStudentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LessonXStudentRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c246db41b4cabbf4db85faf8cac688c0</Hash>
</Codenesium>*/