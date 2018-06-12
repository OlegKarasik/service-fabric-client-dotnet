// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ServiceCorrelationScheme.
    /// </summary>
    public enum ServiceCorrelationScheme
    {
        /// <summary>
        /// An invalid correlation scheme. Cannot be used. The value is zero..
        /// </summary>
        Invalid,

        /// <summary>
        /// Indicates that this service has an affinity relationship with another service. Provided for backwards
        /// compatibility, consider preferring the Aligned or NonAlignedAffinity options. The value is 1..
        /// </summary>
        Affinity,

        /// <summary>
        /// Aligned affinity ensures that the primaries of the partitions of the affinitized services are collocated on the
        /// same nodes. This is the default and is the same as selecting the Affinity scheme. The value is 2..
        /// </summary>
        AlignedAffinity,

        /// <summary>
        /// Non-Aligned affinity guarantees that all replicas of each service will be placed on the same nodes. Unlike Aligned
        /// Affinity, this does not guarantee that replicas of particular role will be collocated. The value is 3..
        /// </summary>
        NonAlignedAffinity,
    }
}
