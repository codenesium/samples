using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractClientCommunicationService: AbstractService
	{
		private IClientCommunicationRepository clientCommunicationRepository;
		private IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator;
		private IBOLClientCommunicationMapper BOLClientCommunicationMapper;
		private IDALClientCommunicationMapper DALClientCommunicationMapper;
		private ILogger logger;

		public AbstractClientCommunicationService(
			ILogger logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
			IBOLClientCommunicationMapper bolclientCommunicationMapper,
			IDALClientCommunicationMapper dalclientCommunicationMapper)
			: base()

		{
			this.clientCommunicationRepository = clientCommunicationRepository;
			this.clientCommunicationModelValidator = clientCommunicationModelValidator;
			this.BOLClientCommunicationMapper = bolclientCommunicationMapper;
			this.DALClientCommunicationMapper = dalclientCommunicationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.clientCommunicationRepository.All(skip, take, orderClause);

			return this.BOLClientCommunicationMapper.MapBOToModel(this.DALClientCommunicationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClientCommunicationResponseModel> Get(int id)
		{
			var record = await clientCommunicationRepository.Get(id);

			return this.BOLClientCommunicationMapper.MapBOToModel(this.DALClientCommunicationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
			ApiClientCommunicationRequestModel model)
		{
			CreateResponse<ApiClientCommunicationResponseModel> response = new CreateResponse<ApiClientCommunicationResponseModel>(await this.clientCommunicationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLClientCommunicationMapper.MapModelToBO(default (int), model);
				var record = await this.clientCommunicationRepository.Create(this.DALClientCommunicationMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLClientCommunicationMapper.MapBOToModel(this.DALClientCommunicationMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClientCommunicationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLClientCommunicationMapper.MapModelToBO(id, model);
				await this.clientCommunicationRepository.Update(this.DALClientCommunicationMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.clientCommunicationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2c9edce80108d2cb7da3786845e8a49f</Hash>
</Codenesium>*/