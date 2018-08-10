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
	public abstract class AbstractSubscriptionService : AbstractService
	{
		protected ISubscriptionRepository SubscriptionRepository { get; private set; }

		protected IApiSubscriptionRequestModelValidator SubscriptionModelValidator { get; private set; }

		protected IBOLSubscriptionMapper BolSubscriptionMapper { get; private set; }

		protected IDALSubscriptionMapper DalSubscriptionMapper { get; private set; }

		private ILogger logger;

		public AbstractSubscriptionService(
			ILogger logger,
			ISubscriptionRepository subscriptionRepository,
			IApiSubscriptionRequestModelValidator subscriptionModelValidator,
			IBOLSubscriptionMapper bolSubscriptionMapper,
			IDALSubscriptionMapper dalSubscriptionMapper)
			: base()
		{
			this.SubscriptionRepository = subscriptionRepository;
			this.SubscriptionModelValidator = subscriptionModelValidator;
			this.BolSubscriptionMapper = bolSubscriptionMapper;
			this.DalSubscriptionMapper = dalSubscriptionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSubscriptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SubscriptionRepository.All(limit, offset);

			return this.BolSubscriptionMapper.MapBOToModel(this.DalSubscriptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSubscriptionResponseModel> Get(string id)
		{
			var record = await this.SubscriptionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSubscriptionMapper.MapBOToModel(this.DalSubscriptionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSubscriptionResponseModel>> Create(
			ApiSubscriptionRequestModel model)
		{
			CreateResponse<ApiSubscriptionResponseModel> response = new CreateResponse<ApiSubscriptionResponseModel>(await this.SubscriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSubscriptionMapper.MapModelToBO(default(string), model);
				var record = await this.SubscriptionRepository.Create(this.DalSubscriptionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSubscriptionMapper.MapBOToModel(this.DalSubscriptionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSubscriptionResponseModel>> Update(
			string id,
			ApiSubscriptionRequestModel model)
		{
			var validationResult = await this.SubscriptionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSubscriptionMapper.MapModelToBO(id, model);
				await this.SubscriptionRepository.Update(this.DalSubscriptionMapper.MapBOToEF(bo));

				var record = await this.SubscriptionRepository.Get(id);

				return new UpdateResponse<ApiSubscriptionResponseModel>(this.BolSubscriptionMapper.MapBOToModel(this.DalSubscriptionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSubscriptionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.SubscriptionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SubscriptionRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiSubscriptionResponseModel> ByName(string name)
		{
			Subscription record = await this.SubscriptionRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSubscriptionMapper.MapBOToModel(this.DalSubscriptionMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>db424bd4980664be96208192de543d25</Hash>
</Codenesium>*/