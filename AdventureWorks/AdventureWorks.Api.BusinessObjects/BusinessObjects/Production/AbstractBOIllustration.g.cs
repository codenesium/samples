using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOIllustration: AbstractBOManager
	{
		private IIllustrationRepository illustrationRepository;
		private IApiIllustrationRequestModelValidator illustrationModelValidator;
		private IBOLIllustrationMapper illustrationMapper;
		private ILogger logger;

		public AbstractBOIllustration(
			ILogger logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper illustrationMapper)
			: base()

		{
			this.illustrationRepository = illustrationRepository;
			this.illustrationModelValidator = illustrationModelValidator;
			this.illustrationMapper = illustrationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.illustrationRepository.All(skip, take, orderClause);

			return this.illustrationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiIllustrationResponseModel> Get(int illustrationID)
		{
			var record = await illustrationRepository.Get(illustrationID);

			return this.illustrationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiIllustrationResponseModel>> Create(
			ApiIllustrationRequestModel model)
		{
			CreateResponse<ApiIllustrationResponseModel> response = new CreateResponse<ApiIllustrationResponseModel>(await this.illustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.illustrationMapper.MapModelToDTO(default (int), model);
				var record = await this.illustrationRepository.Create(dto);

				response.SetRecord(this.illustrationMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int illustrationID,
			ApiIllustrationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateUpdateAsync(illustrationID, model));

			if (response.Success)
			{
				var dto = this.illustrationMapper.MapModelToDTO(illustrationID, model);
				await this.illustrationRepository.Update(illustrationID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int illustrationID)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateDeleteAsync(illustrationID));

			if (response.Success)
			{
				await this.illustrationRepository.Delete(illustrationID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ed052d9b1fecba5ffbecb57fca6ec8e3</Hash>
</Codenesium>*/