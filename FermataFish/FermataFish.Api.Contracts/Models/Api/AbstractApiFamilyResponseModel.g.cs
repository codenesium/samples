using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiFamilyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string notes,
                        string pcEmail,
                        string pcFirstName,
                        string pcLastName,
                        string pcPhone,
                        int studioId)
                {
                        this.Id = id;
                        this.Notes = notes;
                        this.PcEmail = pcEmail;
                        this.PcFirstName = pcFirstName;
                        this.PcLastName = pcLastName;
                        this.PcPhone = pcPhone;
                        this.StudioId = studioId;

                        this.IdEntity = nameof(ApiResponse.Studios);
                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public int Id { get; private set; }

                public string IdEntity { get; set; }

                public string Notes { get; private set; }

                public string PcEmail { get; private set; }

                public string PcFirstName { get; private set; }

                public string PcLastName { get; private set; }

                public string PcPhone { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNotesValue { get; set; } = true;

                public bool ShouldSerializeNotes()
                {
                        return this.ShouldSerializeNotesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePcEmailValue { get; set; } = true;

                public bool ShouldSerializePcEmail()
                {
                        return this.ShouldSerializePcEmailValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePcFirstNameValue { get; set; } = true;

                public bool ShouldSerializePcFirstName()
                {
                        return this.ShouldSerializePcFirstNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePcLastNameValue { get; set; } = true;

                public bool ShouldSerializePcLastName()
                {
                        return this.ShouldSerializePcLastNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePcPhoneValue { get; set; } = true;

                public bool ShouldSerializePcPhone()
                {
                        return this.ShouldSerializePcPhoneValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudioIdValue { get; set; } = true;

                public bool ShouldSerializeStudioId()
                {
                        return this.ShouldSerializeStudioIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNotesValue = false;
                        this.ShouldSerializePcEmailValue = false;
                        this.ShouldSerializePcFirstNameValue = false;
                        this.ShouldSerializePcLastNameValue = false;
                        this.ShouldSerializePcPhoneValue = false;
                        this.ShouldSerializeStudioIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e37e92c49c5c59dea135ab4eb5510389</Hash>
</Codenesium>*/