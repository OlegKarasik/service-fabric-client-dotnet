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
    /// Converter for <see cref="ApplicationUpgradeRollbackCompleteEvent" />.
    /// </summary>
    internal class ApplicationUpgradeRollbackCompleteEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationUpgradeRollbackCompleteEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationUpgradeRollbackCompleteEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var applicationId = default(string);
            var applicationTypeName = default(string);
            var applicationTypeVersion = default(string);
            var failureReason = default(string);
            var overallUpgradeElapsedTimeInMs = default(double?);

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
                else if (string.Compare("ApplicationId", propName, StringComparison.Ordinal) == 0)
                {
                    applicationId = reader.ReadValueAsString();
                }
                else if (string.Compare("ApplicationTypeName", propName, StringComparison.Ordinal) == 0)
                {
                    applicationTypeName = reader.ReadValueAsString();
                }
                else if (string.Compare("ApplicationTypeVersion", propName, StringComparison.Ordinal) == 0)
                {
                    applicationTypeVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("FailureReason", propName, StringComparison.Ordinal) == 0)
                {
                    failureReason = reader.ReadValueAsString();
                }
                else if (string.Compare("OverallUpgradeElapsedTimeInMs", propName, StringComparison.Ordinal) == 0)
                {
                    overallUpgradeElapsedTimeInMs = reader.ReadValueAsDouble();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationUpgradeRollbackCompleteEvent(
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                applicationId: applicationId,
                applicationTypeName: applicationTypeName,
                applicationTypeVersion: applicationTypeVersion,
                failureReason: failureReason,
                overallUpgradeElapsedTimeInMs: overallUpgradeElapsedTimeInMs);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationUpgradeRollbackCompleteEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.ApplicationId, "ApplicationId", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.ApplicationTypeName, "ApplicationTypeName", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.ApplicationTypeVersion, "ApplicationTypeVersion", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.FailureReason, "FailureReason", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.OverallUpgradeElapsedTimeInMs, "OverallUpgradeElapsedTimeInMs", JsonWriterExtensions.WriteDoubleValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
