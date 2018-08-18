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
	public abstract class AbstractDashboardConfigurationService : AbstractService
	{
		protected IDashboardConfigurationRepository DashboardConfigurationRepository { get; private set; }

		protected IApiDashboardConfigurationRequestModelValidator DashboardConfigurationModelValidator { get; private set; }

		protected IBOLDashboardConfigurationMapper BolDashboardConfigurationMapper { get; private set; }

		protected IDALDashboardConfigurationMapper DalDashboardConfigurationMapper { get; private set; }

		private ILogger logger;

		public AbstractDashboardConfigurationService(
			ILogger logger,
			IDashboardConfigurationRepository dashboardConfigurationRepository,
			IApiDashboardConfigurationRequestModelValidator dashboardConfigurationModelValidator,
			IBOLDashboardConfigurationMapper bolDashboardConfigurationMapper,
			IDALDashboardConfigurationMapper dalDashboardConfigurationMapper)
			: base()
		{
			this.DashboardConfigurationRepository = dashboardConfigurationRepository;
			this.DashboardConfigurationModelValidator = dashboardConfigurationModelValidator;
			this.BolDashboardConfigurationMapper = bolDashboardConfigurationMapper;
			this.DalDashboardConfigurationMapper = dalDashboardConfigurationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDashboardConfigurationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DashboardConfigurationRepository.All(limit, offset);

			return this.BolDashboardConfigurationMapper.MapBOToModel(this.DalDashboardConfigurationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDashboardConfigurationResponseModel> Get(string id)
		{
			var record = await this.DashboardConfigurationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDashboardConfigurationMapper.MapBOToModel(this.DalDashboardConfigurationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDashboardConfigurationResponseModel>> Create(
			ApiDashboardConfigurationRequestModel model)
		{
			CreateResponse<ApiDashboardConfigurationResponseModel> response = new CreateResponse<ApiDashboardConfigurationResponseModel>(await this.DashboardConfigurationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDashboardConfigurationMapper.MapModelToBO(default(string), model);
				var record = await this.DashboardConfigurationRepository.Create(this.DalDashboardConfigurationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDashboardConfigurationMapper.MapBOToModel(this.DalDashboardConfigurationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDashboardConfigurationResponseModel>> Update(
			string id,
			ApiDashboardConfigurationRequestModel model)
		{
			var validationResult = await this.DashboardConfigurationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDashboardConfigurationMapper.MapModelToBO(id, model);
				await this.DashboardConfigurationRepository.Update(this.DalDashboardConfigurationMapper.MapBOToEF(bo));

				var record = await this.DashboardConfigurationRepository.Get(id);

				return new UpdateResponse<ApiDashboardConfigurationResponseModel>(this.BolDashboardConfigurationMapper.MapBOToModel(this.DalDashboardConfigurationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDashboardConfigurationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.DashboardConfigurationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DashboardConfigurationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>43e518b86a099a5d9d76f34b5a3f164d</Hash>
</Codenesium>*/