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
		protected IAWBuildVersionRepository AWBuildVersionRepository { get; private set; }

		protected IApiAWBuildVersionRequestModelValidator AWBuildVersionModelValidator { get; private set; }

		protected IBOLAWBuildVersionMapper BolAWBuildVersionMapper { get; private set; }

		protected IDALAWBuildVersionMapper DalAWBuildVersionMapper { get; private set; }

		private ILogger logger;

		public AbstractAWBuildVersionService(
			ILogger logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper bolAWBuildVersionMapper,
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base()
		{
			this.AWBuildVersionRepository = aWBuildVersionRepository;
			this.AWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.BolAWBuildVersionMapper = bolAWBuildVersionMapper;
			this.DalAWBuildVersionMapper = dalAWBuildVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AWBuildVersionRepository.All(limit, offset);

			return this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID)
		{
			var record = await this.AWBuildVersionRepository.Get(systemInformationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
			ApiAWBuildVersionRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionResponseModel> response = new CreateResponse<ApiAWBuildVersionResponseModel>(await this.AWBuildVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolAWBuildVersionMapper.MapModelToBO(default(int), model);
				var record = await this.AWBuildVersionRepository.Create(this.DalAWBuildVersionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAWBuildVersionResponseModel>> Update(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model)
		{
			var validationResult = await this.AWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAWBuildVersionMapper.MapModelToBO(systemInformationID, model);
				await this.AWBuildVersionRepository.Update(this.DalAWBuildVersionMapper.MapBOToEF(bo));

				var record = await this.AWBuildVersionRepository.Get(systemInformationID);

				return new UpdateResponse<ApiAWBuildVersionResponseModel>(this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAWBuildVersionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = new ActionResponse(await this.AWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));
			if (response.Success)
			{
				await this.AWBuildVersionRepository.Delete(systemInformationID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c7f794c29961592f89c07d6295789410</Hash>
</Codenesium>*/