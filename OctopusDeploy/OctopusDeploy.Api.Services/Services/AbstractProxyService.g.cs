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
	public abstract class AbstractProxyService : AbstractService
	{
		protected IProxyRepository ProxyRepository { get; private set; }

		protected IApiProxyRequestModelValidator ProxyModelValidator { get; private set; }

		protected IBOLProxyMapper BolProxyMapper { get; private set; }

		protected IDALProxyMapper DalProxyMapper { get; private set; }

		private ILogger logger;

		public AbstractProxyService(
			ILogger logger,
			IProxyRepository proxyRepository,
			IApiProxyRequestModelValidator proxyModelValidator,
			IBOLProxyMapper bolProxyMapper,
			IDALProxyMapper dalProxyMapper)
			: base()
		{
			this.ProxyRepository = proxyRepository;
			this.ProxyModelValidator = proxyModelValidator;
			this.BolProxyMapper = bolProxyMapper;
			this.DalProxyMapper = dalProxyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProxyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProxyRepository.All(limit, offset);

			return this.BolProxyMapper.MapBOToModel(this.DalProxyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProxyResponseModel> Get(string id)
		{
			var record = await this.ProxyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProxyMapper.MapBOToModel(this.DalProxyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProxyResponseModel>> Create(
			ApiProxyRequestModel model)
		{
			CreateResponse<ApiProxyResponseModel> response = new CreateResponse<ApiProxyResponseModel>(await this.ProxyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProxyMapper.MapModelToBO(default(string), model);
				var record = await this.ProxyRepository.Create(this.DalProxyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProxyMapper.MapBOToModel(this.DalProxyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProxyResponseModel>> Update(
			string id,
			ApiProxyRequestModel model)
		{
			var validationResult = await this.ProxyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProxyMapper.MapModelToBO(id, model);
				await this.ProxyRepository.Update(this.DalProxyMapper.MapBOToEF(bo));

				var record = await this.ProxyRepository.Get(id);

				return new UpdateResponse<ApiProxyResponseModel>(this.BolProxyMapper.MapBOToModel(this.DalProxyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProxyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ProxyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ProxyRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiProxyResponseModel> ByName(string name)
		{
			Proxy record = await this.ProxyRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProxyMapper.MapBOToModel(this.DalProxyMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>7853f30e345c129307336af74f9fc6e1</Hash>
</Codenesium>*/