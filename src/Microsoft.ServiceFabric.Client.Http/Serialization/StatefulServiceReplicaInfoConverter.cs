// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="StatefulServiceReplicaInfo" />.
    /// </summary>
    internal class StatefulServiceReplicaInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static StatefulServiceReplicaInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static StatefulServiceReplicaInfo GetFromJsonProperties(JsonReader reader)
        {
            var replicaStatus = default(ReplicaStatus?);
            var healthState = default(HealthState?);
            var nodeName = default(NodeName);
            var address = default(string);
            var lastInBuildDurationInSeconds = default(string);
            var replicaRole = default(ReplicaRole?);
            var replicaId = default(ReplicaId);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ReplicaStatus", propName, StringComparison.Ordinal) == 0)
                {
                    replicaStatus = ReplicaStatusConverter.Deserialize(reader);
                }
                else if (string.Compare("HealthState", propName, StringComparison.Ordinal) == 0)
                {
                    healthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("NodeName", propName, StringComparison.Ordinal) == 0)
                {
                    nodeName = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("Address", propName, StringComparison.Ordinal) == 0)
                {
                    address = reader.ReadValueAsString();
                }
                else if (string.Compare("LastInBuildDurationInSeconds", propName, StringComparison.Ordinal) == 0)
                {
                    lastInBuildDurationInSeconds = reader.ReadValueAsString();
                }
                else if (string.Compare("ReplicaRole", propName, StringComparison.Ordinal) == 0)
                {
                    replicaRole = ReplicaRoleConverter.Deserialize(reader);
                }
                else if (string.Compare("ReplicaId", propName, StringComparison.Ordinal) == 0)
                {
                    replicaId = ReplicaIdConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new StatefulServiceReplicaInfo(
                replicaStatus: replicaStatus,
                healthState: healthState,
                nodeName: nodeName,
                address: address,
                lastInBuildDurationInSeconds: lastInBuildDurationInSeconds,
                replicaRole: replicaRole,
                replicaId: replicaId);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, StatefulServiceReplicaInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.ServiceKind.ToString(), "ServiceKind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.ReplicaStatus, "ReplicaStatus", ReplicaStatusConverter.Serialize);
            writer.WriteProperty(obj.HealthState, "HealthState", HealthStateConverter.Serialize);
            writer.WriteProperty(obj.ReplicaRole, "ReplicaRole", ReplicaRoleConverter.Serialize);
            if (obj.NodeName != null)
            {
                writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            }

            if (obj.Address != null)
            {
                writer.WriteProperty(obj.Address, "Address", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.LastInBuildDurationInSeconds != null)
            {
                writer.WriteProperty(obj.LastInBuildDurationInSeconds, "LastInBuildDurationInSeconds", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ReplicaId != null)
            {
                writer.WriteProperty(obj.ReplicaId, "ReplicaId", ReplicaIdConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
