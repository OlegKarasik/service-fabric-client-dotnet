// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents common health report information. It is included in all health reports sent to health store and in all
    /// health events returned by health queries.
    /// </summary>
    public partial class HealthInformation
    {
        /// <summary>
        /// Initializes a new instance of the HealthInformation class.
        /// </summary>
        /// <param name="sourceId">The source name which identifies the client/watchdog/system component which generated the
        /// health information.
        /// </param>
        /// <param name="property">The property of the health information. An entity can have health reports for different
        /// properties.
        /// The property is a string and not a fixed enumeration to allow the reporter flexibility to categorize the state
        /// condition that triggers the report.
        /// For example, a reporter with SourceId "LocalWatchdog" can monitor the state of the available disk on a node,
        /// so it can report "AvailableDisk" property on that node.
        /// The same reporter can monitor the node connectivity, so it can report a property "Connectivity" on the same node.
        /// In the health store, these reports are treated as separate health events for the specified node.
        /// 
        /// Together with the SourceId, the property uniquely identifies the health information.
        /// </param>
        /// <param name="healthState">The health state of a Service Fabric entity such as Cluster, Node, Application, Service,
        /// Partition, Replica etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'</param>
        /// <param name="timeToLiveInMilliSeconds">The duration for which this health report is valid. This field uses ISO8601
        /// format for specifying the duration.
        /// When clients report periodically, they should send reports with higher frequency than time to live.
        /// If clients report on transition, they can set the time to live to infinite.
        /// When time to live expires, the health event that contains the health information
        /// is either removed from health store, if RemoveWhenExpired is true, or evaluated at error, if RemoveWhenExpired
        /// false.
        /// 
        /// If not specified, time to live defaults to infinite value.
        /// </param>
        /// <param name="description">The description of the health information. It represents free text used to add human
        /// readable information about the report.
        /// The maximum string length for the description is 4096 characters.
        /// If the provided string is longer, it will be automatically truncated.
        /// When truncated, the last characters of the description contain a marker "[Truncated]", and total string size is
        /// 4096 characters.
        /// The presence of the marker indicates to users that truncation occurred.
        /// Note that when truncated, the description has less than 4096 characters from the original string.
        /// </param>
        /// <param name="sequenceNumber">The sequence number for this health report as a numeric string.
        /// The report sequence number is used by the health store to detect stale reports.
        /// If not specified, a sequence number is auto-generated by the health client when a report is added.
        /// </param>
        /// <param name="removeWhenExpired">Value that indicates whether the report is removed from health store when it
        /// expires.
        /// If set to true, the report is removed from the health store after it expires.
        /// If set to false, the report is treated as an error when expired. The value of this property is false by default.
        /// When clients report periodically, they should set RemoveWhenExpired false (default).
        /// This way, is the reporter has issues (eg. deadlock) and can't report, the entity is evaluated at error when the
        /// health report expires.
        /// This flags the entity as being in Error health state.
        /// </param>
        public HealthInformation(
            string sourceId,
            string property,
            HealthState? healthState,
            TimeSpan? timeToLiveInMilliSeconds = default(TimeSpan?),
            string description = default(string),
            string sequenceNumber = default(string),
            bool? removeWhenExpired = default(bool?))
        {
            sourceId.ThrowIfNull(nameof(sourceId));
            property.ThrowIfNull(nameof(property));
            healthState.ThrowIfNull(nameof(healthState));
            this.SourceId = sourceId;
            this.Property = property;
            this.HealthState = healthState;
            this.TimeToLiveInMilliSeconds = timeToLiveInMilliSeconds;
            this.Description = description;
            this.SequenceNumber = sequenceNumber;
            this.RemoveWhenExpired = removeWhenExpired;
        }

        /// <summary>
        /// Gets the source name which identifies the client/watchdog/system component which generated the health information.
        /// </summary>
        public string SourceId { get; }

        /// <summary>
        /// Gets the property of the health information. An entity can have health reports for different properties.
        /// The property is a string and not a fixed enumeration to allow the reporter flexibility to categorize the state
        /// condition that triggers the report.
        /// For example, a reporter with SourceId "LocalWatchdog" can monitor the state of the available disk on a node,
        /// so it can report "AvailableDisk" property on that node.
        /// The same reporter can monitor the node connectivity, so it can report a property "Connectivity" on the same node.
        /// In the health store, these reports are treated as separate health events for the specified node.
        /// 
        /// Together with the SourceId, the property uniquely identifies the health information.
        /// </summary>
        public string Property { get; }

        /// <summary>
        /// Gets the health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica
        /// etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public HealthState? HealthState { get; }

        /// <summary>
        /// Gets the duration for which this health report is valid. This field uses ISO8601 format for specifying the
        /// duration.
        /// When clients report periodically, they should send reports with higher frequency than time to live.
        /// If clients report on transition, they can set the time to live to infinite.
        /// When time to live expires, the health event that contains the health information
        /// is either removed from health store, if RemoveWhenExpired is true, or evaluated at error, if RemoveWhenExpired
        /// false.
        /// 
        /// If not specified, time to live defaults to infinite value.
        /// </summary>
        public TimeSpan? TimeToLiveInMilliSeconds { get; }

        /// <summary>
        /// Gets the description of the health information. It represents free text used to add human readable information
        /// about the report.
        /// The maximum string length for the description is 4096 characters.
        /// If the provided string is longer, it will be automatically truncated.
        /// When truncated, the last characters of the description contain a marker "[Truncated]", and total string size is
        /// 4096 characters.
        /// The presence of the marker indicates to users that truncation occurred.
        /// Note that when truncated, the description has less than 4096 characters from the original string.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the sequence number for this health report as a numeric string.
        /// The report sequence number is used by the health store to detect stale reports.
        /// If not specified, a sequence number is auto-generated by the health client when a report is added.
        /// </summary>
        public string SequenceNumber { get; }

        /// <summary>
        /// Gets value that indicates whether the report is removed from health store when it expires.
        /// If set to true, the report is removed from the health store after it expires.
        /// If set to false, the report is treated as an error when expired. The value of this property is false by default.
        /// When clients report periodically, they should set RemoveWhenExpired false (default).
        /// This way, is the reporter has issues (eg. deadlock) and can't report, the entity is evaluated at error when the
        /// health report expires.
        /// This flags the entity as being in Error health state.
        /// </summary>
        public bool? RemoveWhenExpired { get; }
    }
}
