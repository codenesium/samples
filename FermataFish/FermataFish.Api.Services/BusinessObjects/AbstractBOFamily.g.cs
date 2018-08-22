using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOFamily : AbstractBusinessObject
	{
		public AbstractBOFamily()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string note,
		                                  string pcEmail,
		                                  string pcFirstName,
		                                  string pcLastName,
		                                  string pcPhone,
		                                  int studioId)
		{
			this.Id = id;
			this.Note = note;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public string Note { get; private set; }

		public string PcEmail { get; private set; }

		public string PcFirstName { get; private set; }

		public string PcLastName { get; private set; }

		public string PcPhone { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>343ecf5aeaba728dd863a9d15dd855e0</Hash>
</Codenesium>*/