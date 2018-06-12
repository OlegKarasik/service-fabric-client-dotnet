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
    /// Converter for <see cref="ClusterConfigurationUpgradeStatusInfo" />.
    /// </summary>
    internal class ClusterConfigurationUpgradeStatusInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterConfigurationUpgradeStatusInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterConfigurationUpgradeStatusInfo GetFromJsonProperties(JsonReader reader)
        {
            var upgradeState = default(UpgradeState?);
            var progressStatus = default(int?);
            var configVersion = default(string);
            var details = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("UpgradeState", propName, StringComparison.Ordinal) == 0)
                {
                    upgradeState = UpgradeStateConverter.Deserialize(reader);
                }
                else if (string.Compare("ProgressStatus", propName, StringComparison.Ordinal) == 0)
                {
                    progressStatus = reader.ReadValueAsInt();
                }
                else if (string.Compare("ConfigVersion", propName, StringComparison.Ordinal) == 0)
                {
                    configVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("Details", propName, StringComparison.Ordinal) == 0)
                {
                    details = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ClusterConfigurationUpgradeStatusInfo(
                upgradeState: upgradeState,
                progressStatus: progressStatus,
                configVersion: configVersion,
                details: details);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ClusterConfigurationUpgradeStatusInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.UpgradeState, "UpgradeState", UpgradeStateConverter.Serialize);
            if (obj.ProgressStatus != null)
            {
                writer.WriteProperty(obj.ProgressStatus, "ProgressStatus", JsonWriterExtensions.WriteIntValue);
            }

            if (obj.ConfigVersion != null)
            {
                writer.WriteProperty(obj.ConfigVersion, "ConfigVersion", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.Details != null)
            {
                writer.WriteProperty(obj.Details, "Details", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
