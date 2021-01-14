// <copyright file="AlwaysOffSampler.cs" company="OpenTelemetry Authors">
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
    /// Sampler implementation which always returns <c>SamplingDecision.Drop</c>.
    /// </summary>
    public sealed class AlwaysOffSampler : Sampler
    {
        /// <inheritdoc />
        public override SamplingResult ShouldSample(
            in ActivityContext parentContext,
            in ActivityTraceId traceId,
            in string name,
            in ActivityKind kind,
            in IEnumerable<KeyValuePair<string, object>> tags = null, // TODO: Empty
            in IEnumerable<ActivityLink> links = null)
        {
            return new SamplingResult(SamplingDecision.Drop);
        }
    }
}
