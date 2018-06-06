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
	public abstract class AbstractClientService: AbstractService
	{
		private IClientRepository clientRepository;
		private IApiClientRequestModelValidator clientModelValidator;
		private IBOLClientMapper bolClientMapper;
		private IDALClientMapper dalClientMapper;
		private ILogger logger;

		public AbstractClientService(
			ILogger logger,
			IClientRepository clientRepository,
			IApiClientRequestModelValidator clientModelValidator,
			IBOLClientMapper bolclientMapper,
			IDALClientMapper dalclientMapper)
			: base()

		{
			this.clientRepository = clientRepository;
			this.clientModelValidator = clientModelValidator;
			this.bolClientMapper = bolclientMapper;
			this.dalClientMapper = dalclientMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClientResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.clientRepository.All(skip, take, orderClause);

			return this.bolClientMapper.MapBOToModel(this.dalClientMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClientResponseModel> Get(int id)
		{
			var record = await clientRepository.Get(id);

			return this.bolClientMapper.MapBOToModel(this.dalClientMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiClientResponseModel>> Create(
			ApiClientRequestModel model)
		{
			CreateResponse<ApiClientResponseModel> response = new CreateResponse<ApiClientResponseModel>(await this.clientModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolClientMapper.MapModelToBO(default (int), model);
				var record = await this.clientRepository.Create(this.dalClientMapper.MapBOToEF(bo));

				response.SetRecord(this.bolClientMapper.MapBOToModel(this.dalClientMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClientRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolClientMapper.MapModelToBO(id, model);
				await this.clientRepository.Update(this.dalClientMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.clientRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>761127b8840510362a4be80ce0fb0eb1</Hash>
</Codenesium>*/