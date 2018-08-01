using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractEmailAddressService : AbstractService
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
			IBOLEmailAddressMapper bolEmailAddressMapper,
			IDALEmailAddressMapper dalEmailAddressMapper)
			: base()
		{
			this.emailAddressRepository = emailAddressRepository;
			this.emailAddressModelValidator = emailAddressModelValidator;
			this.bolEmailAddressMapper = bolEmailAddressMapper;
			this.dalEmailAddressMapper = dalEmailAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.emailAddressRepository.All(limit, offset);

			return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmailAddressResponseModel> Get(int businessEntityID)
		{
			var record = await this.emailAddressRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
			ApiEmailAddressRequestModel model)
		{
			CreateResponse<ApiEmailAddressResponseModel> response = new CreateResponse<ApiEmailAddressResponseModel>(await this.emailAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolEmailAddressMapper.MapModelToBO(default(int), model);
				var record = await this.emailAddressRepository.Create(this.dalEmailAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmailAddressResponseModel>> Update(
			int businessEntityID,
			ApiEmailAddressRequestModel model)
		{
			var validationResult = await this.emailAddressModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolEmailAddressMapper.MapModelToBO(businessEntityID, model);
				await this.emailAddressRepository.Update(this.dalEmailAddressMapper.MapBOToEF(bo));

				var record = await this.emailAddressRepository.Get(businessEntityID);

				return new UpdateResponse<ApiEmailAddressResponseModel>(this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmailAddressResponseModel>(validationResult);
			}
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

		public async Task<List<ApiEmailAddressResponseModel>> ByEmailAddress(string emailAddress1)
		{
			List<EmailAddress> records = await this.emailAddressRepository.ByEmailAddress(emailAddress1);

			return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4fa0c906d048c50046017d3e1b03b1c0</Hash>
</Codenesium>*/