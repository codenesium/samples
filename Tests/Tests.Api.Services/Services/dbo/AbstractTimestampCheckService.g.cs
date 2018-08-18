using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTimestampCheckService : AbstractService
	{
		protected ITimestampCheckRepository TimestampCheckRepository { get; private set; }

		protected IApiTimestampCheckRequestModelValidator TimestampCheckModelValidator { get; private set; }

		protected IBOLTimestampCheckMapper BolTimestampCheckMapper { get; private set; }

		protected IDALTimestampCheckMapper DalTimestampCheckMapper { get; private set; }

		private ILogger logger;

		public AbstractTimestampCheckService(
			ILogger logger,
			ITimestampCheckRepository timestampCheckRepository,
			IApiTimestampCheckRequestModelValidator timestampCheckModelValidator,
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

		public virtual async Task<List<ApiTimestampCheckResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TimestampCheckRepository.All(limit, offset);

			return this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTimestampCheckResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiTimestampCheckResponseModel>> Create(
			ApiTimestampCheckRequestModel model)
		{
			CreateResponse<ApiTimestampCheckResponseModel> response = new CreateResponse<ApiTimestampCheckResponseModel>(await this.TimestampCheckModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTimestampCheckMapper.MapModelToBO(default(int), model);
				var record = await this.TimestampCheckRepository.Create(this.DalTimestampCheckMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTimestampCheckResponseModel>> Update(
			int id,
			ApiTimestampCheckRequestModel model)
		{
			var validationResult = await this.TimestampCheckModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTimestampCheckMapper.MapModelToBO(id, model);
				await this.TimestampCheckRepository.Update(this.DalTimestampCheckMapper.MapBOToEF(bo));

				var record = await this.TimestampCheckRepository.Get(id);

				return new UpdateResponse<ApiTimestampCheckResponseModel>(this.BolTimestampCheckMapper.MapBOToModel(this.DalTimestampCheckMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTimestampCheckResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TimestampCheckModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TimestampCheckRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d90ef3870d7a0c3bc09b96f409c3ee85</Hash>
</Codenesium>*/