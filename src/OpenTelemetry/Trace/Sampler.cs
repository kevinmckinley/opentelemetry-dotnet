// <copyright file="Sampler.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
using System.Collections.Generic;
using System.Diagnostics;

namespace OpenTelemetry.Trace
{
    /// <summary>
    /// Controls the number of samples of traces collected and sent to the backend.
    /// </summary>
    public abstract class Sampler
    {
        protected Sampler()
        {
            this.Description = this.GetType().Name;
        }

        /// <summary>
        /// Gets or sets the sampler description.
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Checks whether activity needs to be created and tracked.
        /// </summary>
        /// <param name="parentContext">Parent activity context. Typically taken from the wire.</param>
        /// <param name="traceId">Trace ID of a activity to be created.</param>
        /// <param name="name">The name (DisplayName) of the activity to be created. Note, that the name of the activity is settable.
        /// So this name can be changed later and Sampler implementation should assume that.
        /// Typical example of a name change is when <see cref="Activity"/> representing incoming http request
        /// has a name of url path and then being updated with route name when routing complete.
        /// </param>
        /// <param name="kind">The kind of the Activity to be created.</param>
        /// <param name="tags">Initial set of Tags for the Activity being constructed.</param>
        /// <param name="links">Links associated with the activity.</param>
        /// <returns>Sampling decision on whether activity needs to be sampled or not.</returns>
        public abstract SamplingResult ShouldSample(
            in ActivityContext parentContext,
            in ActivityTraceId traceId,
            in string name,
            in ActivityKind kind,
            in IEnumerable<KeyValuePair<string, object>> tags = null, // TODO: Empty
            in IEnumerable<ActivityLink> links = null);
    }
}
