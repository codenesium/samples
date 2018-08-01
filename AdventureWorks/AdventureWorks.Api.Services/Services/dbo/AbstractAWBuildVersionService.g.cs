using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAWBuildVersionService : AbstractService
	{
		private IAWBuildVersionRepository aWBuildVersionRepository;

		private IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator;

		private IBOLAWBuildVersionMapper bolAWBuildVersionMapper;

		private IDALAWBuildVersionMapper dalAWBuildVersionMapper;

		private ILogger logger;

		public AbstractAWBuildVersionService(
			ILogger logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper bolAWBuildVersionMapper,
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base()
		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.bolAWBuildVersionMapper = bolAWBuildVersionMapper;
			this.dalAWBuildVersionMapper = dalAWBuildVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.aWBuildVersionRepository.All(limit, offset);

			return this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID)
		{
			var record = await this.aWBuildVersionRepository.Get(systemInformationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
			ApiAWBuildVersionRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionResponseModel> response = new CreateResponse<ApiAWBuildVersionResponseModel>(await this.aWBuildVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolAWBuildVersionMapper.MapModelToBO(default(int), model);
				var record = await this.aWBuildVersionRepository.Create(this.dalAWBuildVersionMapper.MapBOToEF(bo));

				response.SetRecord(this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAWBuildVersionResponseModel>> Update(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model)
		{
			var validationResult = await this.aWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolAWBuildVersionMapper.MapModelToBO(systemInformationID, model);
				await this.aWBuildVersionRepository.Update(this.dalAWBuildVersionMapper.MapBOToEF(bo));

				var record = await this.aWBuildVersionRepository.Get(systemInformationID);

				return new UpdateResponse<ApiAWBuildVersionResponseModel>(this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAWBuildVersionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));
			if (response.Success)
			{
				await this.aWBuildVersionRepository.Delete(systemInformationID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9508d032cc442bc1d1eab6a1b54f7cb3</Hash>
</Codenesium>*/