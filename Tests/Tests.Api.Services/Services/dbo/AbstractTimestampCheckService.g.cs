using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTimestampCheckService : AbstractService
	{
		protected ITimestampCheckRepository TimestampCheckRepository { get; private set; }

		protected IApiTimestampCheckServerRequestModelValidator TimestampCheckModelValidator { get; private set; }

		protected IBOLTimestampCheckMapper BolTimestampCheckMapper { get; private set; }

		protected IDALTimestampCheckMapper DalTimestampCheckMapper { get; private set; }

		private ILogger logger;

		public AbstractTimestampCheckService(
			ILogger logger,
			ITimestampCheckRepository timestampCheckRepository,
			IApiTimestampCheckServerRequestModelValidator timestampCheckModelValidator,
			IBOLTimestampCheckMapper bolTimestampCheckMapper,
			IDALTimestampCheckMapper dalTimestampCheckMapper)
			: base()
		{
			this.TimestampCheckRepository = timestampCheckRepository;
			this.TimestampCheckModelValidator = timestampCheckModelValidator;
			this.BolTimestampCheckMapper = bolTimestampCheckMapper;
			this.DalTimestampCheckMapper = dalTimestampCheckMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTimestampCheckServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TimestampCheckRepository.All(limit, offset);

			return this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTimestampCheckServerResponseModel> Get(int id)
		{
			var record = await this.TimestampCheckRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTimestampCheckServerResponseModel>> Create(
			ApiTimestampCheckServerRequestModel model)
		{
			CreateResponse<ApiTimestampCheckServerResponseModel> response = ValidationResponseFactory<ApiTimestampCheckServerResponseModel>.CreateResponse(await this.TimestampCheckModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTimestampCheckMapper.MapModelToBO(default(int), model);
				var record = await this.TimestampCheckRepository.Create(this.DalTimestampCheckMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTimestampCheckServerResponseModel>> Update(
			int id,
			ApiTimestampCheckServerRequestModel model)
		{
			var validationResult = await this.TimestampCheckModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTimestampCheckMapper.MapModelToBO(id, model);
				await this.TimestampCheckRepository.Update(this.DalTimestampCheckMapper.MapBOToEF(bo));

				var record = await this.TimestampCheckRepository.Get(id);

				return ValidationResponseFactory<ApiTimestampCheckServerResponseModel>.UpdateResponse(this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTimestampCheckServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TimestampCheckModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TimestampCheckRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7f2bdd8fb253647a9d060c0c8061f8bc</Hash>
</Codenesium>*/