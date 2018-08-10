using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractConfigurationService : AbstractService
	{
		protected IConfigurationRepository ConfigurationRepository { get; private set; }

		protected IApiConfigurationRequestModelValidator ConfigurationModelValidator { get; private set; }

		protected IBOLConfigurationMapper BolConfigurationMapper { get; private set; }

		protected IDALConfigurationMapper DalConfigurationMapper { get; private set; }

		private ILogger logger;

		public AbstractConfigurationService(
			ILogger logger,
			IConfigurationRepository configurationRepository,
			IApiConfigurationRequestModelValidator configurationModelValidator,
			IBOLConfigurationMapper bolConfigurationMapper,
			IDALConfigurationMapper dalConfigurationMapper)
			: base()
		{
			this.ConfigurationRepository = configurationRepository;
			this.ConfigurationModelValidator = configurationModelValidator;
			this.BolConfigurationMapper = bolConfigurationMapper;
			this.DalConfigurationMapper = dalConfigurationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiConfigurationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ConfigurationRepository.All(limit, offset);

			return this.BolConfigurationMapper.MapBOToModel(this.DalConfigurationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiConfigurationResponseModel> Get(string id)
		{
			var record = await this.ConfigurationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolConfigurationMapper.MapBOToModel(this.DalConfigurationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiConfigurationResponseModel>> Create(
			ApiConfigurationRequestModel model)
		{
			CreateResponse<ApiConfigurationResponseModel> response = new CreateResponse<ApiConfigurationResponseModel>(await this.ConfigurationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolConfigurationMapper.MapModelToBO(default(string), model);
				var record = await this.ConfigurationRepository.Create(this.DalConfigurationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolConfigurationMapper.MapBOToModel(this.DalConfigurationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiConfigurationResponseModel>> Update(
			string id,
			ApiConfigurationRequestModel model)
		{
			var validationResult = await this.ConfigurationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolConfigurationMapper.MapModelToBO(id, model);
				await this.ConfigurationRepository.Update(this.DalConfigurationMapper.MapBOToEF(bo));

				var record = await this.ConfigurationRepository.Get(id);

				return new UpdateResponse<ApiConfigurationResponseModel>(this.BolConfigurationMapper.MapBOToModel(this.DalConfigurationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiConfigurationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ConfigurationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ConfigurationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b9ea984c1c90cefa59858d760ab85108</Hash>
</Codenesium>*/