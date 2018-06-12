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
    /// Converter for <see cref="ApplicationHealthPolicyMapItem" />.
    /// </summary>
    internal class ApplicationHealthPolicyMapItemConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationHealthPolicyMapItem Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationHealthPolicyMapItem GetFromJsonProperties(JsonReader reader)
        {
            var key = default(ApplicationName);
            var value = default(ApplicationHealthPolicy);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("Key", propName, StringComparison.Ordinal) == 0)
                {
                    key = ApplicationNameConverter.Deserialize(reader);
                }
                else if (string.Compare("Value", propName, StringComparison.Ordinal) == 0)
                {
                    value = ApplicationHealthPolicyConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationHealthPolicyMapItem(
                key: key,
                value: value);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationHealthPolicyMapItem obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Key, "Key", ApplicationNameConverter.Serialize);
            writer.WriteProperty(obj.Value, "Value", ApplicationHealthPolicyConverter.Serialize);
            writer.WriteEndObject();
        }
    }
}
