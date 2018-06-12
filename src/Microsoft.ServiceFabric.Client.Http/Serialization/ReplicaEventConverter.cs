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
    /// Converter for <see cref="ReplicaEvent" />.
    /// </summary>
    internal class ReplicaEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ReplicaEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ReplicaEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var partitionId = default(PartitionId);
            var replicaId = default(ReplicaId);

            do
            {
                var propName = reader.ReadPropertyName();
                if (propName.Equals("Kind", StringComparison.Ordinal))
                {
                    var propValue = reader.ReadValueAsString();

                    if (propValue.Equals("StatefulReplicaHealthReportCreated", StringComparison.Ordinal))
                    {
                        return StatefulReplicaHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("StatefulReplicaHealthReportExpired", StringComparison.Ordinal))
                    {
                        return StatefulReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("StatelessReplicaHealthReportCreated", StringComparison.Ordinal))
                    {
                        return StatelessReplicaHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("StatelessReplicaHealthReportExpired", StringComparison.Ordinal))
                    {
                        return StatelessReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRemoveReplicaFaultScheduled", StringComparison.Ordinal))
                    {
                        return ChaosRemoveReplicaFaultScheduledEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRemoveReplicaFaultCompleted", StringComparison.Ordinal))
                    {
                        return ChaosRemoveReplicaFaultCompletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRestartReplicaFaultScheduled", StringComparison.Ordinal))
                    {
                        return ChaosRestartReplicaFaultScheduledEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ReplicaEvent", StringComparison.Ordinal))
                    {
                        // kind specified as same type, deserialize using properties.
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown Discriminator.");
                    }
                }
                else
                {
                    if (string.Compare("EventInstanceId", propName, StringComparison.Ordinal) == 0)
                    {
                        eventInstanceId = reader.ReadValueAsGuid();
                    }
                    else if (string.Compare("TimeStamp", propName, StringComparison.Ordinal) == 0)
                    {
                        timeStamp = reader.ReadValueAsDateTime();
                    }
                    else if (string.Compare("HasCorrelatedEvents", propName, StringComparison.Ordinal) == 0)
                    {
                        hasCorrelatedEvents = reader.ReadValueAsBool();
                    }
                    else if (string.Compare("PartitionId", propName, StringComparison.Ordinal) == 0)
                    {
                        partitionId = PartitionIdConverter.Deserialize(reader);
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
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ReplicaEvent(
                kind: Common.FabricEventKind.ReplicaEvent,
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                partitionId: partitionId,
                replicaId: replicaId);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ReplicaEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.PartitionId, "PartitionId", PartitionIdConverter.Serialize);
            writer.WriteProperty(obj.ReplicaId, "ReplicaId", ReplicaIdConverter.Serialize);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
