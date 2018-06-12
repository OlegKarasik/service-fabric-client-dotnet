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
    /// Converter for <see cref="CreateFabricDump" />.
    /// </summary>
    internal class CreateFabricDumpConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static CreateFabricDump? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(CreateFabricDump);

            if (string.Compare(value, "False", StringComparison.Ordinal) == 0)
            {
                obj = CreateFabricDump.False;
            }
            else if (string.Compare(value, "True", StringComparison.Ordinal) == 0)
            {
                obj = CreateFabricDump.True;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, CreateFabricDump? value)
        {
            switch (value)
            {
                case CreateFabricDump.False:
                    writer.WriteStringValue("False");
                    break;
                case CreateFabricDump.True:
                    writer.WriteStringValue("True");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type CreateFabricDump");
            }
        }
    }
}
