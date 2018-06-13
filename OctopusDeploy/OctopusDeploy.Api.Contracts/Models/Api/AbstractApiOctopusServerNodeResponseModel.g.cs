using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiOctopusServerNodeResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool isInMaintenanceMode,
                        string jSON,
                        DateTimeOffset lastSeen,
                        int maxConcurrentTasks,
                        string name,
                        string rank)
                {
                        this.Id = id;
                        this.IsInMaintenanceMode = isInMaintenanceMode;
                        this.JSON = jSON;
                        this.LastSeen = lastSeen;
                        this.MaxConcurrentTasks = maxConcurrentTasks;
                        this.Name = name;
                        this.Rank = rank;
                }

                public string Id { get; private set; }

                public bool IsInMaintenanceMode { get; private set; }

                public string JSON { get; private set; }

                public DateTimeOffset LastSeen { get; private set; }

                public int MaxConcurrentTasks { get; private set; }

                public string Name { get; private set; }

                public string Rank { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsInMaintenanceModeValue { get; set; } = true;

                public bool ShouldSerializeIsInMaintenanceMode()
                {
                        return this.ShouldSerializeIsInMaintenanceModeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastSeenValue { get; set; } = true;

                public bool ShouldSerializeLastSeen()
                {
                        return this.ShouldSerializeLastSeenValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMaxConcurrentTasksValue { get; set; } = true;

                public bool ShouldSerializeMaxConcurrentTasks()
                {
                        return this.ShouldSerializeMaxConcurrentTasksValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRankValue { get; set; } = true;

                public bool ShouldSerializeRank()
                {
                        return this.ShouldSerializeRankValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsInMaintenanceModeValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeLastSeenValue = false;
                        this.ShouldSerializeMaxConcurrentTasksValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRankValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e2a5a4329404664c3abf130cba0aa3a3</Hash>
</Codenesium>*/