// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes an update for a stateless service.
    /// </summary>
    public partial class StatelessServiceUpdateDescription : ServiceUpdateDescription
    {
        /// <summary>
        /// Initializes a new instance of the StatelessServiceUpdateDescription class.
        /// </summary>
        /// <param name="flags">Flags indicating whether other properties are set. Each of the associated properties
        /// corresponds to a flag, specified below, which, if set, indicate that the property is specified.
        /// This property can be a combination of those flags obtained using bitwise 'OR' operator.
        /// For example, if the provided value is 6 then the flags for ReplicaRestartWaitDuration (2) and
        /// QuorumLossWaitDuration (4) are set.
        /// 
        /// - None - Does not indicate any other properties are set. The value is zero.
        /// - TargetReplicaSetSize/InstanceCount - Indicates whether the TargetReplicaSetSize property (for Stateful services)
        /// or the InstanceCount property (for Stateless services) is set. The value is 1.
        /// - ReplicaRestartWaitDuration - Indicates the ReplicaRestartWaitDuration property is set. The value is  2.
        /// - QuorumLossWaitDuration - Indicates the QuorumLossWaitDuration property is set. The value is 4.
        /// - StandByReplicaKeepDuration - Indicates the StandByReplicaKeepDuration property is set. The value is 8.
        /// - MinReplicaSetSize - Indicates the MinReplicaSetSize property is set. The value is 16.
        /// - PlacementConstraints - Indicates the PlacementConstraints property is set. The value is 32.
        /// - PlacementPolicyList - Indicates the ServicePlacementPolicies property is set. The value is 64.
        /// - Correlation - Indicates the CorrelationScheme property is set. The value is 128.
        /// - Metrics - Indicates the ServiceLoadMetrics property is set. The value is 256.
        /// - DefaultMoveCost - Indicates the DefaultMoveCost property is set. The value is 512.
        /// - ScalingPolicy - Indicates the ScalingPolicies property is set. The value is 1024.
        /// </param>
        /// <param name="placementConstraints">The placement constraints as a string. Placement constraints are boolean
        /// expressions on node properties and allow for restricting a service to particular nodes based on the service
        /// requirements. For example, to place a service on nodes where NodeType is blue specify the following: "NodeColor ==
        /// blue)".</param>
        /// <param name="correlationScheme">The correlation scheme.</param>
        /// <param name="loadMetrics">The service load metrics.</param>
        /// <param name="servicePlacementPolicies">The service placement policies.</param>
        /// <param name="defaultMoveCost">Specifies the move cost for the service. Possible values include: 'Zero', 'Low',
        /// 'Medium', 'High'</param>
        /// <param name="scalingPolicies">Scaling policies for this service.</param>
        /// <param name="instanceCount">The instance count.</param>
        public StatelessServiceUpdateDescription(
            string flags = default(string),
            string placementConstraints = default(string),
            IEnumerable<ServiceCorrelationDescription> correlationScheme = default(IEnumerable<ServiceCorrelationDescription>),
            IEnumerable<ServiceLoadMetricDescription> loadMetrics = default(IEnumerable<ServiceLoadMetricDescription>),
            IEnumerable<ServicePlacementPolicyDescription> servicePlacementPolicies = default(IEnumerable<ServicePlacementPolicyDescription>),
            MoveCost? defaultMoveCost = default(MoveCost?),
            IEnumerable<ScalingPolicyDescription> scalingPolicies = default(IEnumerable<ScalingPolicyDescription>),
            int? instanceCount = default(int?))
            : base(
                Common.ServiceKind.Stateless,
                flags,
                placementConstraints,
                correlationScheme,
                loadMetrics,
                servicePlacementPolicies,
                defaultMoveCost,
                scalingPolicies)
        {
            instanceCount?.ThrowIfLessThan("instanceCount", -1);
            this.InstanceCount = instanceCount;
        }

        /// <summary>
        /// Gets the instance count.
        /// </summary>
        public int? InstanceCount { get; }
    }
}
