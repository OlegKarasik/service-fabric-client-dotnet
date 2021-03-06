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
    /// Converter for <see cref="NodeOpeningEvent" />.
    /// </summary>
    internal class NodeOpeningEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeOpeningEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NodeOpeningEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var nodeName = default(NodeName);
            var nodeInstance = default(long?);
            var nodeId = default(string);
            var upgradeDomain = default(string);
            var faultDomain = default(string);
            var ipAddressOrFQDN = default(string);
            var hostname = default(string);
            var isSeedNode = default(bool?);
            var nodeVersion = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
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
                else if (string.Compare("NodeName", propName, StringComparison.Ordinal) == 0)
                {
                    nodeName = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("NodeInstance", propName, StringComparison.Ordinal) == 0)
                {
                    nodeInstance = reader.ReadValueAsLong();
                }
                else if (string.Compare("NodeId", propName, StringComparison.Ordinal) == 0)
                {
                    nodeId = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeDomain", propName, StringComparison.Ordinal) == 0)
                {
                    upgradeDomain = reader.ReadValueAsString();
                }
                else if (string.Compare("FaultDomain", propName, StringComparison.Ordinal) == 0)
                {
                    faultDomain = reader.ReadValueAsString();
                }
                else if (string.Compare("IpAddressOrFQDN", propName, StringComparison.Ordinal) == 0)
                {
                    ipAddressOrFQDN = reader.ReadValueAsString();
                }
                else if (string.Compare("Hostname", propName, StringComparison.Ordinal) == 0)
                {
                    hostname = reader.ReadValueAsString();
                }
                else if (string.Compare("IsSeedNode", propName, StringComparison.Ordinal) == 0)
                {
                    isSeedNode = reader.ReadValueAsBool();
                }
                else if (string.Compare("NodeVersion", propName, StringComparison.Ordinal) == 0)
                {
                    nodeVersion = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeOpeningEvent(
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                nodeName: nodeName,
                nodeInstance: nodeInstance,
                nodeId: nodeId,
                upgradeDomain: upgradeDomain,
                faultDomain: faultDomain,
                ipAddressOrFQDN: ipAddressOrFQDN,
                hostname: hostname,
                isSeedNode: isSeedNode,
                nodeVersion: nodeVersion);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeOpeningEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            writer.WriteProperty(obj.NodeInstance, "NodeInstance", JsonWriterExtensions.WriteLongValue);
            writer.WriteProperty(obj.NodeId, "NodeId", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.UpgradeDomain, "UpgradeDomain", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.FaultDomain, "FaultDomain", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.IpAddressOrFQDN, "IpAddressOrFQDN", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Hostname, "Hostname", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.IsSeedNode, "IsSeedNode", JsonWriterExtensions.WriteBoolValue);
            writer.WriteProperty(obj.NodeVersion, "NodeVersion", JsonWriterExtensions.WriteStringValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
