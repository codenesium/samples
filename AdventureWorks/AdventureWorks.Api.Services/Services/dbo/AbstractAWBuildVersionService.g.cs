using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAWBuildVersionService: AbstractService
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
			IBOLAWBuildVersionMapper bolaWBuildVersionMapper,
			IDALAWBuildVersionMapper dalaWBuildVersionMapper)
			: base()

		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.bolAWBuildVersionMapper = bolaWBuildVersionMapper;
			this.dalAWBuildVersionMapper = dalaWBuildVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.aWBuildVersionRepository.All(skip, take, orderClause);

			return this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID)
		{
			var record = await aWBuildVersionRepository.Get(systemInformationID);

			return this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
			ApiAWBuildVersionRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionResponseModel> response = new CreateResponse<ApiAWBuildVersionResponseModel>(await this.aWBuildVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolAWBuildVersionMapper.MapModelToBO(default (int), model);
				var record = await this.aWBuildVersionRepository.Create(this.dalAWBuildVersionMapper.MapBOToEF(bo));

				response.SetRecord(this.bolAWBuildVersionMapper.MapBOToModel(this.dalAWBuildVersionMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model));

			if (response.Success)
			{
				var bo = this.bolAWBuildVersionMapper.MapModelToBO(systemInformationID, model);
				await this.aWBuildVersionRepository.Update(this.dalAWBuildVersionMapper.MapBOToEF(bo));
			}

			return response;
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
    <Hash>9a44861fd226250f543ab6ee68ebbb97</Hash>
</Codenesium>*/