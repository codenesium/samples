using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractClientCommunicationMapper
	{
		public virtual ClientCommunication MapBOToEF(
			BOClientCommunication bo)
		{
			ClientCommunication efClientCommunication = new ClientCommunication();
			efClientCommunication.SetProperties(
				bo.ClientId,
				bo.DateCreated,
				bo.EmployeeId,
				bo.Id,
				bo.Notes);
			return efClientCommunication;
		}

		public virtual BOClientCommunication MapEFToBO(
			ClientCommunication ef)
		{
			var bo = new BOClientCommunication();

			bo.SetProperties(
				ef.Id,
				ef.ClientId,
				ef.DateCreated,
				ef.EmployeeId,
				ef.Notes);
			return bo;
		}

		public virtual List<BOClientCommunication> MapEFToBO(
			List<ClientCommunication> records)
		{
			List<BOClientCommunication> response = new List<BOClientCommunication>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dd9eacc0089b1114051b3ebf25278158</Hash>
</Codenesium>*/