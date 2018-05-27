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
	public abstract class AbstractBOEmailAddress: AbstractBOManager
	{
		private IEmailAddressRepository emailAddressRepository;
		private IApiEmailAddressRequestModelValidator emailAddressModelValidator;
		private IBOLEmailAddressMapper emailAddressMapper;
		private ILogger logger;

		public AbstractBOEmailAddress(
			ILogger logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper emailAddressMapper)
			: base()

		{
			this.emailAddressRepository = emailAddressRepository;
			this.emailAddressModelValidator = emailAddressModelValidator;
			this.emailAddressMapper = emailAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.emailAddressRepository.All(skip, take, orderClause);

			return this.emailAddressMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiEmailAddressResponseModel> Get(int businessEntityID)
		{
			var record = await emailAddressRepository.Get(businessEntityID);

			return this.emailAddressMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
			ApiEmailAddressRequestModel model)
		{
			CreateResponse<ApiEmailAddressResponseModel> response = new CreateResponse<ApiEmailAddressResponseModel>(await this.emailAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.emailAddressMapper.MapModelToDTO(default (int), model);
				var record = await this.emailAddressRepository.Create(dto);

				response.SetRecord(this.emailAddressMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmailAddressRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.emailAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.emailAddressMapper.MapModelToDTO(businessEntityID, model);
				await this.emailAddressRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.emailAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.emailAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiEmailAddressResponseModel>> GetEmailAddress(string emailAddress1)
		{
			List<DTOEmailAddress> records = await this.emailAddressRepository.GetEmailAddress(emailAddress1);

			return this.emailAddressMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>59d159315243971e0ef9e3ee700892f1</Hash>
</Codenesium>*/