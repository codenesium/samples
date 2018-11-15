using Microsoft.EntityFrameworkCore;
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
				bo.Note);
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
				ef.Note);
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
    <Hash>2a8b4ae7b2030237dd69daa0261a3dc7</Hash>
</Codenesium>*/