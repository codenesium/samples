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
	public abstract class AbstractBOLink: AbstractBOManager
	{
		private ILinkRepository linkRepository;
		private IApiLinkRequestModelValidator linkModelValidator;
		private IBOLLinkMapper linkMapper;
		private ILogger logger;

		public AbstractBOLink(
			ILogger logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper linkMapper)
			: base()

		{
			this.linkRepository = linkRepository;
			this.linkModelValidator = linkModelValidator;
			this.linkMapper = linkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.linkRepository.All(skip, take, orderClause);

			return this.linkMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLinkResponseModel> Get(int id)
		{
			var record = await linkRepository.Get(id);

			return this.linkMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model)
		{
			CreateResponse<ApiLinkResponseModel> response = new CreateResponse<ApiLinkResponseModel>(await this.linkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.linkMapper.MapModelToDTO(default (int), model);
				var record = await this.linkRepository.Create(dto);

				response.SetRecord(this.linkMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLinkRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.linkMapper.MapModelToDTO(id, model);
				await this.linkRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.linkRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiLinkResponseModel> GetExternalId(Guid externalId)
		{
			DTOLink record = await this.linkRepository.GetExternalId(externalId);

			return this.linkMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiLinkResponseModel>> GetChainId(int chainId)
		{
			List<DTOLink> records = await this.linkRepository.GetChainId(chainId);

			return this.linkMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>8b18e225c9bdac86d1e270a034b786f1</Hash>
</Codenesium>*/