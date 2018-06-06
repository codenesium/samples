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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractEmailAddressService: AbstractService
	{
		private IEmailAddressRepository emailAddressRepository;
		private IApiEmailAddressRequestModelValidator emailAddressModelValidator;
		private IBOLEmailAddressMapper bolEmailAddressMapper;
		private IDALEmailAddressMapper dalEmailAddressMapper;
		private ILogger logger;

		public AbstractEmailAddressService(
			ILogger logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper bolemailAddressMapper,
			IDALEmailAddressMapper dalemailAddressMapper)
			: base()

		{
			this.emailAddressRepository = emailAddressRepository;
			this.emailAddressModelValidator = emailAddressModelValidator;
			this.bolEmailAddressMapper = bolemailAddressMapper;
			this.dalEmailAddressMapper = dalemailAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.emailAddressRepository.All(skip, take, orderClause);

			return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmailAddressResponseModel> Get(int businessEntityID)
		{
			var record = await emailAddressRepository.Get(businessEntityID);

			return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
			ApiEmailAddressRequestModel model)
		{
			CreateResponse<ApiEmailAddressResponseModel> response = new CreateResponse<ApiEmailAddressResponseModel>(await this.emailAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolEmailAddressMapper.MapModelToBO(default (int), model);
				var record = await this.emailAddressRepository.Create(this.dalEmailAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(record)));
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
				var bo = this.bolEmailAddressMapper.MapModelToBO(businessEntityID, model);
				await this.emailAddressRepository.Update(this.dalEmailAddressMapper.MapBOToEF(bo));
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
			List<EmailAddress> records = await this.emailAddressRepository.GetEmailAddress(emailAddress1);

			return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f2999e7a764eaed8e364a76fa0a8f320</Hash>
</Codenesium>*/