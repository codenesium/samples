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
		protected IEmailAddressRepository EmailAddressRepository { get; private set; }

		protected IApiEmailAddressRequestModelValidator EmailAddressModelValidator { get; private set; }

		protected IBOLEmailAddressMapper BolEmailAddressMapper { get; private set; }

		protected IDALEmailAddressMapper DalEmailAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractEmailAddressService(
			ILogger logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper bolEmailAddressMapper,
			IDALEmailAddressMapper dalEmailAddressMapper)
			: base()
		{
			this.EmailAddressRepository = emailAddressRepository;
			this.EmailAddressModelValidator = emailAddressModelValidator;
			this.BolEmailAddressMapper = bolEmailAddressMapper;
			this.DalEmailAddressMapper = dalEmailAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmailAddressRepository.All(limit, offset);

			return this.BolEmailAddressMapper.MapBOToModel(this.DalEmailAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmailAddressResponseModel> Get(int businessEntityID)
		{
			var record = await this.EmailAddressRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmailAddressMapper.MapBOToModel(this.DalEmailAddressMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
			ApiEmailAddressRequestModel model)
		{
			CreateResponse<ApiEmailAddressResponseModel> response = new CreateResponse<ApiEmailAddressResponseModel>(await this.EmailAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEmailAddressMapper.MapModelToBO(default(int), model);
				var record = await this.EmailAddressRepository.Create(this.DalEmailAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEmailAddressMapper.MapBOToModel(this.DalEmailAddressMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmailAddressResponseModel>> Update(
			int businessEntityID,
			ApiEmailAddressRequestModel model)
		{
			var validationResult = await this.EmailAddressModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEmailAddressMapper.MapModelToBO(businessEntityID, model);
				await this.EmailAddressRepository.Update(this.DalEmailAddressMapper.MapBOToEF(bo));

				var record = await this.EmailAddressRepository.Get(businessEntityID);

				return new UpdateResponse<ApiEmailAddressResponseModel>(this.BolEmailAddressMapper.MapBOToModel(this.DalEmailAddressMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmailAddressResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.EmailAddressModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.EmailAddressRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiEmailAddressResponseModel>> ByEmailAddress(string emailAddress1, int limit = 0, int offset = int.MaxValue)
		{
			List<EmailAddress> records = await this.EmailAddressRepository.ByEmailAddress(emailAddress1, limit, offset);

			return this.BolEmailAddressMapper.MapBOToModel(this.DalEmailAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2d829b6e05c0baf3e80ab25dd77ef046</Hash>
</Codenesium>*/