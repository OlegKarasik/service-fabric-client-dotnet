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
    /// Converter for <see cref="BackupSuspensionInfo" />.
    /// </summary>
    internal class BackupSuspensionInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static BackupSuspensionInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static BackupSuspensionInfo GetFromJsonProperties(JsonReader reader)
        {
            var isSuspended = default(bool?);
            var suspensionInheritedFrom = default(BackupSuspensionScope?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("IsSuspended", propName, StringComparison.Ordinal) == 0)
                {
                    isSuspended = reader.ReadValueAsBool();
                }
                else if (string.Compare("SuspensionInheritedFrom", propName, StringComparison.Ordinal) == 0)
                {
                    suspensionInheritedFrom = BackupSuspensionScopeConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new BackupSuspensionInfo(
                isSuspended: isSuspended,
                suspensionInheritedFrom: suspensionInheritedFrom);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, BackupSuspensionInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.SuspensionInheritedFrom, "SuspensionInheritedFrom", BackupSuspensionScopeConverter.Serialize);
            if (obj.IsSuspended != null)
            {
                writer.WriteProperty(obj.IsSuspended, "IsSuspended", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
