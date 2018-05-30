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

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOClient: AbstractBOManager
	{
		private IClientRepository clientRepository;
		private IApiClientRequestModelValidator clientModelValidator;
		private IBOLClientMapper clientMapper;
		private ILogger logger;

		public AbstractBOClient(
			ILogger logger,
			IClientRepository clientRepository,
			IApiClientRequestModelValidator clientModelValidator,
			IBOLClientMapper clientMapper)
			: base()

		{
			this.clientRepository = clientRepository;
			this.clientModelValidator = clientModelValidator;
			this.clientMapper = clientMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClientResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.clientRepository.All(skip, take, orderClause);

			return this.clientMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiClientResponseModel> Get(int id)
		{
			var record = await clientRepository.Get(id);

			return this.clientMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiClientResponseModel>> Create(
			ApiClientRequestModel model)
		{
			CreateResponse<ApiClientResponseModel> response = new CreateResponse<ApiClientResponseModel>(await this.clientModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.clientMapper.MapModelToDTO(default (int), model);
				var record = await this.clientRepository.Create(dto);

				response.SetRecord(this.clientMapper.MapDTOToModel(record));
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
				var dto = this.clientMapper.MapModelToDTO(id, model);
				await this.clientRepository.Update(id, dto);
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
    <Hash>befb3775a0e87c681af5d145c2cea928</Hash>
</Codenesium>*/