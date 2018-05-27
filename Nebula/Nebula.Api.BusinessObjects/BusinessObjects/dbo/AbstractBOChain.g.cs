using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOChain: AbstractBOManager
	{
		private IChainRepository chainRepository;
		private IApiChainRequestModelValidator chainModelValidator;
		private IBOLChainMapper chainMapper;
		private ILogger logger;

		public AbstractBOChain(
			ILogger logger,
			IChainRepository chainRepository,
			IApiChainRequestModelValidator chainModelValidator,
			IBOLChainMapper chainMapper)
			: base()

		{
			this.chainRepository = chainRepository;
			this.chainModelValidator = chainModelValidator;
			this.chainMapper = chainMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChainResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.chainRepository.All(skip, take, orderClause);

			return this.chainMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiChainResponseModel> Get(int id)
		{
			var record = await chainRepository.Get(id);

			return this.chainMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiChainResponseModel>> Create(
			ApiChainRequestModel model)
		{
			CreateResponse<ApiChainResponseModel> response = new CreateResponse<ApiChainResponseModel>(await this.chainModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.chainMapper.MapModelToDTO(default (int), model);
				var record = await this.chainRepository.Create(dto);

				response.SetRecord(this.chainMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiChainRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.chainMapper.MapModelToDTO(id, model);
				await this.chainRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.chainRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiChainResponseModel> GetExternalId(Guid externalId)
		{
			DTOChain record = await this.chainRepository.GetExternalId(externalId);

			return this.chainMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>5ccd3e1a6caada7b8cd38b7ab2e9a92d</Hash>
</Codenesium>*/