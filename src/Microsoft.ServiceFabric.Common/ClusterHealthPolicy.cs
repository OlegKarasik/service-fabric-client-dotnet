// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a health policy used to evaluate the health of the cluster or of a cluster node.
    /// </summary>
    public partial class ClusterHealthPolicy
    {
        /// <summary>
        /// Initializes a new instance of the ClusterHealthPolicy class.
        /// </summary>
        /// <param name="considerWarningAsError">Indicates whether warnings are treated with the same severity as
        /// errors.</param>
        /// <param name="maxPercentUnhealthyNodes">The maximum allowed percentage of unhealthy nodes before reporting an error.
        /// For example, to allow 10% of nodes to be unhealthy, this value would be 10.
        /// 
        /// The percentage represents the maximum tolerated percentage of nodes that can be unhealthy before the cluster is
        /// considered in error.
        /// If the percentage is respected but there is at least one unhealthy node, the health is evaluated as Warning.
        /// The percentage is calculated by dividing the number of unhealthy nodes over the total number of nodes in the
        /// cluster.
        /// The computation rounds up to tolerate one failure on small numbers of nodes. Default percentage is zero.
        /// 
        /// In large clusters, some nodes will always be down or out for repairs, so this percentage should be configured to
        /// tolerate that.
        /// </param>
        /// <param name="maxPercentUnhealthyApplications">The maximum allowed percentage of unhealthy applications before
        /// reporting an error. For example, to allow 10% of applications to be unhealthy, this value would be 10.
        /// 
        /// The percentage represents the maximum tolerated percentage of applications that can be unhealthy before the cluster
        /// is considered in error.
        /// If the percentage is respected but there is at least one unhealthy application, the health is evaluated as Warning.
        /// This is calculated by dividing the number of unhealthy applications over the total number of application instances
        /// in the cluster, excluding applications of application types that are included in the
        /// ApplicationTypeHealthPolicyMap.
        /// The computation rounds up to tolerate one failure on small numbers of applications. Default percentage is zero.
        /// </param>
        /// <param name="applicationTypeHealthPolicyMap">Defines a map with max percentage unhealthy applications for specific
        /// application types.
        /// Each entry specifies as key the application type name and as value an integer that represents the
        /// MaxPercentUnhealthyApplications percentage used to evaluate the applications of the specified application type.
        /// 
        /// The application type health policy map can be used during cluster health evaluation to describe special application
        /// types.
        /// The application types included in the map are evaluated against the percentage specified in the map, and not with
        /// the global MaxPercentUnhealthyApplications defined in the cluster health policy.
        /// The applications of application types specified in the map are not counted against the global pool of applications.
        /// For example, if some applications of a type are critical, the cluster administrator can add an entry to the map for
        /// that application type
        /// and assign it a value of 0% (that is, do not tolerate any failures).
        /// All other applications can be evaluated with MaxPercentUnhealthyApplications set to 20% to tolerate some failures
        /// out of the thousands of application instances.
        /// The application type health policy map is used only if the cluster manifest enables application type health
        /// evaluation using the configuration entry for HealthManager/EnableApplicationTypeHealthEvaluation.
        /// </param>
        public ClusterHealthPolicy(
            bool? considerWarningAsError = false,
            int? maxPercentUnhealthyNodes = 0,
            int? maxPercentUnhealthyApplications = 0,
            IEnumerable<ApplicationTypeHealthPolicyMapItem> applicationTypeHealthPolicyMap = default(IEnumerable<ApplicationTypeHealthPolicyMapItem>))
        {
            this.ConsiderWarningAsError = considerWarningAsError;
            this.MaxPercentUnhealthyNodes = maxPercentUnhealthyNodes;
            this.MaxPercentUnhealthyApplications = maxPercentUnhealthyApplications;
            this.ApplicationTypeHealthPolicyMap = applicationTypeHealthPolicyMap;
        }

        /// <summary>
        /// Gets indicates whether warnings are treated with the same severity as errors.
        /// </summary>
        public bool? ConsiderWarningAsError { get; }

        /// <summary>
        /// Gets the maximum allowed percentage of unhealthy nodes before reporting an error. For example, to allow 10% of
        /// nodes to be unhealthy, this value would be 10.
        /// 
        /// The percentage represents the maximum tolerated percentage of nodes that can be unhealthy before the cluster is
        /// considered in error.
        /// If the percentage is respected but there is at least one unhealthy node, the health is evaluated as Warning.
        /// The percentage is calculated by dividing the number of unhealthy nodes over the total number of nodes in the
        /// cluster.
        /// The computation rounds up to tolerate one failure on small numbers of nodes. Default percentage is zero.
        /// 
        /// In large clusters, some nodes will always be down or out for repairs, so this percentage should be configured to
        /// tolerate that.
        /// </summary>
        public int? MaxPercentUnhealthyNodes { get; }

        /// <summary>
        /// Gets the maximum allowed percentage of unhealthy applications before reporting an error. For example, to allow 10%
        /// of applications to be unhealthy, this value would be 10.
        /// 
        /// The percentage represents the maximum tolerated percentage of applications that can be unhealthy before the cluster
        /// is considered in error.
        /// If the percentage is respected but there is at least one unhealthy application, the health is evaluated as Warning.
        /// This is calculated by dividing the number of unhealthy applications over the total number of application instances
        /// in the cluster, excluding applications of application types that are included in the
        /// ApplicationTypeHealthPolicyMap.
        /// The computation rounds up to tolerate one failure on small numbers of applications. Default percentage is zero.
        /// </summary>
        public int? MaxPercentUnhealthyApplications { get; }

        /// <summary>
        /// Gets defines a map with max percentage unhealthy applications for specific application types.
        /// Each entry specifies as key the application type name and as value an integer that represents the
        /// MaxPercentUnhealthyApplications percentage used to evaluate the applications of the specified application type.
        /// 
        /// The application type health policy map can be used during cluster health evaluation to describe special application
        /// types.
        /// The application types included in the map are evaluated against the percentage specified in the map, and not with
        /// the global MaxPercentUnhealthyApplications defined in the cluster health policy.
        /// The applications of application types specified in the map are not counted against the global pool of applications.
        /// For example, if some applications of a type are critical, the cluster administrator can add an entry to the map for
        /// that application type
        /// and assign it a value of 0% (that is, do not tolerate any failures).
        /// All other applications can be evaluated with MaxPercentUnhealthyApplications set to 20% to tolerate some failures
        /// out of the thousands of application instances.
        /// The application type health policy map is used only if the cluster manifest enables application type health
        /// evaluation using the configuration entry for HealthManager/EnableApplicationTypeHealthEvaluation.
        /// </summary>
        public IEnumerable<ApplicationTypeHealthPolicyMapItem> ApplicationTypeHealthPolicyMap { get; }
    }
}
